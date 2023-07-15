using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nodemanager.Services;

namespace nodemanager.Pages;

public class BpqInstallModel : PageModel
{
    private readonly BpqManagerService bpqManagerService;

    public bool IsInstalling { get; private set; }

    public BpqInstallModel(BpqManagerService bpqManagerService)
    {
        this.bpqManagerService = bpqManagerService;
    }

    public Task OnGetAsync()
    {
        return Task.CompletedTask;
    }

    public async Task<IActionResult> OnPostReleaseBinaryAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        IsInstalling = true;

        return Page();
    }

    public async Task<IActionResult> OnPostBetaBinaryAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await Task.Delay(10000);

        IsInstalling = true;

        return Page();
    }

    public async Task<IActionResult> OnPostFromSourceAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await Task.Delay(10000);

        IsInstalling = true;

        return Page();
    }
}
