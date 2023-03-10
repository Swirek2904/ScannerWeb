using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScannerWeb.Models;

namespace ScannerWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ScannerWeb.Models.ScannerDbContext _context;

        public IndexModel(ScannerWeb.Models.ScannerDbContext context)
        {
            _context = context;
        }

        public IList<Historium> Odczyt { get; set; } = default!;

        public IList<Budynek> Budynki { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Historia != null)
            {
                Odczyt = await _context.Historia
                .Include(h => h.IdOsobyNavigation)
                .Include(h => h.IdOsobyNavigation)
                .Include(h => h.IdSkaneraNavigation)
                .ToListAsync();
            }

            if (_context.Budyneks != null)
            {
                Budynki = await _context.Budyneks
                .Where(h => true).ToListAsync();
               
            }

        }

       
    }
}
