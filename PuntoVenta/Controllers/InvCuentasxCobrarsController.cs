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
    public class InvCuentasxCobrarsController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvCuentasxCobrarsController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvCuentasxCobrars
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvCuentasxCobrars.ToListAsync());
        }

        // GET: InvCuentasxCobrars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCuentasxCobrar = await _context.InvCuentasxCobrars
                .FirstOrDefaultAsync(m => m.Idcuenta == id);
            if (invCuentasxCobrar == null)
            {
                return NotFound();
            }

            return View(invCuentasxCobrar);
        }

        // GET: InvCuentasxCobrars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvCuentasxCobrars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcuenta,Fecha,Monto,Estado")] InvCuentasxCobrar invCuentasxCobrar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invCuentasxCobrar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invCuentasxCobrar);
        }

        // GET: InvCuentasxCobrars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCuentasxCobrar = await _context.InvCuentasxCobrars.FindAsync(id);
            if (invCuentasxCobrar == null)
            {
                return NotFound();
            }
            return View(invCuentasxCobrar);
        }

        // POST: InvCuentasxCobrars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcuenta,Fecha,Monto,Estado")] InvCuentasxCobrar invCuentasxCobrar)
        {
            if (id != invCuentasxCobrar.Idcuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invCuentasxCobrar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvCuentasxCobrarExists(invCuentasxCobrar.Idcuenta))
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
            return View(invCuentasxCobrar);
        }

        // GET: InvCuentasxCobrars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCuentasxCobrar = await _context.InvCuentasxCobrars
                .FirstOrDefaultAsync(m => m.Idcuenta == id);
            if (invCuentasxCobrar == null)
            {
                return NotFound();
            }

            return View(invCuentasxCobrar);
        }

        // POST: InvCuentasxCobrars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invCuentasxCobrar = await _context.InvCuentasxCobrars.FindAsync(id);
            if (invCuentasxCobrar != null)
            {
                _context.InvCuentasxCobrars.Remove(invCuentasxCobrar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvCuentasxCobrarExists(int id)
        {
            return _context.InvCuentasxCobrars.Any(e => e.Idcuenta == id);
        }
    }
}
