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
    public class SuministroesController : Controller
    {
        private readonly BienmesabeContext _context;

        public SuministroesController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: Suministroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suministros.ToListAsync());
        }

        // GET: Suministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (suministro == null)
            {
                return NotFound();
            }

            return View(suministro);
        }

        // GET: Suministroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministro,Nombre,PrecioUnitario")] Suministro suministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suministro);
        }

        // GET: Suministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministros.FindAsync(id);
            if (suministro == null)
            {
                return NotFound();
            }
            return View(suministro);
        }

        // POST: Suministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuministro,Nombre,PrecioUnitario")] Suministro suministro)
        {
            if (id != suministro.IdSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuministroExists(suministro.IdSuministro))
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
            return View(suministro);
        }

        // GET: Suministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (suministro == null)
            {
                return NotFound();
            }

            return View(suministro);
        }

        // POST: Suministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suministro = await _context.Suministros.FindAsync(id);
            if (suministro != null)
            {
                _context.Suministros.Remove(suministro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuministroExists(int id)
        {
            return _context.Suministros.Any(e => e.IdSuministro == id);
        }
    }
}
