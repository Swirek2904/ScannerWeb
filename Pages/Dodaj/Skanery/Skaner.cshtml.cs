using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScannerWeb.Models;

namespace ScannerWeb.Pages.Skanery
{
    public class SkanerModel : PageModel
    {
        public void OnGet()
        {
        }
        public readonly ScannerDbContext db;
        public SkanerModel(ScannerDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(idBudynku.ToString()))
            {
                ModelState.AddModelError("idBudynku", "Wpisz id budynku !");
                
            }
            if (string.IsNullOrWhiteSpace(typAutoryzacji))
            {
                ModelState.AddModelError("typAutoryzacji", "Wpisz typ autoryzacji !");
                
            }
            if (string.IsNullOrWhiteSpace(kodOtwarcia.ToString()))
            {
                ModelState.AddModelError("kodOtwarcia", "Wpisz kod otwarcia !");
               
            }
            if (string.IsNullOrWhiteSpace(poziomDostepu))
            {
                ModelState.AddModelError("poziomDostepu", "Wpisz poziom dostêpu !");
                return Page();
            }
            db.Skaners.Add(new Models.Skaner
            {
                IdBudynku = this.idBudynku,
                TypAutoryzacji = this.typAutoryzacji,
                KodOtwarcia = this.kodOtwarcia,
                PoziomDostepu = this.poziomDostepu
            });
            db.SaveChanges();
            return Page();
        }
       
        
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
