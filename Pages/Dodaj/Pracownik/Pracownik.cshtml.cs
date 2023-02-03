using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScannerWeb.Models;
using ScannerWeb.Pages.Karty;

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
            var cardNumbers = (from karty in db.Karties
                               where !(from pracownik in db.Pracowniks
                                       select pracownik.IdKarty).Contains(karty.Uid)
                               select karty.Uid).ToList();

            ViewData["IdKarty"] = new SelectList(cardNumbers);

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var cardNumbers = (from karty in db.Karties
                               where !(from pracownik in db.Pracowniks
                                       select pracownik.IdKarty).Contains(karty.Uid)
                               select karty.Uid).ToList();

            bool peselExist = (from pracownik in db.Pracowniks select pracownik.Pesel).Contains(Pracownik.Pesel);

            if (peselExist)
            {
                ModelState.AddModelError("Pracownik.Pesel", "Taki pesel istnieje w bazie!");
                ViewData["IdKarty"] = new SelectList(cardNumbers);
                return Page();
            }
           
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
