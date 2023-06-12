#!/bin/bash -e
echo Installing bpqmanager, please wait...
wget -q https://nightly.link/M0LTE/bpqmanager/workflows/dotnet/master/bpqmanager.zip
sudo systemctl stop bpqmanager > /dev/null
sudo rm -rf /opt/bpqmanager
sudo mkdir /opt/bpqmanager
sudo unzip -q bpqmanager.zip -d /opt/bpqmanager/
rm bpqmanager.zip
sudo chmod +x /opt/bpqmanager/bpqmanager
sudo sh -c 'echo "[Unit]
After=network.target
[Service]
ExecStart=/opt/bpqmanager/bpqmanager --urls http://*:5000
WorkingDirectory=/opt/bpqmanager
Restart=always
[Install]
WantedBy=multi-user.target" > /etc/systemd/system/bpqmanager.service'
sudo systemctl enable bpqmanager > /dev/null
sudo systemctl start bpqmanager
echo All done, please visit http://`hostname`:5000 from another PC on your LAN
