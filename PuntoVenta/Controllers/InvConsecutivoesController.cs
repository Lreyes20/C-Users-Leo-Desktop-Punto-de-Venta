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
    public class InvConsecutivoesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvConsecutivoesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvConsecutivoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvConsecutivos.ToListAsync());
        }

        // GET: InvConsecutivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invConsecutivo = await _context.InvConsecutivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invConsecutivo == null)
            {
                return NotFound();
            }

            return View(invConsecutivo);
        }

        // GET: InvConsecutivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvConsecutivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Consecutivo")] InvConsecutivo invConsecutivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invConsecutivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invConsecutivo);
        }

        // GET: InvConsecutivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invConsecutivo = await _context.InvConsecutivos.FindAsync(id);
            if (invConsecutivo == null)
            {
                return NotFound();
            }
            return View(invConsecutivo);
        }

        // POST: InvConsecutivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Consecutivo")] InvConsecutivo invConsecutivo)
        {
            if (id != invConsecutivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invConsecutivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvConsecutivoExists(invConsecutivo.Id))
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
            return View(invConsecutivo);
        }

        // GET: InvConsecutivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invConsecutivo = await _context.InvConsecutivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invConsecutivo == null)
            {
                return NotFound();
            }

            return View(invConsecutivo);
        }

        // POST: InvConsecutivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invConsecutivo = await _context.InvConsecutivos.FindAsync(id);
            if (invConsecutivo != null)
            {
                _context.InvConsecutivos.Remove(invConsecutivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvConsecutivoExists(int id)
        {
            return _context.InvConsecutivos.Any(e => e.Id == id);
        }
    }
}
