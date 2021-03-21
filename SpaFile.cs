using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace spa_ftir_viewer
{
    public class SpaFile
    {
        public string filePath { get; set; }

        public string fileName { get; set; }

        public SpaFile()
        {
            filePath = "";
            fileName = "";
        }

        public SpaFile(String spaPath)
        {
            filePath = spaPath;
            fileName = (string)System.IO.Path.GetFileName(spaPath);
        }

        public List<float[]> LoadSpectrum()
        {
            return LoadSpectrum(filePath);
        }

        // Read spectrum from a spa-file, return list with {absorbance, wavenumber} -units
        public List<float[]> LoadSpectrum(String fn) 
        {
            List<float> absList = new List<float>();
            List<float[]> spec = new List<float[]>();

            int absStartOffset = 1852;
            int maxWavenumOffset = 1600;
            int totalNumValsOffset = 1588;
            int totalNumVals = 7468; // TODO: check if spectrometer resolution is read correctly from offset 1588? 
            float maxWavenum = 0;
            float minWavenum = 0;
            float wavenumStep = 0;

            // TOOD: error handling if file is not the right format?

            if (File.Exists(fn))
            {

                // Read total number of absorbance entries (array length) from offset 1588
                using (BinaryReader reader = new BinaryReader(File.Open(fn, FileMode.Open)))
                {
                    reader.ReadBytes(totalNumValsOffset);
                    totalNumVals = (int)reader.ReadUInt16();
                    reader.Close();
                }

                // Read minimum and maximum wavenumbers (wavenumber range) from offset 1600
                using (BinaryReader reader = new BinaryReader(File.Open(fn, FileMode.Open)))
                {
                    reader.ReadBytes(maxWavenumOffset);
                    maxWavenum = reader.ReadSingle();
                    minWavenum = reader.ReadSingle();
                    reader.Close();
                }

                // Read individual absorbance values starting from offset 1852
                using (BinaryReader reader = new BinaryReader(File.Open(fn, FileMode.Open)))
                {
                    reader.ReadBytes(absStartOffset);

                    for (int i = 0; i < totalNumVals; i++)
                    {
                        float absorbance = reader.ReadSingle();
                        absList.Add(absorbance);
                    }

                    reader.Close();
                }

                wavenumStep = (maxWavenum - minWavenum) / absList.Count();
            }

            foreach (float absorbance in absList)
            {
                float[] vals = { absorbance, maxWavenum };
                spec.Add(vals);
                maxWavenum = maxWavenum - wavenumStep;
            }

            return spec;
        }

        public override string ToString()
        {
            return filePath;
        }
    }
}
