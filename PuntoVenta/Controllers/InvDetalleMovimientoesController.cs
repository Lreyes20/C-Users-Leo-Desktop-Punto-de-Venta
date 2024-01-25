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
    public class InvDetalleMovimientoesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvDetalleMovimientoesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvDetalleMovimientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvDetalleMovimientos.ToListAsync());
        }

        // GET: InvDetalleMovimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDetalleMovimiento = await _context.InvDetalleMovimientos
                .FirstOrDefaultAsync(m => m.IdDocumento == id);
            if (invDetalleMovimiento == null)
            {
                return NotFound();
            }

            return View(invDetalleMovimiento);
        }

        // GET: InvDetalleMovimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvDetalleMovimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDocumento,IdArticulo,Cantidad")] InvDetalleMovimiento invDetalleMovimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invDetalleMovimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invDetalleMovimiento);
        }

        // GET: InvDetalleMovimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDetalleMovimiento = await _context.InvDetalleMovimientos.FindAsync(id);
            if (invDetalleMovimiento == null)
            {
                return NotFound();
            }
            return View(invDetalleMovimiento);
        }

        // POST: InvDetalleMovimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDocumento,IdArticulo,Cantidad")] InvDetalleMovimiento invDetalleMovimiento)
        {
            if (id != invDetalleMovimiento.IdDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invDetalleMovimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvDetalleMovimientoExists(invDetalleMovimiento.IdDocumento))
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
            return View(invDetalleMovimiento);
        }

        // GET: InvDetalleMovimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDetalleMovimiento = await _context.InvDetalleMovimientos
                .FirstOrDefaultAsync(m => m.IdDocumento == id);
            if (invDetalleMovimiento == null)
            {
                return NotFound();
            }

            return View(invDetalleMovimiento);
        }

        // POST: InvDetalleMovimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invDetalleMovimiento = await _context.InvDetalleMovimientos.FindAsync(id);
            if (invDetalleMovimiento != null)
            {
                _context.InvDetalleMovimientos.Remove(invDetalleMovimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvDetalleMovimientoExists(int id)
        {
            return _context.InvDetalleMovimientos.Any(e => e.IdDocumento == id);
        }
    }
}
