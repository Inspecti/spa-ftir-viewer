# spa-ftir-viewer
Simple C# GUI application for viewing Thermo Scientific Nicolet FTIR spectrometer files (.spa). Currently tested on files for Nicolet Summit Pro, other spectra could need fiddling with file reading (SpaFile.cs).

## Usage
Set up file association to open up .spa files with the program, or just run the executable. Open new spectrum from `File > Open...`, and clear current spectra with `Spectra > Clear all spectra`. Toggle specific spectra on and off from the `Spectra`-menu.

## Compile instructions
Compile solution with Visual Studio I guess.

## TODO:
* Copying .emf file to clipboard for easy paste to Office apps
* Read peak intensities based on single wn or range
* Spectra names visible as legends
* Additional information extracting from .spa file
* Spectrum peak picking and overlay
* Selecting by clicking
* Zooming and scaling spectrum
* Propose chemical identity based on wavenumber

## Stuff for the future:
* Library reading, overlaying reference spectra
* Library search?
