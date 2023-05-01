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
    public class PeliculasController : Controller
    {
        private readonly Proyecto_P1_Raura_CorderoContext _context;

		private readonly IWebHostEnvironment _env;
		public PeliculasController(Proyecto_P1_Raura_CorderoContext context, IWebHostEnvironment env)
        {
            _context = context;
			_env = env;
		}
        

		// GET: Peliculas
		public async Task<IActionResult> Index()
        {
              return _context.Pelicula != null ? 
                          View(await _context.Pelicula.ToListAsync()) :
                          Problem("Entity set 'Proyecto_P1_Raura_CorderoContext.Pelicula'  is null.");
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pelicula == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula
                .FirstOrDefaultAsync(m => m.IdPelicula == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelicula,Nombre,Descripcion,Genero,anio,Poster,IdResena")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pelicula == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelicula,Nombre,Descripcion,Genero,anio,Poster,IdResena")] Pelicula pelicula)
        {
            if (id != pelicula.IdPelicula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.IdPelicula))
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
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pelicula == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula
                .FirstOrDefaultAsync(m => m.IdPelicula == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pelicula == null)
            {
                return Problem("Entity set 'Proyecto_P1_Raura_CorderoContext.Pelicula'  is null.");
            }
            var pelicula = await _context.Pelicula.FindAsync(id);
            if (pelicula != null)
            {
                _context.Pelicula.Remove(pelicula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
          return (_context.Pelicula?.Any(e => e.IdPelicula == id)).GetValueOrDefault();
        }

		

		[HttpPost]
		public async Task<IActionResult> Upload(IFormFile file)
		{
			// Crea una ruta de archivo única
			string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

			// Construye la ruta completa de la imagen
			string filePath = Path.Combine(_env.WebRootPath, "posters", fileName);

			// Guarda la imagen en el sistema de archivos
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			// Retorna la ruta de la imagen
			return Ok(new { filePath });
		}

		[HttpPost]
		public async Task<IActionResult> CrearPelicula(Pelicula pelicula, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					// Crea una ruta de archivo única
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

					// Construye la ruta completa de la imagen
					string filePath = Path.Combine(_env.WebRootPath, "posters", fileName);

					// Guarda la imagen en el sistema de archivos
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}

					// Asigna la ruta de la imagen a la propiedad Poster del objeto Pelicula
					pelicula.Poster = filePath;
				}

				_context.Add(pelicula);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(pelicula);
		}

	}
}
