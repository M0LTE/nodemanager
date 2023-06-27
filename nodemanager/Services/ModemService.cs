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
            //return Task.FromResult(new List<Modem> { new Modem { FullPath = "abc" }, new Modem { FullPath = "def" } });

            const string dir = "/dev/serial/by-path/";

            var modems = new List<Modem>();

            foreach (var file in Directory.GetFiles(dir))
            {
                var fi = new FileInfo(file);
                if (fi?.LinkTarget != null && fi.LinkTarget.Contains("ttyACM"))
                {
                    modems.Add(new Modem { FullPath = file });
                }
            }

            return Task.FromResult(modems);
        }
    }

    public record Modem
    {
        public required string FullPath { get; set; }
    }
}
