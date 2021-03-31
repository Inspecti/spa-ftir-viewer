using System;
using System.Collections.Generic;
using System.Linq;

namespace spa_ftir_viewer
{
    public class Spectrum
    {
        public SpaFile spaFile { get; set; }
        public List<double[]> values { get; set; }
        public List<double[]> binnedValues { get; set; }
        public double intensityMax { get; set; }
        public double intensityMin { get; set;  }
        public int count { get; }
        public bool visible { get; set; }
        public double tempYOffset { get; set; } // TODO: this is disgusting
        public double yOffset { get; set; }
        public bool isAbsorbance { get; set; }

        public Spectrum()
        {
            this.spaFile = null;
            this.values = null;
            this.binnedValues = new List<double[]>();
            this.intensityMax = 0;
            this.intensityMin = 100;
            this.count = 0;
            this.visible = true;
            this.tempYOffset = 0;
            this.yOffset = 0;
            this.isAbsorbance = false;
        }

        public Spectrum(String filePath)
        {
            this.spaFile = new SpaFile(filePath);
            this.values = spaFile.LoadSpectrum();
            this.binnedValues = new List<double[]>();
            this.intensityMax = (int)GetIntensities().Max();
            this.intensityMin = (int)GetIntensities().Min();
            this.count = values.Count;
            this.visible = true;
            this.tempYOffset = 0;
            this.yOffset = 100-(int)GetIntensities().Max();
            this.isAbsorbance = false;
        }

        // SPECTRUM LOGIC
        public double GetSingleIntensity(double wavenum)
        {
            try
            {
                foreach (double[] vals in values)
                {
                    if ((int)vals[0] == (int)wavenum)
                    {
                        return vals[1];
                    }
                }
                return 0;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                return 0;
            }
        }

        private List<double> GetIntensities()
        {
            List<double> intensities = new List<double>();
            foreach (double[] val in values) intensities.Add(val[1]);
            return intensities;
        }

        public void BinSpectrum(int xWidth)
        {
            this.binnedValues = GetBinnedSpectrum(xWidth);
        }

        // Returns a spectrum that has been reduced to xWidth amount of bins, an easier spectrum to handle in GUI
        public List<double[]> GetBinnedSpectrum(int xWidth)
        {
            List<double[]> binnedSpectrum = new List<double[]>();
            int binSize = (int) Math.Ceiling((double) values.Count / xWidth);

            for (int i = 0; i+binSize < values.Count; i += binSize)
            {
                double binnedWn = 0;
                double binnedInt = 0;

                for (int j = 0; j < binSize; j++)
                {
                    binnedWn += values[i + j][0];
                }
                binnedWn /= binSize;

                for (int j = 0; j < binSize; j++)
                {
                    binnedInt += values[i + j][1];
                }
                binnedInt /= binSize;

                binnedSpectrum.Add(new double[] { binnedWn, binnedInt });
            }
            return binnedSpectrum;
        }

        // TODO: peak picking not done yet
        public List<double[]> GetPeaks()
        {
            return GetPeaks(GetIntensities());
        }

        public List<double[]> GetPeaks(List<double> intensities)
        {
            List<double[]> peakList = new List<double[]>();
            List<double> detected = new List<double>();
            double thresh = 0.3;

            for (int i = 0; i + 1 < intensities.Count(); i++)
            {
                if (Math.Abs(intensities[i + 1] - intensities[i]) > thresh)
                {
                    detected.Add(intensities[i + 1]);
                }

                if (detected.Count() > 10)
                {
                    peakList.Add(new double[] { i - 10 + detected.IndexOf(detected.Min()), detected.Min() });
                    detected.Clear();
                }
            }

            return peakList;
        }

        public void ResetYOffset()
        {
            if (!isAbsorbance)
            {
                this.yOffset = 100 - (int)GetIntensities().Max();
            }
            else
            {
                this.yOffset = 0; // TODO: absorbance yoffset
            }
        }

        public List<double[]> TranslateSpectrumIntensityType()
        {
            this.binnedValues.Clear();
            if (!isAbsorbance)
            {
                return TransToAbs();
            }
            return AbsToTrans();
        }

        private List<double[]> TransToAbs()
        {
            List<double[]> translatedValues = new List<double[]>();

            foreach (double[] vals in this.values)
            {
                // A = 2-log(%T)
                double[] absValuePair = { vals[0], 2-Math.Log10(vals[1]) };
                translatedValues.Add(absValuePair);
            }
            this.values = translatedValues;
            this.isAbsorbance = true;
            this.intensityMax = GetIntensities().Max();
            this.intensityMin = GetIntensities().Min();
            return translatedValues;
        }

        private List<double[]> AbsToTrans()
        {
            List<double[]> translatedValues = new List<double[]>();

            foreach (double[] vals in this.values)
            {
                // %T = -10^(A+2)
                double[] transValuePair = { vals[0], Math.Pow(10, -vals[1]+2) };
                translatedValues.Add(transValuePair);
            }
            this.values = translatedValues;
            this.isAbsorbance = false;
            this.intensityMax = GetIntensities().Max();
            this.intensityMin = GetIntensities().Min();
            return translatedValues;
        }

        // GENERAL UTILITIES
        public string GetFilename()
        {
            return spaFile.fileName;
        }

        public override string ToString()
        {
            return String.Join(",", this.GetIntensities().ToArray());
        }
    }
}
