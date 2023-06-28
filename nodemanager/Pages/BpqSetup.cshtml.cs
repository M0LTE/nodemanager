using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nodemanager.Services;

namespace nodemanager.Pages;

public class BpqSetupModel : PageModel
{
    private readonly IBpqStateService bpqStateService;

    public BpqSetupModel(IBpqStateService bpqStateService)
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
            serviceRunning = await bpqStateService.IsBpqServiceRunning()
        });
    }
}
