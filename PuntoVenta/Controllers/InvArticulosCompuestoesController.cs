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
    public class InvArticulosCompuestoesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvArticulosCompuestoesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvArticulosCompuestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvArticulosCompuestos.ToListAsync());
        }

        // GET: InvArticulosCompuestoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invArticulosCompuesto = await _context.InvArticulosCompuestos
                .FirstOrDefaultAsync(m => m.IdArticulo == id);
            if (invArticulosCompuesto == null)
            {
                return NotFound();
            }

            return View(invArticulosCompuesto);
        }

        // GET: InvArticulosCompuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvArticulosCompuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArticulo,Idartidepen,Cantidadactual,Cantestablecida")] InvArticulosCompuesto invArticulosCompuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invArticulosCompuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invArticulosCompuesto);
        }

        // GET: InvArticulosCompuestoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invArticulosCompuesto = await _context.InvArticulosCompuestos.FindAsync(id);
            if (invArticulosCompuesto == null)
            {
                return NotFound();
            }
            return View(invArticulosCompuesto);
        }

        // POST: InvArticulosCompuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdArticulo,Idartidepen,Cantidadactual,Cantestablecida")] InvArticulosCompuesto invArticulosCompuesto)
        {
            if (id != invArticulosCompuesto.IdArticulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invArticulosCompuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvArticulosCompuestoExists(invArticulosCompuesto.IdArticulo))
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
            return View(invArticulosCompuesto);
        }

        // GET: InvArticulosCompuestoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invArticulosCompuesto = await _context.InvArticulosCompuestos
                .FirstOrDefaultAsync(m => m.IdArticulo == id);
            if (invArticulosCompuesto == null)
            {
                return NotFound();
            }

            return View(invArticulosCompuesto);
        }

        // POST: InvArticulosCompuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var invArticulosCompuesto = await _context.InvArticulosCompuestos.FindAsync(id);
            if (invArticulosCompuesto != null)
            {
                _context.InvArticulosCompuestos.Remove(invArticulosCompuesto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvArticulosCompuestoExists(decimal id)
        {
            return _context.InvArticulosCompuestos.Any(e => e.IdArticulo == id);
        }
    }
}
