using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System;
using System.Reflection.PortableExecutable;
using ScannerWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ScannerWeb.Pages.Dodaj.Budynek
{
    public class BudynekModel : PageModel
    {
        public void OnGet()
		{
        }
		public readonly ScannerDbContext db;
		public BudynekModel(ScannerDbContext db)
		{
			this.db = db;
		}
		public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Nazwa))
            {
                ModelState.AddModelError("Nazwa", "Wpisz nazwe budynku!");
                return Page();
            }
            if (string.IsNullOrWhiteSpace(idSkanera.ToString()))
            {
                ModelState.AddModelError("idSkanera", "Wpisz id skanera!");
                return Page();
            }
            
            db.Budyneks.Add(new Models.Budynek
            {
                Nazwa = this.Nazwa,
                IdSkanera = this.idSkanera
            });
			db.SaveChanges();
			return Page();
        }
        [BindProperty]
		public int idBudynku { get; set; }
		[BindProperty]
        public string? Nazwa { get; set; }
        [BindProperty]
        public int idSkanera { get; set; }
	}
}
