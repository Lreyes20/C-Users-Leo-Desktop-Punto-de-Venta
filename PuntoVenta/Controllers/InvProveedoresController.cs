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
    public class InvProveedoresController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvProveedoresController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvProveedores
        public async Task<IActionResult> Index()
        {
            var inventarioPuntoventaContext = _context.InvProveedores.Include(i => i.ProvinciaNavigation);
            return View(await inventarioPuntoventaContext.ToListAsync());
        }

        // GET: InvProveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invProveedore = await _context.InvProveedores
                .Include(i => i.ProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (invProveedore == null)
            {
                return NotFound();
            }

            return View(invProveedore);
        }

        // GET: InvProveedores/Create
        public IActionResult Create()
        {
            ViewData["Provincia"] = new SelectList(_context.InvProvincias, "Id", "Id");
            return View();
        }

        // POST: InvProveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedor,Nombre,Contacto,Cedula,Direccion,Provincia,Email,Website,Fechainiciorelacion,Telefono1,Telfax,Telcelular,Apartadopostal")] InvProveedore invProveedore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invProveedore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Provincia"] = new SelectList(_context.InvProvincias, "Id", "Id", invProveedore.Provincia);
            return View(invProveedore);
        }

        // GET: InvProveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invProveedore = await _context.InvProveedores.FindAsync(id);
            if (invProveedore == null)
            {
                return NotFound();
            }
            ViewData["Provincia"] = new SelectList(_context.InvProvincias, "Id", "Id", invProveedore.Provincia);
            return View(invProveedore);
        }

        // POST: InvProveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedor,Nombre,Contacto,Cedula,Direccion,Provincia,Email,Website,Fechainiciorelacion,Telefono1,Telfax,Telcelular,Apartadopostal")] InvProveedore invProveedore)
        {
            if (id != invProveedore.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invProveedore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvProveedoreExists(invProveedore.IdProveedor))
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
            ViewData["Provincia"] = new SelectList(_context.InvProvincias, "Id", "Id", invProveedore.Provincia);
            return View(invProveedore);
        }

        // GET: InvProveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invProveedore = await _context.InvProveedores
                .Include(i => i.ProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (invProveedore == null)
            {
                return NotFound();
            }

            return View(invProveedore);
        }

        // POST: InvProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invProveedore = await _context.InvProveedores.FindAsync(id);
            if (invProveedore != null)
            {
                _context.InvProveedores.Remove(invProveedore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvProveedoreExists(int id)
        {
            return _context.InvProveedores.Any(e => e.IdProveedor == id);
        }
    }
}
