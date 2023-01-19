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
        [BindProperty]
        public Models.Budynek Budynek { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            db.Budyneks.Add(new Models.Budynek
            {
                Nazwa = this.Budynek.Nazwa,
                IdSkanera = this.Budynek.IdSkanera
            });
            await db.SaveChangesAsync();

            return RedirectToPage("/Success");
        }
	}
}
