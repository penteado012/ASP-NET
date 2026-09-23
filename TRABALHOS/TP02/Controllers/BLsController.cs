
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBLContainer.Models;
using TP02.Data;

public class BLsController : Controller
{
    private readonly AppDbContext _context;

    public BLsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: BLS
    public async Task<IActionResult> Index()
    {
        var bls = await _context.BLs.ToListAsync();

        return View("~/Views/BLs/Index.cshtml", bls);
    }

    // GET: BLS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bl = await _context.BLs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (bl == null)
        {
            return NotFound();
        }

        return View(bl);
    }

    // GET: BLS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BLS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Numero,Consignee,Navio,Containers")] BL bl)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(bl);
    }

    // GET: BLS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bl = await _context.BLs.FindAsync(id);
        if (bl == null)
        {
            return NotFound();
        }
        return View(bl);
    }

    // POST: BLS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Numero,Consignee,Navio,Containers")] BL bl)
    {
        if (id != bl.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bl);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BLExists(bl.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(bl);
    }

    // GET: BLS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bl = await _context.BLs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (bl == null)
        {
            return NotFound();
        }

        return View(bl);
    }

    // POST: BLS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var bl = await _context.BLs.FindAsync(id);
        if (bl != null)
        {
            _context.BLs.Remove(bl);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BLExists(int? id)
    {
        return _context.BLs.Any(e => e.Id == id);
    }
}
