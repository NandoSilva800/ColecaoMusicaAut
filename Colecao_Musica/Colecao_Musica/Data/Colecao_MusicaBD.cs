using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Colecao_Musica.Models;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

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
            //Adicionar dados para as tabelas (seed)
            //********************************************************

            // adicionar os Roles
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "a", Name = "Artista", NormalizedName = "ARTISTA" },
               new IdentityRole { Id = "g", Name = "Gestor", NormalizedName = "GESTOR" }
            );


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
               new Artistas { Id = 1, Nome = "Eagles", Nacionalidade ="USA", Url = "https://eagles.com/" },
               new Artistas { Id = 2, Nome = "Queen", Nacionalidade = "UK", Url = "https://queen.com/" },
               new Artistas { Id = 3, Nome = "Pink Floyd", Nacionalidade = "UK", Url = "https://pinkfloyd.com/" },
               new Artistas { Id = 4, Nome = "Dire Straits", Nacionalidade = "UK", Url = "https://direstraits.com/" },
               new Artistas { Id = 5, Nome = "Led Zeppelin", Nacionalidade = "UK", Url = "https://ledzeppelin.com/" },
               new Artistas { Id = 6, Nome = "AC/DC", Nacionalidade = "Australia", Url = "https://acdc.com/" }
            );

            modelBuilder.Entity<Albuns>().HasData(
               new Albuns { Id = 1, Título = "Hotel Califórnia", Duracao = "43", Ano = "1976", Editora = "Asylom Records", NrFaixas = "9", Cover ="HotelCaliforniaAlbumCover.png", GenerosFK = 1, ArtistasFK = 1 },
                new Albuns { Id = 2, Título = "A night at Opera", Duracao = "60", Ano = "1996", Editora = "Asylom Records", NrFaixas = "9", Cover = "anightoperaCover.png", GenerosFK = 1, ArtistasFK = 2 },
              new Albuns { Id = 3, Título = "Division Bell", Duracao = "80", Ano = "1986", Editora = "Asylom Records", NrFaixas = "9", Cover = "divisionbellCover.png", GenerosFK = 1, ArtistasFK = 3 }
                );

          

            modelBuilder.Entity<Musicas>().HasData(
               new Musicas { Id = 1, Título = "Hotel Califórnia", Duracao = "4", Ano = "1976", ArtistasFK = 1  },
               new Musicas { Id = 2, Título = "Bhoeamian Rapsody", Duracao = "7", Ano = "1996", ArtistasFK = 2 },
               new Musicas { Id = 3, Título = "Divisio Bell", Duracao = "5", Ano = "1986", ArtistasFK = 3 }

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
