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
    public class InvProvinciasController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvProvinciasController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvProvincias
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvProvincias.ToListAsync());
        }

        // GET: InvProvincias/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invProvincia = await _context.InvProvincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invProvincia == null)
            {
                return NotFound();
            }

            return View(invProvincia);
        }

        // GET: InvProvincias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvProvincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripción")] InvProvincia invProvincia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invProvincia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invProvincia);
        }

        // GET: InvProvincias/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invProvincia = await _context.InvProvincias.FindAsync(id);
            if (invProvincia == null)
            {
                return NotFound();
            }
            return View(invProvincia);
        }

        // POST: InvProvincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Descripción")] InvProvincia invProvincia)
        {
            if (id != invProvincia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invProvincia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvProvinciaExists(invProvincia.Id))
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
            return View(invProvincia);
        }

        // GET: InvProvincias/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invProvincia = await _context.InvProvincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invProvincia == null)
            {
                return NotFound();
            }

            return View(invProvincia);
        }

        // POST: InvProvincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var invProvincia = await _context.InvProvincias.FindAsync(id);
            if (invProvincia != null)
            {
                _context.InvProvincias.Remove(invProvincia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvProvinciaExists(decimal id)
        {
            return _context.InvProvincias.Any(e => e.Id == id);
        }
    }
}
