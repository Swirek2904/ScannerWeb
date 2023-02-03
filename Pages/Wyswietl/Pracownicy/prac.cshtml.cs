using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScannerWeb.Models;

namespace ScannerWeb.Pages
{
    public class pracModel : PageModel
    {

        private readonly ScannerWeb.Models.ScannerDbContext _context;

        public pracModel(ScannerWeb.Models.ScannerDbContext context)
        {
            _context = context;
        }

        public IList<Pracownik> Prac { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Pracowniks != null)
            {
                Prac = (IList<Pracownik>)await _context.Pracowniks
                .Where(h => true).ToListAsync();




            }
        }
    }
}

