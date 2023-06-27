using SimpleExec;
using System.Diagnostics;
using static SimpleExec.Command;

namespace bpqmanager.Services
{
    public class BpqManagerService
    {
        public async Task Start()
        {
            await RunAsync("systemctl", "start linbpq");
        }

        public async Task Stop()
        {
            await RunAsync("systemctl", "stop linbpq");
        }

        public async Task<string> Status()
        {
            var (standardOutput, _) = await ReadAsync("systemctl", "status linbpq");
            return standardOutput;
        }

        public async Task InstallService()
        {
            const string file = @"[Unit]
After=network.target

[Service]
ExecStart=/opt/linbpq/linbpq
WorkingDirectory=/opt/linbpq
Restart=always

[Install]
WantedBy=multi-user.target";

            await File.WriteAllTextAsync("/etc/systemd/system/linbpq.service", file.Replace("\r\n", "\n"));

            await RunAsync("systemctl", "enable linbpq");
        }

        public async Task Disable()
        {
            await RunAsync("systemctl", "disable linbpq");
        }

        public async Task ReplaceBinaryFromSource()
        {
            var binary = await FetchAndBuildSource();

            const string installDirectory = "/opt/linbpq";

            if (!Directory.Exists(installDirectory))
            {
                Directory.CreateDirectory(installDirectory);
            }

            await File.WriteAllBytesAsync(Path.Combine(installDirectory, "linbpq"), binary);
        }

        public async Task<byte[]> FetchAndBuildSource()
        {
            await RunAsync("apt update && apt install -y -q git build-essential libconfig-dev libssl-dev libminiupnpc-dev libzip-dev libpcap-dev libasound2-dev minicom unzip");

            var buildDir = $"linbpq-src-{DateTime.UtcNow:yyyyMMddHHmmss}";

            Directory.CreateDirectory(buildDir);

            await RunAsync("git", "clone git://vps1.g8bpq.net/linbpq .", workingDirectory: buildDir);

            await RunAsync("make");

            var outputFile = Path.Combine(buildDir, "linbpq");

            var bytes = await File.ReadAllBytesAsync(outputFile);

            Directory.Delete(buildDir, true);

            return bytes;
        }
    }
}
