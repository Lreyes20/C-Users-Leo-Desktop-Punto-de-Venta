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
    public class InvFamiliumsController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvFamiliumsController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvFamiliums
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvFamilia.ToListAsync());
        }

        // GET: InvFamiliums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invFamilium = await _context.InvFamilia
                .FirstOrDefaultAsync(m => m.IdFamilia == id);
            if (invFamilium == null)
            {
                return NotFound();
            }

            return View(invFamilium);
        }

        // GET: InvFamiliums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvFamiliums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFamilia,Descripcion,Informacion")] InvFamilium invFamilium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invFamilium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invFamilium);
        }

        // GET: InvFamiliums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invFamilium = await _context.InvFamilia.FindAsync(id);
            if (invFamilium == null)
            {
                return NotFound();
            }
            return View(invFamilium);
        }

        // POST: InvFamiliums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFamilia,Descripcion,Informacion")] InvFamilium invFamilium)
        {
            if (id != invFamilium.IdFamilia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invFamilium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvFamiliumExists(invFamilium.IdFamilia))
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
            return View(invFamilium);
        }

        // GET: InvFamiliums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invFamilium = await _context.InvFamilia
                .FirstOrDefaultAsync(m => m.IdFamilia == id);
            if (invFamilium == null)
            {
                return NotFound();
            }

            return View(invFamilium);
        }

        // POST: InvFamiliums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invFamilium = await _context.InvFamilia.FindAsync(id);
            if (invFamilium != null)
            {
                _context.InvFamilia.Remove(invFamilium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvFamiliumExists(int id)
        {
            return _context.InvFamilia.Any(e => e.IdFamilia == id);
        }
    }
}
