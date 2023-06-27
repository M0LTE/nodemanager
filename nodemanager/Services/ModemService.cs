namespace nodemanager.Services
{
    public interface IModemService
    {
        Task<List<Modem>> GetModems();
    }

    public class LinuxModemService : IModemService
    {
        public Task<List<Modem>> GetModems()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                return Task.FromResult(new List<Modem> { 
                    new Modem { FullPath = Guid.NewGuid().ToString(), TtyAcmName = "one" },
                    new Modem { FullPath = "def", TtyAcmName = "two" } 
                });
            }

            const string dir = "/dev/serial/by-path/";

            var modems = new List<Modem>();

            foreach (var file in Directory.GetFiles(dir))
            {
                var fi = new FileInfo(file);
                if (fi?.LinkTarget != null && fi.LinkTarget.Contains("ttyACM"))
                {
                    modems.Add(new Modem { FullPath = file, TtyAcmName = new FileInfo(fi.LinkTarget).Name });
                }
            }

            return Task.FromResult(modems);
        }
    }

    public record Modem
    {
        public required string FullPath { get; set; }
        public required string TtyAcmName { get; set; }
    }
}
