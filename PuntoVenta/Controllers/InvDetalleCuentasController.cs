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
    public class InvDetalleCuentasController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvDetalleCuentasController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvDetalleCuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvDetalleCuentas.ToListAsync());
        }

        // GET: InvDetalleCuentas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDetalleCuenta = await _context.InvDetalleCuentas
                .FirstOrDefaultAsync(m => m.IdCuenta == id);
            if (invDetalleCuenta == null)
            {
                return NotFound();
            }

            return View(invDetalleCuenta);
        }

        // GET: InvDetalleCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvDetalleCuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCuenta,IdLinea,IdCodarticulo,Unidamedidad,Cantidad,Costoventa,Impuestoventa,Costopromedio,Descuento,Cortesia,Tipo,Opctipo")] InvDetalleCuenta invDetalleCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invDetalleCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invDetalleCuenta);
        }

        // GET: InvDetalleCuentas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDetalleCuenta = await _context.InvDetalleCuentas.FindAsync(id);
            if (invDetalleCuenta == null)
            {
                return NotFound();
            }
            return View(invDetalleCuenta);
        }

        // POST: InvDetalleCuentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdCuenta,IdLinea,IdCodarticulo,Unidamedidad,Cantidad,Costoventa,Impuestoventa,Costopromedio,Descuento,Cortesia,Tipo,Opctipo")] InvDetalleCuenta invDetalleCuenta)
        {
            if (id != invDetalleCuenta.IdCuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invDetalleCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvDetalleCuentaExists(invDetalleCuenta.IdCuenta))
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
            return View(invDetalleCuenta);
        }

        // GET: InvDetalleCuentas/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDetalleCuenta = await _context.InvDetalleCuentas
                .FirstOrDefaultAsync(m => m.IdCuenta == id);
            if (invDetalleCuenta == null)
            {
                return NotFound();
            }

            return View(invDetalleCuenta);
        }

        // POST: InvDetalleCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var invDetalleCuenta = await _context.InvDetalleCuentas.FindAsync(id);
            if (invDetalleCuenta != null)
            {
                _context.InvDetalleCuentas.Remove(invDetalleCuenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvDetalleCuentaExists(decimal id)
        {
            return _context.InvDetalleCuentas.Any(e => e.IdCuenta == id);
        }
    }
}
