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
    public class IngredientesController : Controller
    {
        private readonly BienmesabeContext _context;

        public IngredientesController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: Ingredientes
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.Ingredientes.Include(i => i.IdSuministroNavigation).Include(i => i.IdTipoNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: Ingredientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes
                .Include(i => i.IdSuministroNavigation)
                .Include(i => i.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdIngrediente == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public IActionResult Create()
        {
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro");
            ViewData["IdTipo"] = new SelectList(_context.TipoIngredientes, "IdTipo", "IdTipo");
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIngrediente,IdTipo,IdSuministro,FechaVencimiento")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro", ingrediente.IdSuministro);
            ViewData["IdTipo"] = new SelectList(_context.TipoIngredientes, "IdTipo", "IdTipo", ingrediente.IdTipo);
            return View(ingrediente);
        }

        // GET: Ingredientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro", ingrediente.IdSuministro);
            ViewData["IdTipo"] = new SelectList(_context.TipoIngredientes, "IdTipo", "IdTipo", ingrediente.IdTipo);
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIngrediente,IdTipo,IdSuministro,FechaVencimiento")] Ingrediente ingrediente)
        {
            if (id != ingrediente.IdIngrediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredienteExists(ingrediente.IdIngrediente))
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
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "IdSuministro", ingrediente.IdSuministro);
            ViewData["IdTipo"] = new SelectList(_context.TipoIngredientes, "IdTipo", "IdTipo", ingrediente.IdTipo);
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes
                .Include(i => i.IdSuministroNavigation)
                .Include(i => i.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdIngrediente == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente != null)
            {
                _context.Ingredientes.Remove(ingrediente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredienteExists(int id)
        {
            return _context.Ingredientes.Any(e => e.IdIngrediente == id);
        }
    }
}
