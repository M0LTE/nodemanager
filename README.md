# bpqmanager

## Installation

Throughout these instructions, we'll refer to your Raspberry Pi as `mypi` and your user account on it as `dave` but you can substitute whatever name you want.

Skip to [Install bpqmanager](#install-bpqmanager) if you are experienced and have a fresh Pi prepared with Raspberry Pi OS Lite 64 bit.

### Prepare your Pi

1. Insert fresh micro SD card into reader
1. Download and run Raspberry Pi Imager
1. Choose Raspberry Pi OS Lite (64-bit)
1. Choose your micro SD card
1. Click the cog, choose some options:
  1. Set hostname: `mypi`
  1. Tick enable SSH, Use Password Authentication
  1. Tick Set username and password, set as you wish, e.g. `dave`
  1. Tick Configure wireless LAN, set as required to connect to your home Wi-Fi
  (or don't, if you will use wired network)
  1. Tick Set locale settings, choose time zone and keyboard layout
  1. Click Save, Write, read and accept the warning.
1. Wait for write and verify to complete, remove micro SD and place in Pi, power it on
1. Wait approximately 3 minutes

### Get a prompt on your Pi

1. From another PC, open a command prompt (on Windows, press Start and type command prompt, press enter)
1. Connect via SSH: type `ssh dave@mypi`, accept the prompt by typing "yes" and pressing enter. 
1. Enter the password you set earlier.

Or, use a keyboard and screen.

### Install bpqmanager

Copy-paste the following one-liner to install bpqmanager:

```
wget -qO - https://raw.githubusercontent.com/M0LTE/bpqmanager/master/remoteinstall.sh | /bin/bash
```

NB if you prefer to inspect the script, run the same command but omitting `| /bin/bash`.

From another PC, open a browser and navigate to http://mypi:5000
