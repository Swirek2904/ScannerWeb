using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScannerWeb.Models;

namespace ScannerWeb.Pages
{
    public class skanModel : PageModel
    {
        private readonly ScannerWeb.Models.ScannerDbContext _context;

        public skanModel(ScannerWeb.Models.ScannerDbContext context)
        {
            _context = context;
        }

        public IList<Skaner> ska { get; set; } = default!;

        public IList<Budynek> Budynki { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Skaners != null)
            {
                ska = (IList<Skaner>)await _context.Skaners
                .Where(h => true).ToListAsync();

            }
            if (_context.Budyneks != null)
            {
                Budynki = await _context.Budyneks
                .Where(h => true).ToListAsync();
            }
        }
    }
}

