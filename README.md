* Insert fresh micro SD card into reader
* Download and run Raspberry Pi Imager
* Choose Raspberry Pi OS Lite (64-bit)
* Choose your micro SD card
* Click the cog, choose some options:
** Set hostname: your choice
** Tick enable SSH, Use Password Authentication
** Tick Set username and password, set as you wish
** Tick Configure wireless LAN, set as required
  (or don't, if you will use wired network)
** Tick Set locale settings, choose time zone and keyboard layout
** Click Save, Write, read and accept the warning.
* Wait for write and verify to complete, remove micro SD and place in Pi, power it on
* Wait approximately 3 minutes
* Open command prompt, type `ssh usernameyouchose@hostnameyouchose`, accept the prompt by typing "yes" and pressing enter
* Type: `wget -qO - https://raw.githubusercontent.com/M0LTE/bpqmanager/master/remoteinstall.sh | /bin/bash`
