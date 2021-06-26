using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Colecao_Musica.Data;
using Colecao_Musica.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace Colecao_Musica.Controllers
{

    /// <summary>
    /// Controller para efetuar a gestão de Albuns de musica
    /// </summary>

    ///[Authorize]

    public class AlbunsController : Controller
    {
        private readonly Colecao_MusicaBD _context;
        

        public AlbunsController(Colecao_MusicaBD context)
        {
            _context = context;
        }

        // GET: Albuns
        public async Task<IActionResult> Index()
        {

            var colecaoAlbuns = await _context.Albuns.Include(a => a.Artista).Include(a => a.Genero).ToListAsync();
            return View(colecaoAlbuns);
        }

        // GET: Albuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albuns = await _context.Albuns
                .Include(a => a.Artista)
                .Include(a => a.Genero)
               .FirstOrDefaultAsync(m => m.Id == id);
            if (albuns == null)
            {
                return NotFound();
            }
            return View(albuns);
        }

        // GET: Albuns/Create
        public IActionResult Create()
        {
            ViewData["ArtistasFK"] = new SelectList( _context.Artistas.OrderBy(a=>a.Nome), "Id", "Nome");
            ViewData["GenerosFK"] = new SelectList(_context.Generos, "Id", "Designacao");

            return View();
        }

        // POST: Albuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("Titulo,Duracao,NrFaixas,Ano,Editora,Cover,GenerosFK,ArtistasFK")]Albuns album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ArtistasFK"] = new SelectList(_context.Artistas.OrderBy(a=>a.Nome), "Id", "Nome", album.ArtistasFK);
            ViewData["GenerosFK"] = new SelectList(_context.Generos, "Id", "Designacao", album.GenerosFK);
            return View(album);
        }

        // GET: Albuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albuns = await _context.Albuns.FindAsync(id);
            if (albuns == null)
            {
                return NotFound();
            }
            ViewData["ArtistasFK"] = new SelectList(_context.Artistas, "Id", "Nome", albuns.ArtistasFK);
            ViewData["GenerosFK"] = new SelectList(_context.Generos, "Id", "Designacao", albuns.GenerosFK);
            return View(albuns);
        }

        // POST: Albuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titulo,Duracao,NrFaixas,Ano,Editora,Cover,GenerosFK,ArtistasFK")] Albuns albuns)
        {
            if (id != albuns.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albuns);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbunsExists(albuns.Id))
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
            ViewData["ArtistasFK"] = new SelectList(_context.Artistas, "Id", "Nome", albuns.ArtistasFK);
            ViewData["GenerosFK"] = new SelectList(_context.Generos, "Id", "Designacao", albuns.GenerosFK);
            return View(albuns);
        }

        // GET: Albuns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albuns = await _context.Albuns
                .Include(a => a.Artista)
                .Include(a => a.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (albuns == null)
            {
                return NotFound();
            }

            return View(albuns);
        }

        // POST: Albuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albuns = await _context.Albuns.FindAsync(id);
            _context.Albuns.Remove(albuns);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbunsExists(int id)
        {
            return _context.Albuns.Any(e => e.Id == id);
        }
    }
}
