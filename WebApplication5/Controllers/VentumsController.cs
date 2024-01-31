using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class VentumsController : Controller
    {
        private readonly BienmesabeContext _context;

        public VentumsController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: Ventums
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.Venta.Include(v => v.IdClienteNavigation).Include(v => v.IdTipoConsumoNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: Ventums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdTipoConsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // GET: Ventums/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumos, "IdTipoConsumo", "IdTipoConsumo");
            return View();
        }

        // POST: Ventums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdCliente,IdTipoConsumo,FechaVenta,HoraVenta")] Ventum ventum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventum.IdCliente);
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumos, "IdTipoConsumo", "IdTipoConsumo", ventum.IdTipoConsumo);
            return View(ventum);
        }

        // GET: Ventums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventum.IdCliente);
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumos, "IdTipoConsumo", "IdTipoConsumo", ventum.IdTipoConsumo);
            return View(ventum);
        }

        // POST: Ventums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdCliente,IdTipoConsumo,FechaVenta,HoraVenta")] Ventum ventum)
        {
            if (id != ventum.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentumExists(ventum.IdVenta))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventum.IdCliente);
            ViewData["IdTipoConsumo"] = new SelectList(_context.TipoConsumos, "IdTipoConsumo", "IdTipoConsumo", ventum.IdTipoConsumo);
            return View(ventum);
        }

        // GET: Ventums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdTipoConsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // POST: Ventums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum != null)
            {
                _context.Venta.Remove(ventum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentumExists(int id)
        {
            return _context.Venta.Any(e => e.IdVenta == id);
        }
    }
}
