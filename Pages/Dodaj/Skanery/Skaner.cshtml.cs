using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScannerWeb.Pages.Skanery
{
    public class SkanerModel : PageModel
    {
        public void OnGet()
        {
        }
       public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(typAutoryzacji))
            {
                ModelState.AddModelError("typAutoryzacji", "Wpisz typ autoryzacji !");
                return Page();
            }
            if (string.IsNullOrWhiteSpace(poziomDostepu))
            {
                ModelState.AddModelError("poziomDostepu", "Wpisz poziom dostêpu !");
                return Page();
            }
            return Page();
        }
       
        [BindProperty]
        public int idSkanera { get; set; }
        [BindProperty]
        public int idBudynku { get; set; }
        [BindProperty]
        public string? typAutoryzacji { get; set; }
        [BindProperty]
        public int kodOtwarcia { get; set; }
        [BindProperty]
        public string? poziomDostepu { get; set; }

    }
}
