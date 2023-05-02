using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_P1_Raura_Cordero.Data;
using Proyecto_P1_Raura_Cordero.Models;

namespace Proyecto_P1_Raura_Cordero.Controllers
{
    public class ResenasController : Controller
    {
        private readonly Proyecto_P1_Raura_CorderoContext _context;

        public ResenasController(Proyecto_P1_Raura_CorderoContext context)
        {
            _context = context;
        }

        // GET: Resenas
        public async Task<IActionResult> Index()
        {
            var proyecto_P1_Raura_CorderoContext = _context.Resenas.Include(r => r.Pelicula);
            return View(await proyecto_P1_Raura_CorderoContext.ToListAsync());
        }

        // GET: Resenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resenas == null)
            {
                return NotFound();
            }

            var resena = await _context.Resenas
                .Include(r => r.Pelicula)
                .FirstOrDefaultAsync(m => m.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // GET: Resenas/Create
        public IActionResult Create()
        {
            ViewData["IdPelicula"] = new SelectList(_context.Pelicula, "IdPelicula", "IdPelicula");
            return View();
        }

        // POST: Resenas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResena,Titulo,Texto,IdPelicula")] Resena resena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPelicula"] = new SelectList(_context.Pelicula, "IdPelicula", "IdPelicula", resena.IdPelicula);
            return View(resena);
        }

        // GET: Resenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resenas == null)
            {
                return NotFound();
            }

            var resena = await _context.Resenas.FindAsync(id);
            if (resena == null)
            {
                return NotFound();
            }
            ViewData["IdPelicula"] = new SelectList(_context.Pelicula, "IdPelicula", "IdPelicula", resena.IdPelicula);
            return View(resena);
        }

        // POST: Resenas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResena,Titulo,Texto,IdPelicula")] Resena resena)
        {
            if (id != resena.IdResena)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResenaExists(resena.IdResena))
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
            ViewData["IdPelicula"] = new SelectList(_context.Pelicula, "IdPelicula", "IdPelicula", resena.IdPelicula);
            return View(resena);
        }

        // GET: Resenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resenas == null)
            {
                return NotFound();
            }

            var resena = await _context.Resenas
                .Include(r => r.Pelicula)
                .FirstOrDefaultAsync(m => m.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // POST: Resenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resenas == null)
            {
                return Problem("Entity set 'Proyecto_P1_Raura_CorderoContext.Resenas'  is null.");
            }
            var resena = await _context.Resenas.FindAsync(id);
            if (resena != null)
            {
                _context.Resenas.Remove(resena);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResenaExists(int id)
        {
          return (_context.Resenas?.Any(e => e.IdResena == id)).GetValueOrDefault();
        }
    }
}
