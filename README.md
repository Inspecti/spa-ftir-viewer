# spa-ftir-viewer
Simple C# GUI application for viewing Thermo Scientific Nicolet FTIR spectrometer files (.spa). Currently tested on files for Nicolet Summit Pro, other spectra could need fiddling with file reading (SpaFile.cs).

## Usage
Set up file association to open up .spa files with the program, or just run the executable. Open new spectra from `File > Open...`, and clear current spectra with `Spectra > Clear all spectra`. Toggle specific spectra on and off from the `Spectra`-menu.

## Compile instructions
Compile solution with Visual Studio I guess.

## TODO:
* Read peak intensities based on single wn or range
* Keyboard shortcuts for hiding, offsetting and resetting
* Additional information extracting from .spa file
* Peak picking and overlay
* Zoom and scale
* Propose vibration based on wavenumber

## Stuff for the future:
* Functions tab
* Library reading, overlaying reference spectra
* Library search?