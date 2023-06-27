#!/bin/bash -e
echo Removing nodemanager, please wait...
cd ~
if [[ $(getconf LONG_BIT) == "32" ]]; then suffix=arm; else suffix=arm64; fi
rm -f nodemanager-$suffix.zip
sudo systemctl stop nodemanager > /dev/null 2>&1
sudo systemctl disable nodemanager > /dev/null 2>&1
sudo rm -rf /opt/nodemanager
sudo rm -f /etc/systemd/system/nodemanager.service 
sudo systemctl daemon-reload > /dev/null 2>&1
echo All done, nodemanager is gone.
