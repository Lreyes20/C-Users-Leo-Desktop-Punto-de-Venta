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
    public class InvCierreCajasController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvCierreCajasController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvCierreCajas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvCierreCajas.ToListAsync());
        }

        // GET: InvCierreCajas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCierreCaja = await _context.InvCierreCajas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invCierreCaja == null)
            {
                return NotFound();
            }

            return View(invCierreCaja);
        }

        // GET: InvCierreCajas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvCierreCajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,MontoEfectivo,MontoTarjetas,MontoCuentascobar,MontoGastos,MontoOtrosingresos,MontoImpservicio,MontoTrabajo,MontoTotal,Montocxc,Montodesc,Montosinpe")] InvCierreCaja invCierreCaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invCierreCaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invCierreCaja);
        }

        // GET: InvCierreCajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCierreCaja = await _context.InvCierreCajas.FindAsync(id);
            if (invCierreCaja == null)
            {
                return NotFound();
            }
            return View(invCierreCaja);
        }

        // POST: InvCierreCajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,MontoEfectivo,MontoTarjetas,MontoCuentascobar,MontoGastos,MontoOtrosingresos,MontoImpservicio,MontoTrabajo,MontoTotal,Montocxc,Montodesc,Montosinpe")] InvCierreCaja invCierreCaja)
        {
            if (id != invCierreCaja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invCierreCaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvCierreCajaExists(invCierreCaja.Id))
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
            return View(invCierreCaja);
        }

        // GET: InvCierreCajas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCierreCaja = await _context.InvCierreCajas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invCierreCaja == null)
            {
                return NotFound();
            }

            return View(invCierreCaja);
        }

        // POST: InvCierreCajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invCierreCaja = await _context.InvCierreCajas.FindAsync(id);
            if (invCierreCaja != null)
            {
                _context.InvCierreCajas.Remove(invCierreCaja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvCierreCajaExists(int id)
        {
            return _context.InvCierreCajas.Any(e => e.Id == id);
        }
    }
}
