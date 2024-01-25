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
    public class InvArticuloController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvArticuloController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvArticuloes
        public async Task<IActionResult> Index()
        {
            var inventarioPuntoventaContext = _context.InvArticulos.Include(i => i.IdFamiliaNavigation).Include(i => i.IdProveedorNavigation).Include(i => i.IdSubfamiliaNavigation);
            return View(await inventarioPuntoventaContext.ToListAsync());
        }

        // GET: InvArticuloes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invArticulo = await _context.InvArticulos
                .Include(i => i.IdFamiliaNavigation)
                .Include(i => i.IdProveedorNavigation)
                .Include(i => i.IdSubfamiliaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invArticulo == null)
            {
                return NotFound();
            }

            return View(invArticulo);
        }

        // GET: InvArticuloes/Create
        public IActionResult Create()
        {
            ViewData["IdFamilia"] = new SelectList(_context.InvFamilia, "IdFamilia", "IdFamilia");
            ViewData["IdProveedor"] = new SelectList(_context.InvProveedores, "IdProveedor", "IdProveedor");
            ViewData["IdSubfamilia"] = new SelectList(_context.InvSubFamilia, "IdSubfamilia", "IdSubfamilia");
            return View();
        }

        // POST: InvArticuloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdUnidadMedida,IdFamilia,IdUbicacion,IdProveedor,PesoBruto,CantExistencia,CantReservado,Cantpedidominimo,Cantareponer,IndNumeroserie,IndFraccionado,IndConsignacion,IndFechavencimiento,IndVentapeso,IndCompuesto,FechaultimaCompra,PrecioCompra,Costopromedio,Precio1,Precio2,Precio3,Montoimpuesto,IndInventario,IntDescuento,IdSubfamilia")] InvArticulo invArticulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invArticulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFamilia"] = new SelectList(_context.InvFamilia, "IdFamilia", "IdFamilia", invArticulo.IdFamilia);
            ViewData["IdProveedor"] = new SelectList(_context.InvProveedores, "IdProveedor", "IdProveedor", invArticulo.IdProveedor);
            ViewData["IdSubfamilia"] = new SelectList(_context.InvSubFamilia, "IdSubfamilia", "IdSubfamilia", invArticulo.IdSubfamilia);
            return View(invArticulo);
        }

        // GET: InvArticuloes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invArticulo = await _context.InvArticulos.FindAsync(id);
            if (invArticulo == null)
            {
                return NotFound();
            }
            ViewData["IdFamilia"] = new SelectList(_context.InvFamilia, "IdFamilia", "IdFamilia", invArticulo.IdFamilia);
            ViewData["IdProveedor"] = new SelectList(_context.InvProveedores, "IdProveedor", "IdProveedor", invArticulo.IdProveedor);
            ViewData["IdSubfamilia"] = new SelectList(_context.InvSubFamilia, "IdSubfamilia", "IdSubfamilia", invArticulo.IdSubfamilia);
            return View(invArticulo);
        }

        // POST: InvArticuloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Nombre,IdUnidadMedida,IdFamilia,IdUbicacion,IdProveedor,PesoBruto,CantExistencia,CantReservado,Cantpedidominimo,Cantareponer,IndNumeroserie,IndFraccionado,IndConsignacion,IndFechavencimiento,IndVentapeso,IndCompuesto,FechaultimaCompra,PrecioCompra,Costopromedio,Precio1,Precio2,Precio3,Montoimpuesto,IndInventario,IntDescuento,IdSubfamilia")] InvArticulo invArticulo)
        {
            if (id != invArticulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invArticulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvArticuloExists(invArticulo.Id))
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
            ViewData["IdFamilia"] = new SelectList(_context.InvFamilia, "IdFamilia", "IdFamilia", invArticulo.IdFamilia);
            ViewData["IdProveedor"] = new SelectList(_context.InvProveedores, "IdProveedor", "IdProveedor", invArticulo.IdProveedor);
            ViewData["IdSubfamilia"] = new SelectList(_context.InvSubFamilia, "IdSubfamilia", "IdSubfamilia", invArticulo.IdSubfamilia);
            return View(invArticulo);
        }

        // GET: InvArticuloes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invArticulo = await _context.InvArticulos
                .Include(i => i.IdFamiliaNavigation)
                .Include(i => i.IdProveedorNavigation)
                .Include(i => i.IdSubfamiliaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invArticulo == null)
            {
                return NotFound();
            }

            return View(invArticulo);
        }

        // POST: InvArticuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var invArticulo = await _context.InvArticulos.FindAsync(id);
            if (invArticulo != null)
            {
                _context.InvArticulos.Remove(invArticulo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvArticuloExists(decimal id)
        {
            return _context.InvArticulos.Any(e => e.Id == id);
        }
    }
}
