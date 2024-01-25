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
    public class InvMovimientoesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvMovimientoesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvMovimientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMovimientos.ToListAsync());
        }

        // GET: InvMovimientoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMovimiento = await _context.InvMovimientos
                .FirstOrDefaultAsync(m => m.IdMovimientos == id);
            if (invMovimiento == null)
            {
                return NotFound();
            }

            return View(invMovimiento);
        }

        // GET: InvMovimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMovimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimientos,NumDocumento,Descripcion,Fechamov,Idtipoajuste")] InvMovimiento invMovimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invMovimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMovimiento);
        }

        // GET: InvMovimientoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMovimiento = await _context.InvMovimientos.FindAsync(id);
            if (invMovimiento == null)
            {
                return NotFound();
            }
            return View(invMovimiento);
        }

        // POST: InvMovimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdMovimientos,NumDocumento,Descripcion,Fechamov,Idtipoajuste")] InvMovimiento invMovimiento)
        {
            if (id != invMovimiento.IdMovimientos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invMovimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMovimientoExists(invMovimiento.IdMovimientos))
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
            return View(invMovimiento);
        }

        // GET: InvMovimientoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMovimiento = await _context.InvMovimientos
                .FirstOrDefaultAsync(m => m.IdMovimientos == id);
            if (invMovimiento == null)
            {
                return NotFound();
            }

            return View(invMovimiento);
        }

        // POST: InvMovimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var invMovimiento = await _context.InvMovimientos.FindAsync(id);
            if (invMovimiento != null)
            {
                _context.InvMovimientos.Remove(invMovimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMovimientoExists(decimal id)
        {
            return _context.InvMovimientos.Any(e => e.IdMovimientos == id);
        }
    }
}
