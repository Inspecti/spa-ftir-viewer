# spa-ftir-viewer
Simple C# GUI application for viewing Thermo Scientific Nicolet FTIR spectrometer files (.spa). Currently tested on files for Nicolet Summit Pro, other spectra could need fiddling with file reading (SpaFile-class).

## Usage
Set up file association to open up .spa files with the program, or just run the executable. Open new spectrum from `File > Open...`, and clear current spectra with `Spectra > Clear all spectra`. Toggle specific spectra on and off from the `Spectra`-menu.

## Compile instructions
Compile solution with Visual Studio I guess.

## TODO:
* Copying .emf file to clipboard
* Saving current view as a .png-file
* Select spectrum by clicking
* Zooming and scaling spectrum
