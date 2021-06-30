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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Colecao_Musica.Controllers
{
    /// <summary>
    /// Controller para efetuar a gestão de músicas
    /// </summary>
    [Authorize]// Só acessivel se autenticado
    public class MusicasController : Controller
    {
        /// <summary>
        /// atributo que referencia a BD do projeto
        /// </summary>
        private readonly Colecao_MusicaBD _context;

        /// <summary>
        /// Atributo que guarda nele os dados do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _dadosServidor;

        /// <summary>
        /// Atributo que irá receber todos os dados referentes à
        /// pessoa q se autenticou no sistema
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;



        public MusicasController(Colecao_MusicaBD context, IWebHostEnvironment dadosServidor,
         UserManager<IdentityUser> userManager){
            _context = context;
            _dadosServidor = dadosServidor;
            _userManager = userManager;
        }

        // GET: Musicas
        [AllowAnonymous]
        public async Task<IActionResult> Index()  
        {
            //var colecao_MusicaBD = _context.Musicas.Include(m => m.Artista);
            //return View(await colecao_MusicaBD.ToListAsync());

            var listaMusicas = (from m in _context.Musicas
                               join r in _context.Artistas on m.ArtistasFK equals r.Id
                               where r.UserNameId == _userManager.GetUserId(User)
                               select m)
                               .OrderBy(m => m.Título);

            //ViewData["ArtistasFK"] = new SelectList(listaMusicas, "Id", "Título");
            return View(listaMusicas);

        }
       

    

        // GET: Musicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicas = await _context.Musicas
                .Include(m => m.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicas == null)
            {
                return NotFound();
            }

            return View(musicas);
        }

        // GET: Musicas/Create
        public IActionResult Create()
        {
            ViewData["ArtistasFK"] = new SelectList(_context.Artistas, "Id", "Nome");
            return View();

 

            // var. auxiliar
            //string user = _userManager.GetUserId(User);

            //Quais os albuns do artista que se autenticou
 
            //var listaAlbuns = (from a in _context.Albuns
                               //join r in _context.artistas on a.artistasfk equals r.id
                               //where r.usernameid == _usermanager.getuserid(user)
                               //select a).orderby(a => a.título);

            // devolver o controlo à View
            // prepara os dados a serem enviados para a View
            // para a Dropdown
            //viewdata["artistafk"] = new selectlist(artistas, "id", "título");
            //return view();


        }

        // POST: Musicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Título,Duracao,Ano,Compositor,ArtistasFK")] Musicas musicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistasFK"] = new SelectList(_context.Artistas, "Id", "Nome", musicas.ArtistasFK);
            return View(musicas);
        }

        // GET: Musicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicas = await _context.Musicas.FindAsync(id);
            if (musicas == null)
            {
                return NotFound();
            }
            ViewData["ArtistasFK"] = new SelectList(_context.Artistas, "Id", "Nome", musicas.ArtistasFK);
            return View(musicas);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Título,Duracao,Ano,Compositor,ArtistasFK")] Musicas musicas)
        {
            if (id != musicas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicasExists(musicas.Id))
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
            ViewData["ArtistasFK"] = new SelectList(_context.Artistas, "Id", "Nome", musicas.ArtistasFK);
            return View(musicas);
        }

        // GET: Musicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicas = await _context.Musicas
                .Include(m => m.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicas == null)
            {
                return NotFound();
            }

            return View(musicas);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicas = await _context.Musicas.FindAsync(id);
            _context.Musicas.Remove(musicas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicasExists(int id)
        {
            return _context.Musicas.Any(e => e.Id == id);
        }
    }
}
