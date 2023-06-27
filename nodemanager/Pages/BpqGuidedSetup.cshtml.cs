using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nodemanager.Services;

namespace nodemanager.Pages
{
    public class BpqGuidedSetupModel : PageModel
    {
        private readonly IModemService modemService;

        //public List<Modem>? Modems { get; set; }
        
        public BpqGuidedSetupModel(IModemService modemService)
        {
            this.modemService = modemService;
        }

        public async Task OnGetAsync()
        {
            //Modems = (await modemService.GetModems()).ToList();
        }

        public async Task<IActionResult> OnGetModems()
        {
            return new JsonResult((await modemService.GetModems()).ToList());
        }
    }
}
