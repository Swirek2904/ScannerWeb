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
        [BindProperty]
        public Models.Skaner Skaner { get; set; }
        public async Task<IActionResult> OnPostAsync()
        { 
            db.Skaners.Add(new Models.Skaner
            {
                IdBudynku = this.Skaner.IdBudynku,
                TypAutoryzacji = this.Skaner.TypAutoryzacji,
                KodOtwarcia = this.Skaner.KodOtwarcia,
                PoziomDostepu = this.Skaner.PoziomDostepu
            });
            await db.SaveChangesAsync();

            return RedirectToPage("/Success");
        }

    }
}
