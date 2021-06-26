using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Colecao_Musica.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Colecao_Musica.Data
{
    /// <summary>
    /// representa a DB da colecao de musica
    /// </summary>
    public class Colecao_MusicaBD : IdentityDbContext {

        //onde está guardada a BD --> appsettings.json
        // tipo da BD ---->    startup.cs

        public Colecao_MusicaBD(DbContextOptions<Colecao_MusicaBD> options) : base(options) { }


        /// <summary>
        /// Método para assistir a criaçºao da BD que representa o modelo
        /// </summary>
        /// <param name="modelBuilder">opção de configuração da criação do modelo</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // importa todo o comportamento deste método
            //Definido na classe DbContext
            base.OnModelCreating(modelBuilder);

            //********************************************************
            //Acrescentar novas tarefas...
            //********************************************************


            // Adicionar dados às tabelas da BD
          modelBuilder.Entity<Generos>().HasData(
               new Generos { Id = 1, Designacao = "Rock" },
               new Generos { Id = 2, Designacao = "Pop" },
               new Generos { Id = 3, Designacao = "Dance" },
               new Generos { Id = 4, Designacao = "Classica" },
               new Generos { Id = 5, Designacao = "Fado" },
               new Generos { Id = 6, Designacao = "Ópera" },
               new Generos { Id = 7, Designacao = "Heavy Metal" },
               new Generos { Id = 8, Designacao = "Jazz" }
            );
            
            modelBuilder.Entity<Artistas>().HasData(
               new Artistas { Id = 1, Nome = "Eagles", Nacionalidade ="USA", Url = "https://eagles.com/" }
            );

            modelBuilder.Entity<Albuns>().HasData(
               new Albuns { Id = 1, Titulo = "Hotel Califórnia", Duracao = "43", Ano = "1976", Editora = "Asylom Records", NrFaixas = "9", Cover ="HotelCaliforniaAlbumCover.png", GenerosFK = 1, ArtistasFK = 1 }
            );

          

            modelBuilder.Entity<Musicas>().HasData(
               new Musicas { Id = 1, Titulo = "Hotel Califórnia", Duracao = "6", Ano = "1976", ArtistasFK = 1  }

            );



        }
    

        //*********************************************
        //especificar as tabelas na BD
        //*********************************************
        public DbSet<Musicas> Musicas { get; set; }
        public DbSet<Albuns> Albuns { get; set; }
        public DbSet<Artistas> Artistas { get; set; }
        public DbSet<Generos> Generos { get; set; }
        //*********************************************
    }

}
