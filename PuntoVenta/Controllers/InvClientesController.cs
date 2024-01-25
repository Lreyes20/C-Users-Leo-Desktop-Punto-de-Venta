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
    public class InvClientesController : Controller
    {
        private readonly InventarioPuntoventaContext _context;

        public InvClientesController(InventarioPuntoventaContext context)
        {
            _context = context;
        }

        // GET: InvClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvClientes.ToListAsync());
        }

        // GET: InvClientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCliente = await _context.InvClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invCliente == null)
            {
                return NotFound();
            }

            return View(invCliente);
        }

        // GET: InvClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Email,Teloficina,Telfax,Cuentabanco")] InvCliente invCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invCliente);
        }

        // GET: InvClientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCliente = await _context.InvClientes.FindAsync(id);
            if (invCliente == null)
            {
                return NotFound();
            }
            return View(invCliente);
        }

        // POST: InvClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombre,Direccion,Email,Teloficina,Telfax,Cuentabanco")] InvCliente invCliente)
        {
            if (id != invCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvClienteExists(invCliente.Id))
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
            return View(invCliente);
        }

        // GET: InvClientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invCliente = await _context.InvClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invCliente == null)
            {
                return NotFound();
            }

            return View(invCliente);
        }

        // POST: InvClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var invCliente = await _context.InvClientes.FindAsync(id);
            if (invCliente != null)
            {
                _context.InvClientes.Remove(invCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvClienteExists(string id)
        {
            return _context.InvClientes.Any(e => e.Id == id);
        }
    }
}
