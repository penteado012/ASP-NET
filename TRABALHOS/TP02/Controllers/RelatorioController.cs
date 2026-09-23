using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP02.Data;

namespace TP02.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;

        public RelatorioController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bls = await _context.BLs
                .Include(b => b.Containers)
                .ToListAsync();

            return View(bls);
        }
    }
}