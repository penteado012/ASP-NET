
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBLContainer.Models;
using TP02.Data;

public class ContainersController : Controller
{
    private readonly AppDbContext _context;

    public ContainersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: CONTAINERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Containers.ToListAsync());
    }

    // GET: CONTAINERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var container = await _context.Containers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (container == null)
        {
            return NotFound();
        }

        return View(container);
    }

    // GET: CONTAINERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CONTAINERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Numero,Tipo,Tamanho,BLId,BL")] Container container)
    {
        if (ModelState.IsValid)
        {
            _context.Add(container);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(container);
    }

    // GET: CONTAINERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var container = await _context.Containers.FindAsync(id);
        if (container == null)
        {
            return NotFound();
        }
        return View(container);
    }

    // POST: CONTAINERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Numero,Tipo,Tamanho,BLId,BL")] Container container)
    {
        if (id != container.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(container);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(container.Id))
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
        return View(container);
    }

    // GET: CONTAINERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var container = await _context.Containers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (container == null)
        {
            return NotFound();
        }

        return View(container);
    }

    // POST: CONTAINERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var container = await _context.Containers.FindAsync(id);
        if (container != null)
        {
            _context.Containers.Remove(container);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContainerExists(int? id)
    {
        return _context.Containers.Any(e => e.Id == id);
    }
}
