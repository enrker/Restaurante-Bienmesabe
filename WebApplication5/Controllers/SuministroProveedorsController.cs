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
    public class SuministroProveedorsController : Controller
    {
        private readonly BienmesabeContext _context;

        public SuministroProveedorsController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: SuministroProveedors
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.SuministroProveedors.Include(s => s.IdProveedorNavigation).Include(s => s.IdSuministroNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: SuministroProveedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministroProveedor = await _context.SuministroProveedors
                .Include(s => s.IdProveedorNavigation)
                .Include(s => s.IdSuministroNavigation)
                .FirstOrDefaultAsync(m => m.IdSuministroProveedor == id);
            if (suministroProveedor == null)
            {
                return NotFound();
            }

            return View(suministroProveedor);
        }

        // GET: SuministroProveedors/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor");
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro");
            return View();
        }

        // POST: SuministroProveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministroProveedor,IdProveedor,IdSuministro,FechaEntrega,Descripcion")] SuministroProveedor suministroProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suministroProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", suministroProveedor.IdProveedor);
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro", suministroProveedor.IdSuministro);
            return View(suministroProveedor);
        }

        // GET: SuministroProveedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministroProveedor = await _context.SuministroProveedors.FindAsync(id);
            if (suministroProveedor == null)
            {
                return NotFound();
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", suministroProveedor.IdProveedor);
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro", suministroProveedor.IdSuministro);
            return View(suministroProveedor);
        }

        // POST: SuministroProveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuministroProveedor,IdProveedor,IdSuministro,FechaEntrega,Descripcion")] SuministroProveedor suministroProveedor)
        {
            if (id != suministroProveedor.IdSuministroProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suministroProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuministroProveedorExists(suministroProveedor.IdSuministroProveedor))
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", suministroProveedor.IdProveedor);
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro", suministroProveedor.IdSuministro);
            return View(suministroProveedor);
        }

        // GET: SuministroProveedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministroProveedor = await _context.SuministroProveedors
                .Include(s => s.IdProveedorNavigation)
                .Include(s => s.IdSuministroNavigation)
                .FirstOrDefaultAsync(m => m.IdSuministroProveedor == id);
            if (suministroProveedor == null)
            {
                return NotFound();
            }

            return View(suministroProveedor);
        }

        // POST: SuministroProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suministroProveedor = await _context.SuministroProveedors.FindAsync(id);
            if (suministroProveedor != null)
            {
                _context.SuministroProveedors.Remove(suministroProveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuministroProveedorExists(int id)
        {
            return _context.SuministroProveedors.Any(e => e.IdSuministroProveedor == id);
        }
    }
}
