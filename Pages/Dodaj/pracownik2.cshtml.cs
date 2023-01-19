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
    public class pracownik2Model : PageModel
    {
        private readonly ScannerWeb.Models.ScannerDbContext db;

        public pracownik2Model(ScannerWeb.Models.ScannerDbContext db)
        {
            this.db = db;
        }

        public IActionResult OnGet()
        {
        ViewData["IdKarty"] = new SelectList(db.Karties, "Uid", "Uid");
            return Page();
        }

        [BindProperty]
        public int idPracownik { get; set; }
        [BindProperty]
        public string Imie { get; set; }
        [BindProperty]
        public string Nazwisko { get; set; }
        [BindProperty]
        public string Pesel { get; set; }
        [BindProperty]
        public string numerTelefonu { get; set; }
        [BindProperty]
        public int idKarty { get; set; }
        [BindProperty]
        public string poziomDostepu { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            { 
                if (string.IsNullOrWhiteSpace(Imie))
                {
                    ModelState.AddModelError("imie", "Wpisz imie pracownika!");

                }
                if (string.IsNullOrWhiteSpace(Nazwisko))
                {
                    ModelState.AddModelError("nazwisko", "Wpisz nazwisko pracownika!");

                }
                if (string.IsNullOrWhiteSpace(Pesel))
                {
                    ModelState.AddModelError("pesel", "Wpisz nazwisko pracownika!");

                }
                if (string.IsNullOrWhiteSpace(numerTelefonu))
                {
                    ModelState.AddModelError("numerTelefonu", "Wpisz numerTelefonu pracownika!");

                }
                if (string.IsNullOrWhiteSpace(poziomDostepu))
                {
                    ModelState.AddModelError("poziomDostepu", "Wpisz poziom dostępu pracownika!");
                
                }
                return Page();
            }
            db.Pracowniks.Add(new Models.Pracownik
            {
                Imie = this.Imie,
                Nazwisko = this.Nazwisko,
                Pesel = this.Pesel, 
                NumerTelefonu = this.numerTelefonu,
                IdKarty = this.idKarty,
                PoziomDostepu = this.poziomDostepu
            });
            await db.SaveChangesAsync();
            
            return RedirectToPage("/Success");
            
        }
    }
}
