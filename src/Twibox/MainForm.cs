namespace Vurdalakov
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private ImageProperties _imageProperties = new ImageProperties();
        private ImageBuilder _imageBuilder = new ImageBuilder();

        public MainForm()
        {
            InitializeComponent();

            this._adjustmentTimer.AutoReset = false;
            this._adjustmentTimer.Enabled = false;
            this._adjustmentTimer.Interval = 100;
            this._adjustmentTimer.Elapsed += (s, e) => this._adjustmentResetEvent.Set();
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            this.SetupTrackBars();

            new Thread(this.Processor).Start();

            this.OpenImageFile(@"D:\photo\5489064_xlarge.jpg");
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
        }

        private void OpenImageFile(String fileName)
        {
            var fileSize = new FileInfo(fileName).Length;

            using (var fileStream = File.OpenRead(fileName))
            {
                this._imageBuilder.SetImage(fileStream);
                this._imageBuilder.UpdateImage(this.pictureBox1, fileStream);
            }
        }

        private void openToolStripMenuItem_Click(Object sender, EventArgs e)
        {

        }

        private class AdjustmentEvent
        {
            public Int32 Type { get; set; }
            public Int32 Diff { get; set; }
            public Int32 Value { get; set; }
        }

        private System.Timers.Timer _adjustmentTimer = new System.Timers.Timer();
        private AutoResetEvent _adjustmentResetEvent = new AutoResetEvent(false);
        private Stack<AdjustmentEvent> _adjustmentEvents = new Stack<AdjustmentEvent>();
        private AdjustmentEvent _lastAdjustment = null;

        private void AddEvent(Int32 type, Int32 diff, Int32 value)
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
            AddEvent(1, 0, contrastValue);
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

                    this._imageBuilder.ApplyTo(this.pictureBox1, this._imageProperties);
                }
            }
        }

        private void UpdateImageProperties(AdjustmentEvent adjustmentEvent)
        {
            var contrastValue = 0 == adjustmentEvent.Diff ? adjustmentEvent.Value : (this.trackBarContrast.Value + adjustmentEvent.Diff);

            this._imageProperties.Contrast = contrastValue;
        }
    }
}
