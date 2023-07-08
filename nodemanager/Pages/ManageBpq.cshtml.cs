using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nodemanager.Services;

namespace nodemanager.Pages;

public class ManageBpqModel : PageModel
{
    private readonly IBpqStateService bpqStateService;

    public ManageBpqModel(IBpqStateService bpqStateService)
    {
        this.bpqStateService = bpqStateService;
    }

    public Task OnGetAsync()
    {
        return Task.CompletedTask;
    }

    public async Task<IActionResult> OnGetBpqState()
    {
        return new JsonResult(new
        {
            configPresent = await bpqStateService.IsConfigPresent(),
            binaryPresent = await bpqStateService.IsBinaryPresent(),
            serviceInstalled = await bpqStateService.IsBpqServiceInstalled(),
            serviceEnabled = await bpqStateService.IsBpqServiceEnabled(),
            serviceRunning = await bpqStateService.IsBpqServiceRunning()
        });
    }
}
