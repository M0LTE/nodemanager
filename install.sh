#!/bin/bash -e
echo Installing bpqmanager, please wait...
if [[ $(getconf LONG_BIT) == "32" ]]; then suffix=arm; else suffix=arm64; fi
rm -f bpqmanager-$suffix.zip
wget -q https://nightly.link/M0LTE/bpqmanager/workflows/dotnet/master/bpqmanager-$suffix.zip
sudo systemctl stop bpqmanager > /dev/null 2>&1
sudo systemctl disable bpqmanager > /dev/null 2>&1
sudo rm -rf /opt/bpqmanager
sudo mkdir /opt/bpqmanager
sudo unzip -q bpqmanager-$suffix.zip -d /opt/bpqmanager/
rm bpqmanager-$suffix.zip
sudo chmod +x /opt/bpqmanager/bpqmanager
sudo sh -c 'echo "[Unit]
After=network.target
[Service]
ExecStart=/opt/bpqmanager/bpqmanager --urls http://*:5000
WorkingDirectory=/opt/bpqmanager
Restart=always
[Install]
WantedBy=multi-user.target" > /etc/systemd/system/bpqmanager.service'
sudo systemctl daemon-reload
sudo systemctl enable bpqmanager > /dev/null 2>&1
sudo systemctl start bpqmanager
echo All done, please visit http://`hostname`:5000 from another PC on your LAN
