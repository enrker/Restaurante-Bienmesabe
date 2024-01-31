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
    public class FacturasController : Controller
    {
        private readonly BienmesabeContext _context;

        public FacturasController(BienmesabeContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var bienmesabeContext = _context.Facturas.Include(f => f.IdEmpleadoNavigation).Include(f => f.IdTipoPagoNavigation).Include(f => f.IdVentaNavigation);
            return View(await bienmesabeContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdEmpleadoNavigation)
                .Include(f => f.IdTipoPagoNavigation)
                .Include(f => f.IdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago");
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,IdVenta,NumeroFactura,FechaEmision,IdTipoPago,IdEmpleado")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", factura.IdEmpleado);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago", factura.IdTipoPago);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", factura.IdVenta);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", factura.IdEmpleado);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago", factura.IdTipoPago);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", factura.IdVenta);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,IdVenta,NumeroFactura,FechaEmision,IdTipoPago,IdEmpleado")] Factura factura)
        {
            if (id != factura.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IdFactura))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", factura.IdEmpleado);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago", factura.IdTipoPago);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", factura.IdVenta);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdEmpleadoNavigation)
                .Include(f => f.IdTipoPagoNavigation)
                .Include(f => f.IdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.IdFactura == id);
        }
    }
}
