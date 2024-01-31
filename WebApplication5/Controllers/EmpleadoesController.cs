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
    public class EmpleadoesController : Controller
    {
        private readonly BienmesabeContext _context;

        public EmpleadoesController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.Empleados.Include(e => e.IdCargoNavigation).Include(e => e.IdJornadaNavigation).Include(e => e.IdPersonaNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdCargoNavigation)
                .Include(e => e.IdJornadaNavigation)
                .Include(e => e.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo");
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada");
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,IdPersona,IdCargo,IdJornada,Ci")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo", empleado.IdCargo);
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada", empleado.IdJornada);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", empleado.IdPersona);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo", empleado.IdCargo);
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada", empleado.IdJornada);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", empleado.IdPersona);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,IdPersona,IdCargo,IdJornada,Ci")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "IdCargo", empleado.IdCargo);
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada", empleado.IdJornada);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", empleado.IdPersona);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdCargoNavigation)
                .Include(e => e.IdJornadaNavigation)
                .Include(e => e.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
