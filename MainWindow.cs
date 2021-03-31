using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace spa_ftir_viewer
{
    public partial class MainWindow : Form
    {
        string windowName = "FTIR spectra viewer";
        List<string> filenames = new List<string>();

        Pen cursorLinePen = new Pen(Color.Red);
        double mouseXloc = 0;
        double mouseYloc = 0;
        bool dragging = false;
        bool absorbanceMode = false;

        int selectedSpectrumIndex = 0;
        public Spectra spectra = new Spectra();

        ToolStripItemCollection specMenu = null;

        List<Color> colorPalette = new List<Color>();

        public MainWindow(string filepath)
        {
            if (filepath != null)
            {
                filenames.Add(filepath);
            }

            this.Text = windowName;

            Color majorGridCol = Color.FromArgb(190, 190, 190);
            Color minorGridCol = Color.FromArgb(235, 235, 235);

            InitializeComponent();
            specGraph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // X-axis
            Axis xAx = specGraph.ChartAreas[0].AxisX;
            
            xAx.MajorGrid.Enabled = true;
            xAx.MajorGrid.LineColor = majorGridCol;
            xAx.MajorGrid.LineWidth = 1;
            xAx.Interval = 1000;
            xAx.IntervalOffset = 600;

            xAx.MinorGrid.Enabled = true;
            xAx.MinorGrid.LineColor = minorGridCol;
            xAx.MinorGrid.LineWidth = 1;
            xAx.MinorGrid.Interval = 100;

            xAx.IntervalAutoMode = 0;
            xAx.IsMarginVisible = true;
            xAx.IsReversed = true;
            xAx.RoundAxisValues();
            xAx.IsMarksNextToAxis = true;

            xAx.Minimum = 400;
            xAx.Maximum = 4000;

            xAx.ScaleView.Zoomable = true;

            // Y-axis
            Axis yAx = specGraph.ChartAreas[0].AxisY;

            yAx.MajorGrid.Enabled = true;
            yAx.MajorGrid.LineColor = majorGridCol;
            yAx.MajorGrid.LineWidth = 1;

            yAx.MinorGrid.Enabled = true;
            yAx.MinorGrid.LineColor = minorGridCol;
            yAx.MinorGrid.LineWidth = 1;

            intensityTitleLabel.Text = "% Transmittance:";

            GenerateColorPalette();
            specMenu = spectraToolStripMenuItem.DropDownItems;
        }

        private void GenerateColorPalette()
        {
            colorPalette.Add(Color.FromArgb(255, 0, 61, 122)); // Dark blue
            colorPalette.Add(Color.FromArgb(255, 188, 27, 27)); // Red
            colorPalette.Add(Color.FromArgb(255, 0, 100, 27)); // Dark green
            colorPalette.Add(Color.FromArgb(255, 43, 111, 214)); // Light blue
            colorPalette.Add(Color.FromArgb(255, 189, 97, 194)); // Magenta
            colorPalette.Add(Color.FromArgb(255, 63, 65, 0)); // Olive
            colorPalette.Add(Color.FromArgb(255, 12, 114, 117)); // Teal
            colorPalette.Add(Color.FromArgb(255, 160, 130, 0)); // Muted Yellow
            colorPalette.Add(Color.FromArgb(255, 194, 70, 0)); // Orange
            colorPalette.Add(Color.FromArgb(255, 69, 29, 158)); // Purple
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
                OpenFile();
        }

        private int OpenFile()
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Nicolet FTIR files (*.spa)|*.spa|All files (*.*)|*.*";
            diag.FilterIndex = 0;
            diag.Multiselect = true;

            if (filenames.Count == 0)
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fn in diag.FileNames) filenames.Add(fn);
                }
                else
                {
                    specGraph.Refresh();
                    return 0;
                }
            }

            if (filenames.Count > 10) filenames.RemoveRange(10, filenames.Count - 10);

            spectra = new Spectra(filenames);
            spectra.ResetYOffsets();

            if (spectra.Count() > 10) spectra.spectrumList.RemoveRange(10, spectra.Count() - 10);
            
            filenames.Clear();

            DrawSpectra();
            SetGraphYScale();

            return 1;
        }

        private int DrawSpectra()
        {
            return DrawSpectra(spectra);
        }

        private int DrawSpectra(Spectra spectra)
        {
            double axYmax = 0;
            double axYmin = 100;

            specGraph.Series.Clear();

            for (int i = 0; i < spectra.Count(); i++)
            {
                Spectrum sp = spectra.GetSpectrum(i);

                if (absorbanceMode && absorbanceMode!= sp.isAbsorbance)
                {
                    sp.TranslateSpectrumIntensityType();
                }

                Series s = new Series();
                s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                s.BorderWidth = 1;
                s.Color = colorPalette[i];

                try
                {
                    if (sp.binnedValues.Count == 0)
                    {
                        sp.BinSpectrum(this.Width);
                    }

                    foreach (double[] binnedValuePair in sp.binnedValues)
                    {
                        s.Points.AddXY(binnedValuePair[0], binnedValuePair[1] + sp.tempYOffset + sp.yOffset);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show("Cannot read", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                s.Enabled = sp.visible;
                specGraph.Series.Add(s);

                AppendToSpectraToolStripMenu(sp, i);
            }

            specGraph.Refresh();
            return 1;
        }

        private void SetGraphYScale()
        {
            if (absorbanceMode)
            {
                specGraph.ChartAreas[0].AxisY.Maximum = spectra.MaximumWithOffsets();
                specGraph.ChartAreas[0].AxisY.Minimum = spectra.MinimumWithOffsets();

                specGraph.ChartAreas[0].AxisY.Interval = 0.1;
                specGraph.ChartAreas[0].AxisY.IntervalOffset = -(spectra.MinimumWithOffsets() % 0.1);
            }
            else 
            {
                specGraph.ChartAreas[0].AxisY.Maximum = spectra.MaximumWithOffsets() + 2;
                specGraph.ChartAreas[0].AxisY.Minimum = spectra.MinimumWithOffsets() - 2;

                specGraph.ChartAreas[0].AxisY.Interval = 10;
                specGraph.ChartAreas[0].AxisY.IntervalOffset = -(spectra.MinimumWithOffsets() - 2) % 10;
            }

        }

        private void AppendToSpectraToolStripMenu(Spectrum sp, int index)
        {
            ToolStripMenuItem specItem = (ToolStripMenuItem)specMenu[index];
            specItem.Text = sp.spaFile.fileName;
            specItem.Enabled = true;
            specItem.ForeColor = colorPalette[index];
            specItem.Checked = sp.visible;
        }

        // MOUSE FUNCTIONALITY
        private void specGraph_MouseMove(object sender, MouseEventArgs e)
        {
            mouseXloc = e.Location.X;
            double mouseChartXLocation = 0;

            if (e.Location.X > 0 && e.Location.X < specGraph.Width)
            {
                mouseChartXLocation = specGraph.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);
            }
                
            if ( mouseChartXLocation > specGraph.ChartAreas[0].AxisX.Minimum && mouseChartXLocation < specGraph.ChartAreas[0].AxisX.Maximum)
            {
                wavenumberValueLine.Text = ((int)mouseChartXLocation).ToString() + " cm ⁻¹";
                wavenumberValueLine.Left = (int)mouseXloc + 5;
                wavenumberValueLabel.Text = ((int)mouseChartXLocation).ToString() + " cm ⁻¹";
                if (selectedSpectrumIndex >= 0)
                {
                    intensityValueLabel.Text = Math.Round(spectra.GetSpectrum(selectedSpectrumIndex).GetSingleIntensity(mouseChartXLocation), 1).ToString() + " %";
                }
            }
            else
            {
                mouseXloc = -1;
                wavenumberValueLabel.Text = "";
                intensityValueLabel.Text = "";
                wavenumberValueLine.Text = "";
            }

            specGraph.Invalidate();

            if (dragging)
            {
                if (e.Location.Y > 0 && specGraph.Height > e.Location.Y)
                {
                    if (selectedSpectrumIndex >= 0)
                    {
                        spectra.GetSpectrum(selectedSpectrumIndex).tempYOffset = ((specGraph.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - specGraph.ChartAreas[0].AxisY.PixelPositionToValue(mouseYloc)));
                    }
                    DrawSpectra();
                }
            }
        }

        private void specGraph_Click(object sender, EventArgs e)
        {
            double mouseYIntensity = specGraph.ChartAreas[0].AxisY.PixelPositionToValue(mouseYloc);
        }

        private void specGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(cursorLinePen, 
                                (float)mouseXloc, (float)specGraph.ChartAreas[0].AxisY.ValueToPixelPosition(specGraph.ChartAreas[0].AxisY.Maximum), 
                                (float)mouseXloc, (float)specGraph.ChartAreas[0].AxisY.ValueToPixelPosition(specGraph.ChartAreas[0].AxisY.Minimum));
        }

        private void specGraph_MouseDown(object sender, MouseEventArgs e)
        {
            mouseXloc = e.Location.X;
            mouseYloc = e.Location.Y;
            SelectClickedSpectrum(specGraph.ChartAreas[0].AxisY.PixelPositionToValue(mouseYloc));
            dragging = true;
        }

        private void specGraph_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            if (selectedSpectrumIndex >= 0)
            {
                spectra.GetSpectrum(selectedSpectrumIndex).yOffset += spectra.GetSpectrum(selectedSpectrumIndex).tempYOffset;
                spectra.GetSpectrum(selectedSpectrumIndex).tempYOffset = 0;
            }
        }

        private void SelectClickedSpectrum(double mouseYIntensity)
        {
            // specGrabDistance = (specGraph.ChartAreas[0].Height / specGraph.ChartAreas[0].AxisY.Maximum)

            for (int i = 0; i < spectra.Count(); i++)
            {
                if (Math.Abs(mouseYIntensity - (spectra.GetSpectrum(i).GetSingleIntensity(specGraph.ChartAreas[0].AxisX.PixelPositionToValue(mouseXloc)) + spectra.GetSpectrum(i).yOffset)) < (spectra.intensityMaxAll - spectra.intensityMinAll)/100)
                {
                    selectedSpectrumIndex = i;
                    selectedSpectrumName.Text = spectra.GetSpectrum(selectedSpectrumIndex).GetFilename();
                    selectedSpectrumName.ForeColor = colorPalette[selectedSpectrumIndex];
                    break;
                }
                else
                {
                    selectedSpectrumIndex = -1;
                }
            }
        }

        // FILE TOOLSTRIP MENU
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void copyEmfToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToClipboard(ChartImageFormat.Emf);
        }

        private void copyPngToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToClipboard(ChartImageFormat.Png);
        }

        private bool copyToClipboard(ChartImageFormat chartImgFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (chartImgFormat == ChartImageFormat.Emf)
                {
                    MessageBox.Show("Not yet implemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                specGraph.SaveImage(ms, chartImgFormat);
                Clipboard.SetImage(System.Drawing.Image.FromStream(ms));
                return true;
            }
        }

        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (spectra.Count() > 0)
            {
                SaveFileDialog diag = new SaveFileDialog();
                diag.Filter = "JPEG image (*.jpg)|*.jpg|Portable Network Graphics image (*.png)|*.png|Tagged Image File Format (*.tif)|*.tif|All files (*.*)|*.*";
                diag.FilterIndex = 0;
                diag.RestoreDirectory = true;

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    saveSpectrumAsImage(diag.FileName);
                }
            }
        }

        private bool saveSpectrumAsImage(string fileName)
        {
            string fileExtension = System.IO.Path.GetExtension(fileName);
            switch (fileExtension) 
            { 
                case ".jpg":
                    specGraph.SaveImage(fileName, ChartImageFormat.Jpeg);
                    return true;
                case ".png": 
                    specGraph.SaveImage(fileName, ChartImageFormat.Png);
                    return true;
                case ".tif": 
                    specGraph.SaveImage(fileName, ChartImageFormat.Tiff);
                    return true;
                default:
                    return false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // SPECTRUM TOOLSTRIP MENU
        private void spectrum1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        private void spectrum10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpectrumToolStripCheckBox((ToolStripMenuItem)sender);
        }

        public void SpectrumToolStripCheckBox(ToolStripMenuItem it)
        {
            if (it.Enabled) it.Checked = !it.Checked;

            int specIdx = specMenu.IndexOf(it);
            spectra.GetSpectrum(specIdx).visible = !spectra.GetSpectrum(specIdx).visible;
            specGraph.Invalidate();
            DrawSpectra();
            SetGraphYScale();
        }

        private void UpdateSpectraToolStripMenuItemsStates()
        {
            for (int i = 0; i < spectra.Count() - 1; i++)
            {
                ToolStripMenuItem specItem = null;
                try
                {
                    specItem = (ToolStripMenuItem)specMenu[i];
                }
                catch (InvalidCastException ex)
                {
                    continue;
                }
                specItem.Enabled = spectra.GetSpectrum(i).visible;
                specItem.Checked = spectra.GetSpectrum(i).visible;
            }
            DrawSpectra();
        }

        private void showAllSpectraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spectra.ShowAll();
            UpdateSpectraToolStripMenuItemsStates();
        }

        private void hideAllSpectraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spectra.HideAll();
            UpdateSpectraToolStripMenuItemsStates();
        }

        private void stackAllSpectraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double offset = (specGraph.ChartAreas[0].AxisY.Maximum - specGraph.ChartAreas[0].AxisY.Minimum) / 30;
            spectra.StackAllSpectra(offset);
            DrawSpectra();
            SetGraphYScale();
        }

        private void resetAllSpectraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spectra.ResetYOffsets();
            DrawSpectra();
            SetGraphYScale();
        }

        private void clearAllSpectraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spectra.Clear();
            selectedSpectrumIndex = -1;
            selectedSpectrumName.Text = "";

            for (int i = 0;  i < 10; i++)
            {
                ToolStripMenuItem specItem = null;
                try
                {
                    specItem = (ToolStripMenuItem)specMenu[i];
                }
                catch(InvalidCastException ex)
                {
                    continue;
                }
                specItem.Text = "Spectrum " + (int)(i + 1);
                specItem.Enabled = false;
                specItem.Checked = false;
            }
            DrawSpectra();
        }

        // VIEW TOOLSTRIP MENU
        private void absorbanceToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            spectra.ToAbsorbance();
            spectra.ResetYOffsets();

            intensityTitleLabel.Text = "Absorbance:";
            absorbanceMode = true;

            DrawSpectra();
            SetGraphYScale();
        }

        private void transmittanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spectra.ToTransmittance();
            spectra.ResetYOffsets();

            intensityTitleLabel.Text = "% Transmittance:";
            absorbanceMode = false;
            
            DrawSpectra();
            SetGraphYScale();
        }

        private void showGridlinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem it = (ToolStripMenuItem)sender;

            it.Checked = !it.Checked;

            specGraph.ChartAreas[0].AxisX.MajorGrid.Enabled = it.Checked;
            specGraph.ChartAreas[0].AxisX.MinorGrid.Enabled = it.Checked;

            specGraph.ChartAreas[0].AxisY.MajorGrid.Enabled = it.Checked;
            specGraph.ChartAreas[0].AxisY.MinorGrid.Enabled = it.Checked;
        }

        // HELP TOOLSTRIP MENU
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // WINDOW BEHAVIOR
        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            spectra.ClearBinnedValues();
            DrawSpectra();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            mouseXloc = -1;
            wavenumberValueLine.Text = "";
        }


    }
}
