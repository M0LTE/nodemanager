#!/bin/bash -e
echo Removing bpqmanager, please wait...
rm -f bpqmanager.zip
sudo systemctl stop bpqmanager
sudo systemctl disable bpqmanager
sudo rm -rf /opt/bpqmanager
sudo rm /etc/systemd/system/bpqmanager.service
sudo systemctl daemon-reload
echo All done, bpqmanager is gone.
