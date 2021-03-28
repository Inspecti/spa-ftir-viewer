using System;
using System.Collections.Generic;
using System.Linq;

namespace spa_ftir_viewer
{
    public class Spectrum
    {
        public SpaFile spaFile { get; set; }
        public List<float[]> values { get; set; }
        public List<float[]> binnedValues { get; set; }
        public float intensityMax { get; set; }
        public float intensityMin { get; set;  }
        public int count { get; }
        public bool visible { get; set; }
        public float tempYOffset { get; set; } // TODO: this is disgusting
        public float yOffset { get; set; }
        public bool isAbsorbance { get; set; }

        public Spectrum()
        {
            this.spaFile = null;
            this.values = null;
            this.binnedValues = new List<float[]>();
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
            this.binnedValues = new List<float[]>();
            this.intensityMax = (int)GetIntensities().Max();
            this.intensityMin = (int)GetIntensities().Min();
            this.count = values.Count;
            this.visible = true;
            this.tempYOffset = 0;
            this.yOffset = 100-(int)GetIntensities().Max();
            this.isAbsorbance = false;
        }

        // SPECTRUM LOGIC
        public float GetSingleIntensity(float wavenum)
        {
            try
            {
                foreach (float[] vals in values)
                {
                    if ((int)vals[0] == (int)wavenum)
                    {
                        return (float)vals[1];
                    }
                }
                return 0;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                return 0;
            }
        }

        private List<float> GetIntensities()
        {
            List<float> intensities = new List<float>();
            foreach (float[] val in values) intensities.Add(val[1]);
            return intensities;
        }

        public void BinSpectrum(int xWidth)
        {
            this.binnedValues = GetBinnedSpectrum(xWidth);
        }

        // Returns a spectrum that has been reduced to xWidth amount of bins, an easier spectrum to handle in GUI
        public List<float[]> GetBinnedSpectrum(int xWidth)
        {
            List<float[]> binnedSpectrum = new List<float[]>();
            int binSize = (int) Math.Ceiling((float) values.Count / (float) xWidth);

            for (int i = 0; i+binSize < values.Count; i += binSize)
            {
                float binnedWn = 0;
                float binnedInt = 0;

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

                binnedSpectrum.Add(new float[] { binnedWn, binnedInt });
            }
            return binnedSpectrum;
        }

        // TODO: peak picking not done yet
        public List<float[]> GetPeaks()
        {
            return GetPeaks(GetIntensities());
        }

        public List<float[]> GetPeaks(List<float> intensities)
        {
            List<float[]> peakList = new List<float[]>();
            List<float> detected = new List<float>();
            float thresh = (float)0.3;

            for (int i = 0; i + 1 < intensities.Count(); i++)
            {
                if (Math.Abs(intensities[i + 1] - intensities[i]) > thresh)
                {
                    detected.Add(intensities[i + 1]);
                }

                if (detected.Count() > 10)
                {
                    peakList.Add(new float[] { i - 10 + detected.IndexOf(detected.Min()), detected.Min() });
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

        public List<float[]> TranslateSpectrumIntensityType()
        {
            this.binnedValues.Clear();
            if (!isAbsorbance)
            {
                return TransToAbs();
            }
            return AbsToTrans();
        }

        // TODO: something is wrong with the calculation here
        private List<float[]> TransToAbs()
        {
            List<float[]> translatedValues = new List<float[]>();

            foreach (float[] vals in this.values)
            {
                // A = -log(%T)
                float[] absValuePair = { vals[0], 2-(float)Math.Log10(vals[1]) };
                translatedValues.Add(absValuePair);
            }
            this.values = translatedValues;
            this.isAbsorbance = true;
            this.intensityMax = (float)GetIntensities().Max();
            this.intensityMin = (float)GetIntensities().Max();
            return translatedValues;
        }

        private List<float[]> AbsToTrans()
        {
            List<float[]> translatedValues = new List<float[]>();

            foreach (float[] vals in this.values)
            {
                // %T = -10^(A)
                float[] transValuePair = { vals[0], (float)Math.Pow(10, vals[1]) };
                translatedValues.Add(transValuePair);
            }
            this.values = translatedValues;
            this.isAbsorbance = false;
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
