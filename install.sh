#!/bin/bash -e
echo Installing nodemanager, please wait...
cd ~
if [[ $(getconf LONG_BIT) == "32" ]]; then suffix=arm; else suffix=arm64; fi
rm -f nodemanager-$suffix.zip
wget -q https://nightly.link/M0LTE/nodemanager/workflows/dotnet/master/nodemanager-$suffix.zip
sudo systemctl stop nodemanager > /dev/null 2>&1
sudo systemctl disable nodemanager > /dev/null 2>&1
sudo rm -rf /opt/nodemanager
sudo mkdir /opt/nodemanager
sudo unzip -q nodemanager-$suffix.zip -d /opt/nodemanager/
rm nodemanager-$suffix.zip
sudo chmod +x /opt/nodemanager/nodemanager
sudo sh -c 'echo "[Unit]
After=network.target
[Service]
ExecStart=/opt/nodemanager/nodemanager --urls http://*:5000
WorkingDirectory=/opt/nodemanager
Restart=always
[Install]
WantedBy=multi-user.target" > /etc/systemd/system/nodemanager.service'
sudo systemctl daemon-reload
sudo systemctl enable nodemanager > /dev/null 2>&1
sudo systemctl start nodemanager
echo All done, please visit http://`hostname`:5000 from another PC on your LAN
