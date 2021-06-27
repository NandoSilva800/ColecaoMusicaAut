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
using Microsoft.AspNetCore.Identity;

namespace Colecao_Musica.Controllers {


    /// <summary>
    /// Controller para efetuar a gestão dos artistas
    /// </summary>
    [Authorize]// Só acessivel se autenticado
    public class ArtistasController : Controller
    {

        /// <summary>
        /// referência à Base de Dados músicas
        /// </summary>
        private readonly Colecao_MusicaBD _context;

        /// <summary>
        /// objeto para gerir os dados dos Utilizadores registados
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;


        public ArtistasController(Colecao_MusicaBD context,
                     UserManager<IdentityUser> userManager ){
                      _context = context;
                     _userManager = userManager;
            }

            // GET: Artistas
            public async Task<IActionResult> Index()
            {
                return View(await _context.Artistas.ToListAsync());
            }

            // GET: Artistas/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var artistas = await _context.Artistas
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (artistas == null)
                {
                    return NotFound();
                }

                return View(artistas);
            }


        /// <summary>
        /// Após a listagem dos Utilizadores a desbloquear,
        /// processa esse desbloqueio
        /// </summary>
        /// <param name="listaUsersDesbloquear">lista dos ID dos utilizadores a desbloquear</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Gestor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesbloquearUtilizadores(string[] listaUsersDesbloquear)
        {

            /* tarefas:
            *  1. se listaUsersDesbloquear = vazio
            *        - nada se pode fazer
            *     caso contrário
            *        2. procurar pelo Utilizador cujo ID foi fornecido
            *        3. desbloquear esse utilizador
            *             3.1 - alterar a data do LockoutDate
            *             3.2 - validar o email
            */

            // Tarefa 1.
            if (listaUsersDesbloquear.Count() != 0)
            {
                // pq existem dados
                foreach (string userId in listaUsersDesbloquear)
                {
                    try
                    {
                        // Tarefa 2.
                        var user = await _userManager.FindByIdAsync(userId);
                        // Tarefa 3.1
                        await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddDays(-10));
                        // Tarefa 3.2
                        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        await _userManager.ConfirmEmailAsync(user, token);
                    }
                    catch (Exception)
                    {
                        // enviar msg de erro ao utilizador
                        // devolver para uma view
                    }

                }
            }

            // eventualmente, gerar uma mensagem de sucesso para o utilizador

            // devolver à view
            return RedirectToAction("Index", "Home");
        }









        //// get: artistas/create
        //public iactionresult create()
        //    {
        //        return view();
        //    }

        //    // post: artistas/create
        //    // to protect from overposting attacks, enable the specific properties you want to bind to.
        //    // for more details, see http://go.microsoft.com/fwlink/?linkid=317598.
        //    [httppost]
        //    [validateantiforgerytoken]
        //    public async task<iactionresult> create([bind("nome,nacionalidade,url")] artistas artistas)
        //    {
        //        if (modelstate.isvalid)
        //        {
        //            _context.add(artistas);
        //            await _context.savechangesasync();
        //            return redirecttoaction(nameof(index));
        //        }
        //        return view(artistas);
        //    }


            // GET: Artistas/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var artistas = await _context.Artistas.FindAsync(id);
                if (artistas == null)
                {
                    return NotFound();
                }
                return View(artistas);
            }

            // POST: Artistas/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Nome,Nacionalidade,Url")] Artistas artistas)
            {
                if (id != artistas.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(artistas);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArtistasExists(artistas.Id))
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
                return View(artistas);
            }

            // GET: Artistas/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var artistas = await _context.Artistas
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (artistas == null)
                {
                    return NotFound();
                }

                return View(artistas);
            }

            // POST: Artistas/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var artistas = await _context.Artistas.FindAsync(id);
                _context.Artistas.Remove(artistas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ArtistasExists(int id)
            {
                return _context.Artistas.Any(e => e.Id == id);
            }
        }
    }