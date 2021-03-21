namespace spa_ftir_viewer
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.specGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Label_waveNumberMouse = new System.Windows.Forms.Label();
            this.Label_absorbanceMouse = new System.Windows.Forms.Label();
            this.Label_wavenumberLine = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrum10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllSpectraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllSpectraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllSpectraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absorbanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transmittanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showGridlinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.specGraph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // specGraph
            // 
            this.specGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.specGraph.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.specGraph.Legends.Add(legend1);
            this.specGraph.Location = new System.Drawing.Point(0, 27);
            this.specGraph.Name = "specGraph";
            this.specGraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.specGraph.Series.Add(series1);
            this.specGraph.Size = new System.Drawing.Size(1640, 864);
            this.specGraph.TabIndex = 2;
            this.specGraph.Text = "chart1";
            this.specGraph.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            this.specGraph.Click += new System.EventHandler(this.specGraph_Click);
            this.specGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.specGraph_Paint);
            this.specGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.specGraph_MouseDown);
            this.specGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.specGraph_MouseMove);
            this.specGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.specGraph_MouseUp);
            // 
            // Label_waveNumberMouse
            // 
            this.Label_waveNumberMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_waveNumberMouse.AutoSize = true;
            this.Label_waveNumberMouse.BackColor = System.Drawing.Color.White;
            this.Label_waveNumberMouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_waveNumberMouse.ForeColor = System.Drawing.Color.Red;
            this.Label_waveNumberMouse.Location = new System.Drawing.Point(21, 863);
            this.Label_waveNumberMouse.Name = "Label_waveNumberMouse";
            this.Label_waveNumberMouse.Size = new System.Drawing.Size(107, 20);
            this.Label_waveNumberMouse.TabIndex = 4;
            this.Label_waveNumberMouse.Text = "Wavenumber:";
            // 
            // Label_absorbanceMouse
            // 
            this.Label_absorbanceMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_absorbanceMouse.AutoSize = true;
            this.Label_absorbanceMouse.BackColor = System.Drawing.Color.White;
            this.Label_absorbanceMouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_absorbanceMouse.ForeColor = System.Drawing.Color.Red;
            this.Label_absorbanceMouse.Location = new System.Drawing.Point(21, 883);
            this.Label_absorbanceMouse.Name = "Label_absorbanceMouse";
            this.Label_absorbanceMouse.Size = new System.Drawing.Size(99, 20);
            this.Label_absorbanceMouse.TabIndex = 5;
            this.Label_absorbanceMouse.Text = "Absorbance:";
            // 
            // Label_wavenumberLine
            // 
            this.Label_wavenumberLine.AutoSize = true;
            this.Label_wavenumberLine.BackColor = System.Drawing.Color.White;
            this.Label_wavenumberLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Label_wavenumberLine.ForeColor = System.Drawing.Color.Red;
            this.Label_wavenumberLine.Location = new System.Drawing.Point(114, 27);
            this.Label_wavenumberLine.Name = "Label_wavenumberLine";
            this.Label_wavenumberLine.Size = new System.Drawing.Size(15, 16);
            this.Label_wavenumberLine.TabIndex = 6;
            this.Label_wavenumberLine.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.spectraToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1640, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // spectraToolStripMenuItem
            // 
            this.spectraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spectrum1ToolStripMenuItem,
            this.spectrum2ToolStripMenuItem,
            this.spectrum3ToolStripMenuItem,
            this.spectrum4ToolStripMenuItem,
            this.spectrum5ToolStripMenuItem,
            this.spectrum6ToolStripMenuItem,
            this.spectrum7ToolStripMenuItem,
            this.spectrum8ToolStripMenuItem,
            this.spectrum9ToolStripMenuItem,
            this.spectrum10ToolStripMenuItem,
            this.toolStripSeparator1,
            this.showAllSpectraToolStripMenuItem,
            this.hideAllSpectraToolStripMenuItem,
            this.toolStripSeparator3,
            this.clearAllSpectraToolStripMenuItem});
            this.spectraToolStripMenuItem.Name = "spectraToolStripMenuItem";
            this.spectraToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.spectraToolStripMenuItem.Text = "Spectra";
            // 
            // spectrum1ToolStripMenuItem
            // 
            this.spectrum1ToolStripMenuItem.Enabled = false;
            this.spectrum1ToolStripMenuItem.Name = "spectrum1ToolStripMenuItem";
            this.spectrum1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum1ToolStripMenuItem.Text = "Spectrum 1";
            this.spectrum1ToolStripMenuItem.Click += new System.EventHandler(this.spectrum1ToolStripMenuItem_Click);
            // 
            // spectrum2ToolStripMenuItem
            // 
            this.spectrum2ToolStripMenuItem.Enabled = false;
            this.spectrum2ToolStripMenuItem.Name = "spectrum2ToolStripMenuItem";
            this.spectrum2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum2ToolStripMenuItem.Text = "Spectrum 2";
            this.spectrum2ToolStripMenuItem.Click += new System.EventHandler(this.spectrum2ToolStripMenuItem_Click);
            // 
            // spectrum3ToolStripMenuItem
            // 
            this.spectrum3ToolStripMenuItem.Enabled = false;
            this.spectrum3ToolStripMenuItem.Name = "spectrum3ToolStripMenuItem";
            this.spectrum3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum3ToolStripMenuItem.Text = "Spectrum 3";
            this.spectrum3ToolStripMenuItem.Click += new System.EventHandler(this.spectrum3ToolStripMenuItem_Click);
            // 
            // spectrum4ToolStripMenuItem
            // 
            this.spectrum4ToolStripMenuItem.Enabled = false;
            this.spectrum4ToolStripMenuItem.Name = "spectrum4ToolStripMenuItem";
            this.spectrum4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum4ToolStripMenuItem.Text = "Spectrum 4";
            this.spectrum4ToolStripMenuItem.Click += new System.EventHandler(this.spectrum4ToolStripMenuItem_Click);
            // 
            // spectrum5ToolStripMenuItem
            // 
            this.spectrum5ToolStripMenuItem.Enabled = false;
            this.spectrum5ToolStripMenuItem.Name = "spectrum5ToolStripMenuItem";
            this.spectrum5ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum5ToolStripMenuItem.Text = "Spectrum 5";
            this.spectrum5ToolStripMenuItem.Click += new System.EventHandler(this.spectrum5ToolStripMenuItem_Click);
            // 
            // spectrum6ToolStripMenuItem
            // 
            this.spectrum6ToolStripMenuItem.Enabled = false;
            this.spectrum6ToolStripMenuItem.Name = "spectrum6ToolStripMenuItem";
            this.spectrum6ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum6ToolStripMenuItem.Text = "Spectrum 6";
            this.spectrum6ToolStripMenuItem.Click += new System.EventHandler(this.spectrum6ToolStripMenuItem_Click);
            // 
            // spectrum7ToolStripMenuItem
            // 
            this.spectrum7ToolStripMenuItem.Enabled = false;
            this.spectrum7ToolStripMenuItem.Name = "spectrum7ToolStripMenuItem";
            this.spectrum7ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum7ToolStripMenuItem.Text = "Spectrum 7";
            this.spectrum7ToolStripMenuItem.Click += new System.EventHandler(this.spectrum7ToolStripMenuItem_Click);
            // 
            // spectrum8ToolStripMenuItem
            // 
            this.spectrum8ToolStripMenuItem.Enabled = false;
            this.spectrum8ToolStripMenuItem.Name = "spectrum8ToolStripMenuItem";
            this.spectrum8ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum8ToolStripMenuItem.Text = "Spectrum 8";
            this.spectrum8ToolStripMenuItem.Click += new System.EventHandler(this.spectrum8ToolStripMenuItem_Click);
            // 
            // spectrum9ToolStripMenuItem
            // 
            this.spectrum9ToolStripMenuItem.Enabled = false;
            this.spectrum9ToolStripMenuItem.Name = "spectrum9ToolStripMenuItem";
            this.spectrum9ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum9ToolStripMenuItem.Text = "Spectrum 9";
            this.spectrum9ToolStripMenuItem.Click += new System.EventHandler(this.spectrum9ToolStripMenuItem_Click);
            // 
            // spectrum10ToolStripMenuItem
            // 
            this.spectrum10ToolStripMenuItem.Enabled = false;
            this.spectrum10ToolStripMenuItem.Name = "spectrum10ToolStripMenuItem";
            this.spectrum10ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spectrum10ToolStripMenuItem.Text = "Spectrum 10";
            this.spectrum10ToolStripMenuItem.Click += new System.EventHandler(this.spectrum10ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // showAllSpectraToolStripMenuItem
            // 
            this.showAllSpectraToolStripMenuItem.Name = "showAllSpectraToolStripMenuItem";
            this.showAllSpectraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showAllSpectraToolStripMenuItem.Text = "Show all spectra";
            this.showAllSpectraToolStripMenuItem.Click += new System.EventHandler(this.showAllSpectraToolStripMenuItem_Click);
            // 
            // hideAllSpectraToolStripMenuItem
            // 
            this.hideAllSpectraToolStripMenuItem.Name = "hideAllSpectraToolStripMenuItem";
            this.hideAllSpectraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideAllSpectraToolStripMenuItem.Text = "Hide all spectra";
            this.hideAllSpectraToolStripMenuItem.Click += new System.EventHandler(this.hideAllSpectraToolStripMenuItem_Click);
            // 
            // clearAllSpectraToolStripMenuItem
            // 
            this.clearAllSpectraToolStripMenuItem.Name = "clearAllSpectraToolStripMenuItem";
            this.clearAllSpectraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearAllSpectraToolStripMenuItem.Text = "Clear all spectra";
            this.clearAllSpectraToolStripMenuItem.Click += new System.EventHandler(this.clearAllSpectraToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.absorbanceToolStripMenuItem,
            this.transmittanceToolStripMenuItem,
            this.toolStripSeparator2,
            this.showGridlinesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // absorbanceToolStripMenuItem
            // 
            this.absorbanceToolStripMenuItem.Name = "absorbanceToolStripMenuItem";
            this.absorbanceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.absorbanceToolStripMenuItem.Text = "Absorbance";
            this.absorbanceToolStripMenuItem.Click += new System.EventHandler(this.absorbanceToolStripMenuItem_Click);
            // 
            // transmittanceToolStripMenuItem
            // 
            this.transmittanceToolStripMenuItem.Name = "transmittanceToolStripMenuItem";
            this.transmittanceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.transmittanceToolStripMenuItem.Text = "Transmittance";
            this.transmittanceToolStripMenuItem.Click += new System.EventHandler(this.transmittanceToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // showGridlinesToolStripMenuItem
            // 
            this.showGridlinesToolStripMenuItem.Checked = true;
            this.showGridlinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridlinesToolStripMenuItem.Name = "showGridlinesToolStripMenuItem";
            this.showGridlinesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showGridlinesToolStripMenuItem.Text = "Show gridlines";
            this.showGridlinesToolStripMenuItem.Click += new System.EventHandler(this.showGridlinesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1640, 919);
            this.Controls.Add(this.Label_wavenumberLine);
            this.Controls.Add(this.Label_absorbanceMouse);
            this.Controls.Add(this.Label_waveNumberMouse);
            this.Controls.Add(this.specGraph);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.specGraph)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart specGraph;
        private System.Windows.Forms.Label Label_waveNumberMouse;
        private System.Windows.Forms.Label Label_absorbanceMouse;
        private System.Windows.Forms.Label Label_wavenumberLine;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllSpectraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem spectrum6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spectrum10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllSpectraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAllSpectraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absorbanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transmittanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showGridlinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

