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
    public class InvMedidasController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvMedidasController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvMedidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvMedidas.ToListAsync());
        }

        // GET: InvMedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMedida = await _context.InvMedidas
                .FirstOrDefaultAsync(m => m.IdMedida == id);
            if (invMedida == null)
            {
                return NotFound();
            }

            return View(invMedida);
        }

        // GET: InvMedidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedida,Descripcion")] InvMedida invMedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMedida);
        }

        // GET: InvMedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMedida = await _context.InvMedidas.FindAsync(id);
            if (invMedida == null)
            {
                return NotFound();
            }
            return View(invMedida);
        }

        // POST: InvMedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedida,Descripcion")] InvMedida invMedida)
        {
            if (id != invMedida.IdMedida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMedidaExists(invMedida.IdMedida))
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
            return View(invMedida);
        }

        // GET: InvMedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invMedida = await _context.InvMedidas
                .FirstOrDefaultAsync(m => m.IdMedida == id);
            if (invMedida == null)
            {
                return NotFound();
            }

            return View(invMedida);
        }

        // POST: InvMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invMedida = await _context.InvMedidas.FindAsync(id);
            if (invMedida != null)
            {
                _context.InvMedidas.Remove(invMedida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMedidaExists(int id)
        {
            return _context.InvMedidas.Any(e => e.IdMedida == id);
        }
    }
}
