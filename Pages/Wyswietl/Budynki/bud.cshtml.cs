using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScannerWeb.Models;

namespace ScannerWeb.Pages
{
    public class budModel : PageModel
    {

        private readonly ScannerWeb.Models.ScannerDbContext _context;

        public budModel(ScannerWeb.Models.ScannerDbContext context)
        {
            _context = context;
        }

        public IList<Budynek> bud { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Budyneks != null)
            {
                bud = (IList<Budynek>)await _context.Budyneks
                .Where(h => true).ToListAsync();




            }
        }
    }
}

