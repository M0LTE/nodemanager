#!/bin/bash -e
echo Removing bpqmanager, please wait...
rm -f bpqmanager.zip
sudo systemctl stop bpqmanager > /dev/null 2>&1
sudo systemctl disable bpqmanager > /dev/null 2>&1
sudo rm -rf /opt/bpqmanager
sudo rm -f /etc/systemd/system/bpqmanager.service 
sudo systemctl daemon-reload 
echo All done, bpqmanager is gone.
