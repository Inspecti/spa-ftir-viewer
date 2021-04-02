using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<double[]> LoadSpectrum()
        {
            return LoadSpectrum(filePath);
        }

        // Read spectrum from a spa-file, return list with {absorbance, wavenumber} -units
        public List<double[]> LoadSpectrum(String fn) 
        {
            List<double> intensities = new List<double>();
            List<double[]> spectrum = new List<double[]>();

            int intensityStartOffset = 1852;
            int maxWavenumOffset = 1600;
            int totalNumValsOffset = 1588; 
            int totalNumVals = 7468;  // Default value for resolution of 4 cm^-1, will be read from offset 1588 
            float maxWavenum = 0;
            float minWavenum = 0;
            float wavenumStep = 0;

            // TOOD: error handling if file is not the right format

            if (File.Exists(fn))
            {

                // Read total number of intensity entries (list length) from offset 1588
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

                // Read individual intensity values starting from offset 1852
                using (BinaryReader reader = new BinaryReader(File.Open(fn, FileMode.Open)))
                {
                    reader.ReadBytes(intensityStartOffset);

                    for (int i = 0; i < totalNumVals; i++)
                    {
                        double intensity = (double) reader.ReadSingle();
                        intensities.Add(intensity);
                    }

                    reader.Close();
                }

                wavenumStep = (maxWavenum - minWavenum) / intensities.Count();

            }

            foreach (double intensity in intensities)
            {
                double[] vals = { maxWavenum, intensity };
                spectrum.Add(vals);
                maxWavenum = maxWavenum - wavenumStep;
            }

            return spectrum;
        }

        public override string ToString()
        {
            return filePath;
        }
    }
}
