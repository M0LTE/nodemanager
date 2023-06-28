using Microsoft.AspNetCore.Mvc.RazorPages;

namespace nodemanager.Pages;

public class BpqSetupModel : PageModel
{
    public BpqSetupModel()
    {
    }

    public Task OnGetAsync()
    {
        return Task.CompletedTask;
    }
}
