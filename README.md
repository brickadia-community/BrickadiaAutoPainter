# BrickadiaAutoPainter

This is an automatic painter for Brickadia. Simply give it a color palette file (`.bp`), an image, specify dimensions and corners,
and it will automatically paint the image for you.

Only supports Windows.

## Installation

Head to the [releases page](https://github.com/brickadia-community/BrickadiaAutoPainter/releases) and download the latest executable.
Instructions included in the program.

### Getting the palette

#### For server admins/owners

Navigate to the server settings (ESC -> Edit Game) and click Advanced Settings on top. Click Edit Server Color Palette, then Presets in the top right.
Click Save New Preset and give it a name. Finally, tab out of Brickadia, press `winkey + R` to open the Run menu, and enter the following:

`%localappdata%\brickadia\saved\presets\colorpalettes`

This will open a File Explorer window in your color palette directory. Find the palette you just saved (ending in `.bp`) and copy it somewhere else for use
with the Auto Painter, or navigate to the same folder with the Auto Painter.

#### For other users

If you are not a server admin/owner, you can get the palette by using [cake's palette tool](https://palette.brickadia.dev).
Simply take a screenshot of the palette in-game, paste it into the tool, and re-create the palette by first dragging down,
using mouse wheel to control number of rows, then right clicking, moving to last column, and scrolling again to re-create
the palette. From here, you can click download preset. The downloaded file can be used with the autopainter.
