# Wake-On-Lan
A simple application to send magic packets to multiple hosts.

## Usage

### Single device

` wol [address]`

Send magic packet to a single device specified by its MAC address, e.g. `wol 01-23-45-67-89-AB`

### Multiple devices

`wol [address1] [address2]...[addressN]`

Send magic packets to multiple MAC addresses separated by spaces, e.g. `wol 01-23-45-67-89-AB 23-45-67-89-AB-01`

## Address formats

`wol` supports MAC addresses formatted as six groups of two, separated by hyphens e.g. `01-23-45-67-89-AB`. Other supported separators are colons and dots.

Addresses formatted as three groups of four (e.g.` 0123.4567.89AB`) are also supported, again using hyphens, colons or dots as separators.

Addresses with no separators are also supported, e.g. `0123456789AB`.

Due to spaces being used to define multiple addresses when waking more than one device, spaces are not supported as separators within a MAC address. Formatting an address as `01 23 45 67 89 AB` or similar will be interpreted as six separate invalid target devices.

## Credits and thankyous.

The icon for this project was provided by http://www.visualpharm.com/, licensed CC BY-ND 3.0.
