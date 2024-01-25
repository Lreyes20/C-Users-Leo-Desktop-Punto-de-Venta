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
    public class InvParametroesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvParametroesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvParametroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvParametros.ToListAsync());
        }

        // GET: InvParametroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invParametro = await _context.InvParametros
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (invParametro == null)
            {
                return NotFound();
            }

            return View(invParametro);
        }

        // GET: InvParametroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvParametroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametro,Descripcion,Valorparam,Valorparam2,Valorparam3")] InvParametro invParametro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invParametro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invParametro);
        }

        // GET: InvParametroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invParametro = await _context.InvParametros.FindAsync(id);
            if (invParametro == null)
            {
                return NotFound();
            }
            return View(invParametro);
        }

        // POST: InvParametroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParametro,Descripcion,Valorparam,Valorparam2,Valorparam3")] InvParametro invParametro)
        {
            if (id != invParametro.IdParametro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invParametro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvParametroExists(invParametro.IdParametro))
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
            return View(invParametro);
        }

        // GET: InvParametroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invParametro = await _context.InvParametros
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (invParametro == null)
            {
                return NotFound();
            }

            return View(invParametro);
        }

        // POST: InvParametroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invParametro = await _context.InvParametros.FindAsync(id);
            if (invParametro != null)
            {
                _context.InvParametros.Remove(invParametro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvParametroExists(int id)
        {
            return _context.InvParametros.Any(e => e.IdParametro == id);
        }
    }
}
