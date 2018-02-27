namespace Vurdalakov
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageControl = new Vurdalakov.ImageControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.numericUpDownContrast = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStripStandard = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdjust = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCrop = new System.Windows.Forms.ToolStripButton();
            this.buttonCropStart = new System.Windows.Forms.Button();
            this.buttonCropApply = new System.Windows.Forms.Button();
            this.buttonCropReject = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownContrast)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStripStandard.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 813);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1356, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1356, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustToolStripMenuItem,
            this.cropToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "&Mode";
            // 
            // adjustToolStripMenuItem
            // 
            this.adjustToolStripMenuItem.Name = "adjustToolStripMenuItem";
            this.adjustToolStripMenuItem.ShortcutKeyDisplayString = "A";
            this.adjustToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.adjustToolStripMenuItem.Tag = "Adjust";
            this.adjustToolStripMenuItem.Text = "&Adjust";
            this.adjustToolStripMenuItem.Click += new System.EventHandler(this.toolStripItemMode_Click);
            // 
            // cropToolStripMenuItem
            // 
            this.cropToolStripMenuItem.Name = "cropToolStripMenuItem";
            this.cropToolStripMenuItem.ShortcutKeyDisplayString = "C";
            this.cropToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.cropToolStripMenuItem.Tag = "Crop";
            this.cropToolStripMenuItem.Text = "&Crop";
            this.cropToolStripMenuItem.Click += new System.EventHandler(this.toolStripItemMode_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1356, 735);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1356, 789);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripStandard);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1356, 735);
            this.splitContainer1.SplitterDistance = 984;
            this.splitContainer1.TabIndex = 0;
            // 
            // imageControl
            // 
            this.imageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageControl.Location = new System.Drawing.Point(0, 0);
            this.imageControl.Name = "imageControl";
            this.imageControl.Size = new System.Drawing.Size(984, 735);
            this.imageControl.TabIndex = 0;
            this.imageControl.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 735);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.trackBarContrast);
            this.tabPage1.Controls.Add(this.numericUpDownContrast);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(360, 709);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "Adjust";
            this.tabPage1.Text = "Adjust";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contrast";
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.LargeChange = 10;
            this.trackBarContrast.Location = new System.Drawing.Point(6, 18);
            this.trackBarContrast.Maximum = 100;
            this.trackBarContrast.Minimum = -100;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(265, 45);
            this.trackBarContrast.TabIndex = 0;
            this.trackBarContrast.Tag = "Contrast";
            this.trackBarContrast.TickFrequency = 10;
            this.trackBarContrast.ValueChanged += new System.EventHandler(this.OnAdjustmentControlValueChanged);
            // 
            // numericUpDownContrast
            // 
            this.numericUpDownContrast.Location = new System.Drawing.Point(288, 18);
            this.numericUpDownContrast.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownContrast.Name = "numericUpDownContrast";
            this.numericUpDownContrast.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownContrast.TabIndex = 1;
            this.numericUpDownContrast.Tag = "Contrast";
            this.numericUpDownContrast.ValueChanged += new System.EventHandler(this.OnAdjustmentControlValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.buttonCropReject);
            this.tabPage2.Controls.Add(this.buttonCropApply);
            this.tabPage2.Controls.Add(this.buttonCropStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(360, 709);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Crop";
            this.tabPage2.Text = "Crop";
            // 
            // toolStripStandard
            // 
            this.toolStripStandard.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripStandard.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdjust,
            this.toolStripButtonCrop});
            this.toolStripStandard.Location = new System.Drawing.Point(3, 0);
            this.toolStripStandard.Name = "toolStripStandard";
            this.toolStripStandard.Size = new System.Drawing.Size(94, 54);
            this.toolStripStandard.TabIndex = 0;
            // 
            // toolStripButtonAdjust
            // 
            this.toolStripButtonAdjust.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdjust.Image")));
            this.toolStripButtonAdjust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdjust.Name = "toolStripButtonAdjust";
            this.toolStripButtonAdjust.Size = new System.Drawing.Size(45, 51);
            this.toolStripButtonAdjust.Tag = "Adjust";
            this.toolStripButtonAdjust.Text = "Adjust";
            this.toolStripButtonAdjust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAdjust.ToolTipText = "Adjust (A)";
            this.toolStripButtonAdjust.Click += new System.EventHandler(this.toolStripItemMode_Click);
            // 
            // toolStripButtonCrop
            // 
            this.toolStripButtonCrop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCrop.Image")));
            this.toolStripButtonCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCrop.Name = "toolStripButtonCrop";
            this.toolStripButtonCrop.Size = new System.Drawing.Size(37, 51);
            this.toolStripButtonCrop.Tag = "Crop";
            this.toolStripButtonCrop.Text = "Crop";
            this.toolStripButtonCrop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCrop.ToolTipText = "Crop (C)";
            this.toolStripButtonCrop.Click += new System.EventHandler(this.toolStripItemMode_Click);
            // 
            // buttonCropStart
            // 
            this.buttonCropStart.Location = new System.Drawing.Point(21, 19);
            this.buttonCropStart.Name = "buttonCropStart";
            this.buttonCropStart.Size = new System.Drawing.Size(319, 36);
            this.buttonCropStart.TabIndex = 0;
            this.buttonCropStart.Text = "Start Crop";
            this.buttonCropStart.UseVisualStyleBackColor = true;
            this.buttonCropStart.Click += new System.EventHandler(this.buttonCropStart_Click);
            // 
            // buttonCropApply
            // 
            this.buttonCropApply.Enabled = false;
            this.buttonCropApply.Location = new System.Drawing.Point(21, 71);
            this.buttonCropApply.Name = "buttonCropApply";
            this.buttonCropApply.Size = new System.Drawing.Size(319, 36);
            this.buttonCropApply.TabIndex = 1;
            this.buttonCropApply.Text = "Apply Crop";
            this.buttonCropApply.UseVisualStyleBackColor = true;
            this.buttonCropApply.Click += new System.EventHandler(this.buttonCropApply_Click);
            // 
            // buttonCropReject
            // 
            this.buttonCropReject.Enabled = false;
            this.buttonCropReject.Location = new System.Drawing.Point(21, 124);
            this.buttonCropReject.Name = "buttonCropReject";
            this.buttonCropReject.Size = new System.Drawing.Size(319, 36);
            this.buttonCropReject.TabIndex = 2;
            this.buttonCropReject.Text = "Reject Crop";
            this.buttonCropReject.UseVisualStyleBackColor = true;
            this.buttonCropReject.Click += new System.EventHandler(this.buttonCropReject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 835);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Twibox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownContrast)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.toolStripStandard.ResumeLayout(false);
            this.toolStripStandard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ImageControl imageControl;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.NumericUpDown numericUpDownContrast;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStripStandard;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdjust;
        private System.Windows.Forms.ToolStripButton toolStripButtonCrop;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cropToolStripMenuItem;
        private System.Windows.Forms.Button buttonCropStart;
        private System.Windows.Forms.Button buttonCropReject;
        private System.Windows.Forms.Button buttonCropApply;
    }
}

