using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScannerWeb.Models;

namespace ScannerWeb.Pages.Dodaj
{
    public class PracownikModel : PageModel
    {
        private readonly ScannerWeb.Models.ScannerDbContext db;

        public PracownikModel(ScannerWeb.Models.ScannerDbContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Models.Pracownik Pracownik { get; set; }

        public IActionResult OnGet()
        {
            ViewData["IdKarty"] = new SelectList(db.Karties, "Uid", "Uid");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
                 
            db.Pracowniks.Add(new Models.Pracownik
            {
                Imie = this.Pracownik.Imie,
                Nazwisko = this.Pracownik.Nazwisko,
                Pesel = this.Pracownik.Pesel, 
                NumerTelefonu = this.Pracownik.NumerTelefonu,
                IdKarty = this.Pracownik.IdKarty,
                PoziomDostepu = this.Pracownik.PoziomDostepu
            });
            await db.SaveChangesAsync();
            
            return RedirectToPage("/Success");
            
        }
    }
}
