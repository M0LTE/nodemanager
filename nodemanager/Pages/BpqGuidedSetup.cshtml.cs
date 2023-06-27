using Microsoft.AspNetCore.Mvc.RazorPages;
using nodemanager.Services;

namespace nodemanager.Pages
{
    public class BpqGuidedSetupModel : PageModel
    {
        private readonly IModemService modemService;

        public List<string>? Modems { get; set; }
        
        public BpqGuidedSetupModel(IModemService modemService)
        {
            this.modemService = modemService;
        }

        public async Task OnGetAsync()
        {
            Modems = (await modemService.GetModems()).Select(m => m.FullPath).ToList();
        }
    }
}
