using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spa_ftir_viewer
{
    public class Spectra
    {
        public List<Spectrum> spectrumList { get; set; }
        public double intensityMinAll { get; set; }
        public double intensityMaxAll { get; set; }
        public bool areAbsorbance { get; set; }

        public Spectra()
        {
            spectrumList = new List<Spectrum>();
            intensityMinAll = 0;
            intensityMaxAll = 0;
            areAbsorbance = false;
        }

        public Spectra(List<string> filenames)
        {
            spectrumList = new List<Spectrum>();
            LoadFromFilenames(filenames);

            intensityMinAll = Minimum();
            intensityMaxAll = Maximum();
            areAbsorbance = false;
        }

        public void LoadFromFilenames(List<string> filenames)
        {
            foreach (string fn in filenames)
            {
                spectrumList.Add(new Spectrum(fn));
            }
        }

        public Spectrum GetSpectrum(int index)
        {
            return spectrumList[index];
        }

        private double Minimum()
        {
            if (spectrumList.Count == 0) return 0;
            double min = spectrumList[0].intensityMin;
            foreach (Spectrum sp in spectrumList)
            {
                if (min > sp.intensityMin) min = sp.intensityMin;
            }
            return min;
        }

        private double Maximum()
        {
            if (spectrumList.Count == 0) return 0;
            double max = spectrumList[0].intensityMax;
            foreach (Spectrum sp in spectrumList)
            {
                if (max < sp.intensityMax) max = sp.intensityMax;
            }
            return max;
        }

        public double MinimumWithOffsets()
        {
            if (!spectrumList.Any()) return 0;
            double min = spectrumList[0].intensityMin + spectrumList[0].yOffset;
            foreach (Spectrum sp in spectrumList)
            {
                if (min > sp.intensityMin + sp.yOffset) min = sp.intensityMin + sp.yOffset;
            }
            return min;
        }

        public double MaximumWithOffsets()
        {
            if (!spectrumList.Any()) return 0;
            double max = spectrumList[0].intensityMax + spectrumList[0].yOffset;
            foreach (Spectrum sp in spectrumList)
            {
                if (max < sp.intensityMax + sp.yOffset) max = sp.intensityMax + sp.yOffset;
            }
            return max;
        }

        public void ToAbsorbance()
        {
            foreach (Spectrum sp in spectrumList)
            {
                if (!sp.isAbsorbance) sp.TranslateSpectrumIntensityType();
            }
            this.intensityMinAll = Minimum();
            this.intensityMaxAll = Maximum();
        }

        public void ToTransmittance()
        {
            foreach (Spectrum sp in spectrumList)
            {
                if (sp.isAbsorbance) sp.TranslateSpectrumIntensityType();
            }
            this.intensityMinAll = Minimum();
            this.intensityMaxAll = Maximum();
        }

        public void ClearBinnedValues()
        {
            foreach (Spectrum sp in spectrumList)
            {
                sp.binnedValues.Clear();
            }
        }

        public void ResetYOffsets()
        {
            foreach (Spectrum sp in spectrumList)
            {
                sp.ResetYOffset();
            }
        }

        public void StackAllSpectra(double offset)
        {
            ResetYOffsets();
            double singleoffset = 0;
            foreach (Spectrum sp in spectrumList)
            {
                sp.yOffset -= singleoffset;
                singleoffset += offset;
            }
        }

        public void ShowAll()
        {
            foreach (Spectrum sp in spectrumList)
            {
                sp.visible = true;
                Console.WriteLine(sp);
            }
        }

        public void HideAll()
        {
            foreach (Spectrum sp in spectrumList)
            {
                sp.visible = false;
            }
        }

        public int Count()
        {
            return spectrumList.Count;
        }

        public void Clear()
        {
            spectrumList.Clear();
            intensityMinAll = 0;
            intensityMaxAll = 0;
            areAbsorbance = false;
        }

    }
}
