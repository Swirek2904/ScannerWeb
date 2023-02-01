using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScannerWeb.Models;

namespace ScannerWeb.Pages.Karty
{
    public class KartyModel : PageModel
    {
        public void OnGet()
        {
        }
        public readonly ScannerDbContext db;
        public KartyModel(ScannerDbContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Models.Karty Karty{ get; set; }
        public async Task<IActionResult> OnPostAsync()
        { 
            db.Karties.Add(new Models.Karty
            {
                Uid = this.Karty.Uid,
                KodOtwarcia = this.Karty.KodOtwarcia
            });
            await db.SaveChangesAsync();

            return RedirectToPage("/Success");
        }

    }
}
