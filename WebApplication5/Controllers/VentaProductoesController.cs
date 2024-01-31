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
    public class VentaProductoesController : Controller
    {
        private readonly BienmesabeContext _context;

        public VentaProductoesController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: VentaProductoes
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.VentaProductos.Include(v => v.IdProductoNavigation).Include(v => v.IdVentaNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: VentaProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProductos
                .Include(v => v.IdProductoNavigation)
                .Include(v => v.IdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaProducto == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // GET: VentaProductoes/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta");
            return View();
        }

        // POST: VentaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaProducto,IdVenta,IdProducto,Cantidad")] VentaProducto ventaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", ventaProducto.IdProducto);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", ventaProducto.IdVenta);
            return View(ventaProducto);
        }

        // GET: VentaProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProductos.FindAsync(id);
            if (ventaProducto == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", ventaProducto.IdProducto);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", ventaProducto.IdVenta);
            return View(ventaProducto);
        }

        // POST: VentaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaProducto,IdVenta,IdProducto,Cantidad")] VentaProducto ventaProducto)
        {
            if (id != ventaProducto.IdVentaProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaProductoExists(ventaProducto.IdVentaProducto))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", ventaProducto.IdProducto);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", ventaProducto.IdVenta);
            return View(ventaProducto);
        }

        // GET: VentaProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProductos
                .Include(v => v.IdProductoNavigation)
                .Include(v => v.IdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaProducto == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // POST: VentaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaProducto = await _context.VentaProductos.FindAsync(id);
            if (ventaProducto != null)
            {
                _context.VentaProductos.Remove(ventaProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaProductoExists(int id)
        {
            return _context.VentaProductos.Any(e => e.IdVentaProducto == id);
        }
    }
}
