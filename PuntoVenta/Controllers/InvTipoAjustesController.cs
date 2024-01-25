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
    public class InvTipoAjustesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvTipoAjustesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvTipoAjustes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvTipoAjustes.ToListAsync());
        }

        // GET: InvTipoAjustes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invTipoAjuste = await _context.InvTipoAjustes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invTipoAjuste == null)
            {
                return NotFound();
            }

            return View(invTipoAjuste);
        }

        // GET: InvTipoAjustes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvTipoAjustes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipocuenta,Nombre")] InvTipoAjuste invTipoAjuste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invTipoAjuste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invTipoAjuste);
        }

        // GET: InvTipoAjustes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invTipoAjuste = await _context.InvTipoAjustes.FindAsync(id);
            if (invTipoAjuste == null)
            {
                return NotFound();
            }
            return View(invTipoAjuste);
        }

        // POST: InvTipoAjustes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipocuenta,Nombre")] InvTipoAjuste invTipoAjuste)
        {
            if (id != invTipoAjuste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invTipoAjuste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvTipoAjusteExists(invTipoAjuste.Id))
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
            return View(invTipoAjuste);
        }

        // GET: InvTipoAjustes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invTipoAjuste = await _context.InvTipoAjustes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invTipoAjuste == null)
            {
                return NotFound();
            }

            return View(invTipoAjuste);
        }

        // POST: InvTipoAjustes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invTipoAjuste = await _context.InvTipoAjustes.FindAsync(id);
            if (invTipoAjuste != null)
            {
                _context.InvTipoAjustes.Remove(invTipoAjuste);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvTipoAjusteExists(int id)
        {
            return _context.InvTipoAjustes.Any(e => e.Id == id);
        }
    }
}
