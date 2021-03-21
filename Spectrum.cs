using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace spa_ftir_viewer
{
    public class Spectrum
    {
        public SpaFile spaFile { get; set; }
        public List<float[]> values { get; set; }
        public List<float[]> binnedValues { get; set; }
        public int absMax { get; set; }
        public int absMin { get; set; }
        public int count { get; set; }
        public bool visible { get; set; }
        public float tempYOffset { get; set; } // TODO: this is disgusting
        public float yOffset { get; set; }

        public Spectrum()
        {
            this.spaFile = null;
            this.values = null;
            this.binnedValues = new List<float[]>();
            this.absMax = 0;
            this.absMin = 100;
            this.count = 0;
            this.visible = true;
            this.tempYOffset = 0;
            this.yOffset = 0;
        }

        public Spectrum(String filePath)
        {
            this.spaFile = new SpaFile(filePath);
            this.values = spaFile.LoadSpectrum();
            this.binnedValues = new List<float[]>();
            this.absMax = (int)GetAbsorbances().Max();
            this.absMin = (int)GetAbsorbances().Min();
            this.count = values.Count;
            this.visible = true;
            this.tempYOffset = 0;
            this.yOffset = 100-(int)GetAbsorbances().Max();
        }

        // SPECTRUM LOGIC
        public float GetSingleAbsorbance(float wavenum)
        {
            try
            {
                foreach (float[] vals in values)
                {
                    if ((int)vals[1] == (int)wavenum)
                    {
                        return (float)vals[0];
                    }
                }
                return 0;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                return 0; // TODO: should return -1?
            }
        }

        private List<float> GetAbsorbances()
        {
            List<float> absVals = new List<float>();
            foreach (float[] val in values) absVals.Add(val[0]);
            return absVals;
        }

        // Returns a spectrum that has been reduced to xWidth amount of bins, an easier spectrum to handle in GUI
        public List<float[]> GetBinnedSpectrum(int xWidth)
        {
            List<float[]> binnedSpectrum = new List<float[]>();
            int binSize = (int) Math.Ceiling((float) values.Count / (float) xWidth);

            for (int i = 0; i+binSize < values.Count; i += binSize)
            {
                float binnedWn = 0;
                float binnedAbs = 0;

                for (int j = 0; j < binSize; j++)
                {
                    binnedAbs += values[i + j][0];
                }

                for (int j = 0; j < binSize; j++)
                {
                    binnedWn += values[i + j][1];
                }

                float[] binnedVal = { binnedAbs / binSize, binnedWn / binSize };
                binnedSpectrum.Add(binnedVal);
            }

            return binnedSpectrum;
        }

        public List<float[]> GetPeaks()
        {
            return GetPeaks(GetAbsorbances());
        }

        public List<float[]> GetPeaks(List<float> absorbs)
        {
            List<float[]> peakList = new List<float[]>();
            List<float> detected = new List<float>();
            float thresh = (float)0.3;

            for (int i = 0; i + 1 < absorbs.Count(); i++)
            {
                if (Math.Abs(absorbs[i + 1] - absorbs[i]) > thresh)
                {
                    detected.Add(absorbs[i + 1]);
                }

                if (detected.Count() > 10)
                {
                    peakList.Add(new float[] { i - 10 + detected.IndexOf(detected.Min()), detected.Min() });
                    detected.Clear();
                }
            }

            return peakList;
        }

        // GENERAL UTILITIES
        public string GetFilename()
        {
            return spaFile.filePath;
        }

        public override string ToString()
        {
            return String.Join(",", this.GetAbsorbances().ToArray());
        }
    }
}
