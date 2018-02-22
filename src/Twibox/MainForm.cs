namespace Vurdalakov
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private WebService _webService = new WebService();

        private ImageBuilder _imageBuilder;

        private String _imageFileName;

        public String AppName { get; }
        public String AppVersion { get; }
        public ImageEditingMode Mode { get; private set; }  = ImageEditingMode.Adjust;

        public MainForm()
        {
            InitializeComponent();

            var fileVersionInfo = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location);
            this.AppName = fileVersionInfo.ProductName;
            this.AppVersion = fileVersionInfo.FileVersion;

            this._adjustmentTimer.AutoReset = false;
            this._adjustmentTimer.Enabled = false;
            this._adjustmentTimer.Interval = 100;
            this._adjustmentTimer.Elapsed += (s, e) => this._adjustmentResetEvent.Set();
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            this.UpgradeUserSettings();
            this.RestoreWindowPlacement();

            // hide tab control header
            this.tabControl1.ItemSize = new Size(0, 1);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;

            this._webService.Start(this);

            this.SetupTrackBars();

            new Thread(this.Processor).Start();

            this.SetImageEditingMode(ImageEditingMode.Adjust.ToString(), true);

            this.OpenImageFile(@"D:\photo\5489064_xlarge.jpg");
        }

        private void SetTitle()
        {
            this.Text = $"{this.AppName} {this.AppVersion} [{this.Mode} mode] - {this._imageFileName ?? "<Untitled>"}";
        }

        private void SetupTrackBars()
        {
            SetupTrackBar(this.trackBarContrast);

            void SetupTrackBar(TrackBar trackBar)
            {
                trackBar.MouseClick += (s, e) => ResetAdjustment(s, e);
            }

            void ResetAdjustment(Object sender, MouseEventArgs args)
            {
                if (MouseButtons.Right == args.Button)
                {
                    if (sender is TrackBar trackBar)
                    {
                        trackBar.Value = 0;
                    }
                }
            }
        }

        private Boolean _closing = false;

        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this._closing = true;
            this._adjustmentResetEvent.Set();

            this._webService.Stop();

            this.SaveWindowPlacement();
        }

        private void MainForm_Resize(Object sender, EventArgs e)
        {
            this._imageBuilder?.UpdateImage();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.A:
                    this.adjustToolStripMenuItem.PerformClick();
                    return true;
                case Keys.C:
                    this.cropToolStripMenuItem.PerformClick();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void OpenImageFile(String fileName)
        {
            this._imageFileName = fileName;

            var fileSize = new FileInfo(fileName).Length;

            using (var fileStream = File.OpenRead(fileName))
            {
                if (this._imageBuilder != null)
                {
                    this._imageBuilder.Dispose();
                    this._imageBuilder = null;
                }

                this._imageBuilder = new ImageBuilder();
                this._imageBuilder.Init(this.imageControl, fileStream);
                this._imageBuilder.UpdateImage();
            }
        }

        private void openToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All image types|*.bmp;*.gif;*.jpg;*.jpeg;*.png|BMP|*.bmp|GIF|*.gif|JPEG|*.jpg;*.jpeg|PNG|*.png";

            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            this.OpenImageFile(openFileDialog.FileName);
        }

        private void exitToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        private class AdjustmentEvent
        {
            public ImageAdjustmentType Type { get; set; }
            public Int32 Diff { get; set; }
            public Int32 Value { get; set; }
        }

        private System.Timers.Timer _adjustmentTimer = new System.Timers.Timer();
        private AutoResetEvent _adjustmentResetEvent = new AutoResetEvent(false);
        private Stack<AdjustmentEvent> _adjustmentEvents = new Stack<AdjustmentEvent>();
        private AdjustmentEvent _lastAdjustment = null;

        private void AddEvent(ImageAdjustmentType type, Int32 diff, Int32 value)
        {
            lock (this._adjustmentEvents)
            {
                if ((this._lastAdjustment != null) && (type == this._lastAdjustment.Type))
                {
                    Trace.WriteLine($"Skip {value}");

                    this._lastAdjustment.Diff = 0;
                    this._lastAdjustment.Value = value;
                }
                else
                {
                    Trace.WriteLine($"Add  {value}");

                    this._lastAdjustment = new AdjustmentEvent()
                    {
                        Type = type,
                        Diff = diff,
                        Value = value
                    };
                    this._adjustmentEvents.Push(this._lastAdjustment);
                }
            }

            this._adjustmentTimer.Stop();
            this._adjustmentTimer.Start();
        }

        private void ChangeContrast(Int32 contrastValue)
        {
            AddEvent(ImageAdjustmentType.Contrast, 0, contrastValue);
        }

        private void trackBarContrast_ValueChanged(Object sender, EventArgs e)
        {
            this.ChangeContrast(this.trackBarContrast.Value);
            this.numericUpDownContrast.Value = this.trackBarContrast.Value;
        }

        private void numericUpDownContrast_ValueChanged(Object sender, EventArgs e)
        {
            this.ChangeContrast((Int32)this.numericUpDownContrast.Value);
            this.trackBarContrast.Value = (Int32)this.numericUpDownContrast.Value;
        }

        private void Processor()
        {
            while (true)
            {
                this._adjustmentResetEvent.WaitOne();
                if (this._closing)
                {
                    return;
                }

                lock (this._adjustmentEvents)
                {
                    while (this._adjustmentEvents.Count > 0)
                    {
                        var adjustmentEvent = this._adjustmentEvents.Pop();
                        this.UpdateImageProperties(adjustmentEvent);
                    }

                    this._lastAdjustment = null;

                    this._imageBuilder.UpdateImage();
                }
            }
        }

        private void UpdateImageProperties(AdjustmentEvent adjustmentEvent)
        {
            switch (adjustmentEvent.Type)
            {
                case ImageAdjustmentType.Contrast:
                    var contrastValue = 0 == adjustmentEvent.Diff ? adjustmentEvent.Value : (this.trackBarContrast.Value + adjustmentEvent.Diff);
                    this._imageBuilder.ImageProperties.Contrast = contrastValue;
                    break;
            }
        }

        private void SetImageEditingMode(String modeName, Boolean switchTabPage = true)
        {
            var mode = modeName.ToImageEditingMode();
            if (ImageEditingMode.None == mode)
            {
                return;
            }

            this.Mode = mode;
            this.SetTitle();

            foreach (var toolStripItem in this.toolStripStandard.Items)
            {
                if (toolStripItem is ToolStripButton toolStripButton)
                {
                    var buttonMode = ImageEditingModeExtensions.ToImageEditingMode(toolStripButton.Tag as String);
                    if (buttonMode != ImageEditingMode.None)
                    {
                        toolStripButton.Checked = buttonMode == mode;
                    }
                }
            }

            if (!switchTabPage)
            {
                return;
            }

            foreach (TabPage tabPage in this.tabControl1.TabPages)
            {
                if (tabPage.IsImageEditingMode(mode))
                {
                    this.tabControl1.SelectedTab = tabPage;
                    break;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.SetImageEditingMode(this.tabControl1.SelectedTab.Tag as String, false);
        }

        private void toolStripItemMode_Click(Object sender, EventArgs e)
        {
            this.SetImageEditingMode((sender as ToolStripItem)?.Tag as String);
        }
    }
}
