using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;

namespace PuntoVenta.Controllers
{
    public class InvMaestroCuentasController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvMaestroCuentasController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvMaestroCuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMaestroCuentas.ToListAsync());
        }

        // GET: InvMaestroCuentas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMaestroCuenta = await _context.InvMaestroCuentas
                .FirstOrDefaultAsync(m => m.IdCuenta == id);
            if (invMaestroCuenta == null)
            {
                return NotFound();
            }

            return View(invMaestroCuenta);
        }

        // GET: InvMaestroCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMaestroCuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCuenta,IdFecha,IdClienteUbicacion,IdDependiente,IdFactura,Montopago,Montoefectivo,Montotarjeta,ImpuestoServicio,Descuento,Estado,IdTipoPago")] InvMaestroCuenta invMaestroCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invMaestroCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMaestroCuenta);
        }

        // GET: InvMaestroCuentas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMaestroCuenta = await _context.InvMaestroCuentas.FindAsync(id);
            if (invMaestroCuenta == null)
            {
                return NotFound();
            }
            return View(invMaestroCuenta);
        }

        // POST: InvMaestroCuentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdCuenta,IdFecha,IdClienteUbicacion,IdDependiente,IdFactura,Montopago,Montoefectivo,Montotarjeta,ImpuestoServicio,Descuento,Estado,IdTipoPago")] InvMaestroCuenta invMaestroCuenta)
        {
            if (id != invMaestroCuenta.IdCuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invMaestroCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMaestroCuentaExists(invMaestroCuenta.IdCuenta))
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
            return View(invMaestroCuenta);
        }

        // GET: InvMaestroCuentas/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMaestroCuenta = await _context.InvMaestroCuentas
                .FirstOrDefaultAsync(m => m.IdCuenta == id);
            if (invMaestroCuenta == null)
            {
                return NotFound();
            }

            return View(invMaestroCuenta);
        }

        // POST: InvMaestroCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var invMaestroCuenta = await _context.InvMaestroCuentas.FindAsync(id);
            if (invMaestroCuenta != null)
            {
                _context.InvMaestroCuentas.Remove(invMaestroCuenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMaestroCuentaExists(decimal id)
        {
            return _context.InvMaestroCuentas.Any(e => e.IdCuenta == id);
        }
    }
}
