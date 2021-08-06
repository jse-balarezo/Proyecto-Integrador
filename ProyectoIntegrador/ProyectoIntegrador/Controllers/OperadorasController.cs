using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Data;
using ProyectoIntegrador.Entities;

namespace ProyectoIntegrador.Controllers
{
    [Authorize]
    public class OperadorasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperadorasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Operadoras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Operadoras.Include(o => o.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Operadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operadora = await _context.Operadoras
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.OperadoraId == id);
            if (operadora == null)
            {
                return NotFound();
            }

            return View(operadora);
        }

        // GET: Operadoras/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto");
            return View();
        }

        // POST: Operadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperadoraId,Nombre,UsuarioId")] Operadora operadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", operadora.UsuarioId);
            return View(operadora);
        }

        // GET: Operadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operadora = await _context.Operadoras.FindAsync(id);
            if (operadora == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", operadora.UsuarioId);
            return View(operadora);
        }

        // POST: Operadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperadoraId,Nombre,UsuarioId")] Operadora operadora)
        {
            if (id != operadora.OperadoraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperadoraExists(operadora.OperadoraId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", operadora.UsuarioId);
            return View(operadora);
        }

        // GET: Operadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operadora = await _context.Operadoras
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.OperadoraId == id);
            if (operadora == null)
            {
                return NotFound();
            }

            return View(operadora);
        }

        // POST: Operadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operadora = await _context.Operadoras.FindAsync(id);
            _context.Operadoras.Remove(operadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperadoraExists(int id)
        {
            return _context.Operadoras.Any(e => e.OperadoraId == id);
        }
    }
}
