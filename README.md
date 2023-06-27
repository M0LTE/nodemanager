# bpqmanager

## Requirements

Tested to date only on Raspberry Pi 4B, both 32 bit and 64 bit Raspberry Pi OS Lite (no desktop).

## Installation

Throughout these instructions, we'll refer to your Raspberry Pi as `packetnode` and your user account on it as `dave` but you can substitute whatever name you want.

Skip to [Install bpqmanager](#install-bpqmanager) if you are experienced and have a fresh Pi prepared with Raspberry Pi OS Lite 64 bit.

### Prepare your Pi

1. Insert fresh micro SD card into reader
1. Download and run Raspberry Pi Imager
1. Under Operating System, choose Raspberry Pi OS Lite (64-bit and 32-bit both supported)
1. Under Storage, choose your micro SD card
1. Click the cog, choose some options:
   1. Tick Set hostname: `packetnode`
   1. Tick Enable SSH, Use Password Authentication
   1. Tick Set username and password, set as you wish, e.g. `dave`, and a strong password
   1. Tick Configure wireless LAN, set as required to connect to your home Wi-Fi
   (or don't, if you will use wired network)
   1. Tick Set locale settings, choose time zone and keyboard layout
   1. Click Save, Write, read and accept the warning.
1. Wait for write and verify to complete, remove micro SD and place in Pi, power it on
1. Wait approximately 3 minutes

### Get a prompt on your Pi

1. From another PC, open a command prompt (on Windows, press Start and type command prompt, press enter)
1. Connect via SSH: type `ssh dave@packetnode`, accept the prompt by typing "yes" and pressing enter. 
1. Enter the password you set earlier.

#### Troubleshooting

If you can't connect, use a keyboard and screen plugged into your Pi, log in using the username and password you set earlier, and type:

```
ifconfig wlan0 | grep inet
```
the output will contain the IP address of your Pi, e.g. 
```
  inet 192.168.0.91  netmask 255.255.255.0  broadcast 192.168.0.255
```
the IP of your Pi is 192.168.0.91, and you should try connecting like `ssh dave@192.168.0.91` instead.

Or, just use a keyboard and screen directly on the Pi from here on in.

### Install bpqmanager

1. On your Pi, copy-paste the following one-liner and press enter to install and start bpqmanager:

hint: paste in a terminal is often single right-click

```
wget -qO - https://raw.githubusercontent.com/M0LTE/bpqmanager/master/install.sh | /bin/bash
```

NB if you prefer to inspect the script, run the same command but omitting `| /bin/bash`.

2. From another PC, open a browser and navigate to http://packetnode:5000

### Remove bpqmanager

If for some reason you want to remove bpqmanager, you can undo all of its installation steps with this one-liner:

```
wget -qO - https://raw.githubusercontent.com/M0LTE/bpqmanager/master/remove.sh | /bin/bash
```
