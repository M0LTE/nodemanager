using SimpleExec;
using static SimpleExec.Command;

namespace nodemanager.Services;

public interface IBpqStateService
{
    Task<bool> IsBinaryPresent();
    Task<bool> IsBpqServiceInstalled();
    Task<bool> IsBpqServiceEnabled ();
    Task<bool> IsBpqServiceRunning();
    Task<bool> IsConfigPresent();
}

public class DevBpqStateService : IBpqStateService
{
    private static Random random = new();
    public Task<bool> IsBinaryPresent()
    {
        return Task.FromResult(random.NextDouble() < 0.5);
    }

    public Task<bool> IsBpqServiceInstalled()
    {
        return Task.FromResult(true);
    }
    public Task<bool> IsBpqServiceEnabled()
    {
        return Task.FromResult(true);
    }

    public Task<bool> IsBpqServiceRunning()
    {
        return Task.FromResult(false);
    }

    public Task<bool> IsConfigPresent()
    {
        return Task.FromResult(true);
    }
}

public class LinuxBpqStateService : IBpqStateService
{
    public Task<bool> IsBinaryPresent()
    {
        return Task.FromResult(File.Exists("/opt/linbpq/linbpq"));
    }

    public async Task<bool> IsBpqServiceRunning()
    {
        try
        {
            await RunAsync("systemctl", "status linbpq");
            return true;
        }
        catch (ExitCodeException)
        {
            return false;
        }
    }

    public async Task<bool> IsBpqServiceEnabled()
    {
        try
        {
            var (stdout, stderr) = await ReadAsync("systemctl", "status linbpq");
            return stdout.Contains("linbpq.service; enabled;");
        }
        catch (ExitCodeReadException ex)
        {
            if (ex.ExitCode == 3 && ex.StandardOutput.Contains("linbpq.service; enabled;"))
            {
                return true;
            }

            return false;
        }
    }

    public async Task<bool> IsBpqServiceInstalled()
    {
        try
        {
            await RunAsync("systemctl", "status linbpq");
            return true;
        }
        catch (ExitCodeException ex)
        {
            if (ex.ExitCode == 3)
            {
                return true;
            }

            return false;
        }
    }

    public Task<bool> IsConfigPresent()
    {
        return Task.FromResult(File.Exists("/etc/bpq32.cfg"));
    }
}
