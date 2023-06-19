#!/bin/bash -e
echo Removing bpqmanager, please wait...
if [[ $(getconf LONG_BIT) == "32" ]]; then suffix=arm; else suffix=arm64; fi
rm -f bpqmanager-$suffix.zip
sudo systemctl stop bpqmanager > /dev/null 2>&1
sudo systemctl disable bpqmanager > /dev/null 2>&1
sudo rm -rf /opt/bpqmanager
sudo rm -f /etc/systemd/system/bpqmanager.service 
sudo systemctl daemon-reload > /dev/null 2>&1
echo All done, bpqmanager is gone.
