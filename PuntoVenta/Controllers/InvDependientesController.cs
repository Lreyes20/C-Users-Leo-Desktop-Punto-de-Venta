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
    public class InvDependientesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvDependientesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvDependientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvDependientes.ToListAsync());
        }

        // GET: InvDependientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDependiente = await _context.InvDependientes
                .FirstOrDefaultAsync(m => m.IdDependiente == id);
            if (invDependiente == null)
            {
                return NotFound();
            }

            return View(invDependiente);
        }

        // GET: InvDependientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvDependientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDependiente,Nombre,Estado")] InvDependiente invDependiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invDependiente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invDependiente);
        }

        // GET: InvDependientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDependiente = await _context.InvDependientes.FindAsync(id);
            if (invDependiente == null)
            {
                return NotFound();
            }
            return View(invDependiente);
        }

        // POST: InvDependientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDependiente,Nombre,Estado")] InvDependiente invDependiente)
        {
            if (id != invDependiente.IdDependiente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invDependiente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvDependienteExists(invDependiente.IdDependiente))
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
            return View(invDependiente);
        }

        // GET: InvDependientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invDependiente = await _context.InvDependientes
                .FirstOrDefaultAsync(m => m.IdDependiente == id);
            if (invDependiente == null)
            {
                return NotFound();
            }

            return View(invDependiente);
        }

        // POST: InvDependientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invDependiente = await _context.InvDependientes.FindAsync(id);
            if (invDependiente != null)
            {
                _context.InvDependientes.Remove(invDependiente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvDependienteExists(int id)
        {
            return _context.InvDependientes.Any(e => e.IdDependiente == id);
        }
    }
}
