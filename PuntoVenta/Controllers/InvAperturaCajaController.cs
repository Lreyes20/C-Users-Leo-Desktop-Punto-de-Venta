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
    public class InvAperturaCajaController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvAperturaCajaController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvAperturaCajas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvAperturaCajas.ToListAsync());
        }

        // GET: InvAperturaCajas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invAperturaCaja = await _context.InvAperturaCajas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invAperturaCaja == null)
            {
                return NotFound();
            }

            return View(invAperturaCaja);
        }

        // GET: InvAperturaCajas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvAperturaCajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Monto,Montocxc")] InvAperturaCaja invAperturaCaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invAperturaCaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invAperturaCaja);
        }

        // GET: InvAperturaCajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invAperturaCaja = await _context.InvAperturaCajas.FindAsync(id);
            if (invAperturaCaja == null)
            {
                return NotFound();
            }
            return View(invAperturaCaja);
        }

        // POST: InvAperturaCajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Monto,Montocxc")] InvAperturaCaja invAperturaCaja)
        {
            if (id != invAperturaCaja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invAperturaCaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvAperturaCajaExists(invAperturaCaja.Id))
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
            return View(invAperturaCaja);
        }

        // GET: InvAperturaCajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invAperturaCaja = await _context.InvAperturaCajas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invAperturaCaja == null)
            {
                return NotFound();
            }

            return View(invAperturaCaja);
        }

        // POST: InvAperturaCajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invAperturaCaja = await _context.InvAperturaCajas.FindAsync(id);
            if (invAperturaCaja != null)
            {
                _context.InvAperturaCajas.Remove(invAperturaCaja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvAperturaCajaExists(int id)
        {
            return _context.InvAperturaCajas.Any(e => e.Id == id);
        }
    }
}
