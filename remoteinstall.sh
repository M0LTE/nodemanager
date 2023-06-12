#!/bin/bash -e

wget -q https://nightly.link/M0LTE/bpqmanager/workflows/dotnet/master/bpqmanager.zip
sudo mkdir /opt/bpqmanager
sudo unzip bpqmanager.zip -d /opt/bpqmanager/
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
sudo systemctl enable bpqmanager
sudo systemctl start bpqmanager
