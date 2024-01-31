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
    public class ProductoIngredientesController : Controller
    {
        private readonly BienmesabeContext _context;

        public ProductoIngredientesController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: ProductoIngredientes
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.ProductoIngredientes.Include(p => p.IdIngredienteNavigation).Include(p => p.IdProductoNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: ProductoIngredientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoIngrediente = await _context.ProductoIngredientes
                .Include(p => p.IdIngredienteNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProductoIngrediente == id);
            if (productoIngrediente == null)
            {
                return NotFound();
            }

            return View(productoIngrediente);
        }

        // GET: ProductoIngredientes/Create
        public IActionResult Create()
        {
            ViewData["IdIngrediente"] = new SelectList(_context.Ingredientes, "IdIngrediente", "IdIngrediente");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: ProductoIngredientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductoIngrediente,IdProducto,IdIngrediente")] ProductoIngrediente productoIngrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoIngrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIngrediente"] = new SelectList(_context.Ingredientes, "IdIngrediente", "IdIngrediente", productoIngrediente.IdIngrediente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", productoIngrediente.IdProducto);
            return View(productoIngrediente);
        }

        // GET: ProductoIngredientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoIngrediente = await _context.ProductoIngredientes.FindAsync(id);
            if (productoIngrediente == null)
            {
                return NotFound();
            }
            ViewData["IdIngrediente"] = new SelectList(_context.Ingredientes, "IdIngrediente", "IdIngrediente", productoIngrediente.IdIngrediente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", productoIngrediente.IdProducto);
            return View(productoIngrediente);
        }

        // POST: ProductoIngredientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductoIngrediente,IdProducto,IdIngrediente")] ProductoIngrediente productoIngrediente)
        {
            if (id != productoIngrediente.IdProductoIngrediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoIngrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoIngredienteExists(productoIngrediente.IdProductoIngrediente))
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
            ViewData["IdIngrediente"] = new SelectList(_context.Ingredientes, "IdIngrediente", "IdIngrediente", productoIngrediente.IdIngrediente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", productoIngrediente.IdProducto);
            return View(productoIngrediente);
        }

        // GET: ProductoIngredientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoIngrediente = await _context.ProductoIngredientes
                .Include(p => p.IdIngredienteNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProductoIngrediente == id);
            if (productoIngrediente == null)
            {
                return NotFound();
            }

            return View(productoIngrediente);
        }

        // POST: ProductoIngredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoIngrediente = await _context.ProductoIngredientes.FindAsync(id);
            if (productoIngrediente != null)
            {
                _context.ProductoIngredientes.Remove(productoIngrediente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoIngredienteExists(int id)
        {
            return _context.ProductoIngredientes.Any(e => e.IdProductoIngrediente == id);
        }
    }
}
