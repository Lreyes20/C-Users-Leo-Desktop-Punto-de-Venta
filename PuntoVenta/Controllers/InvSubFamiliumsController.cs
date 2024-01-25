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
    public class InvSubFamiliumsController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvSubFamiliumsController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvSubFamiliums
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvSubFamilia.ToListAsync());
        }

        // GET: InvSubFamiliums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invSubFamilium = await _context.InvSubFamilia
                .FirstOrDefaultAsync(m => m.IdSubfamilia == id);
            if (invSubFamilium == null)
            {
                return NotFound();
            }

            return View(invSubFamilium);
        }

        // GET: InvSubFamiliums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvSubFamiliums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubfamilia,Descripcion,Informacion,IdFamilia")] InvSubFamilium invSubFamilium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invSubFamilium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invSubFamilium);
        }

        // GET: InvSubFamiliums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invSubFamilium = await _context.InvSubFamilia.FindAsync(id);
            if (invSubFamilium == null)
            {
                return NotFound();
            }
            return View(invSubFamilium);
        }

        // POST: InvSubFamiliums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubfamilia,Descripcion,Informacion,IdFamilia")] InvSubFamilium invSubFamilium)
        {
            if (id != invSubFamilium.IdSubfamilia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invSubFamilium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvSubFamiliumExists(invSubFamilium.IdSubfamilia))
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
            return View(invSubFamilium);
        }

        // GET: InvSubFamiliums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invSubFamilium = await _context.InvSubFamilia
                .FirstOrDefaultAsync(m => m.IdSubfamilia == id);
            if (invSubFamilium == null)
            {
                return NotFound();
            }

            return View(invSubFamilium);
        }

        // POST: InvSubFamiliums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invSubFamilium = await _context.InvSubFamilia.FindAsync(id);
            if (invSubFamilium != null)
            {
                _context.InvSubFamilia.Remove(invSubFamilium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvSubFamiliumExists(int id)
        {
            return _context.InvSubFamilia.Any(e => e.IdSubfamilia == id);
        }
    }
}
