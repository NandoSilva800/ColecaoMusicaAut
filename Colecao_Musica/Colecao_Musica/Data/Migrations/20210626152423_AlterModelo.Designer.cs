﻿// <auto-generated />
using Colecao_Musica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Colecao_Musica.Data.Migrations
{
    [DbContext(typeof(Colecao_MusicaBD))]
    [Migration("20210626152423_AlterModelo")]
    partial class AlterModelo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbunsMusicas", b =>
                {
                    b.Property<int>("ListaDeAlbunsId")
                        .HasColumnType("int");

                    b.Property<int>("ListaDeMusicasId")
                        .HasColumnType("int");

                    b.HasKey("ListaDeAlbunsId", "ListaDeMusicasId");

                    b.HasIndex("ListaDeMusicasId");

                    b.ToTable("AlbunsMusicas");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Albuns", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("ArtistasFK")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Editora")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("GenerosFK")
                        .HasColumnType("int");

                    b.Property<string>("NrFaixas")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistasFK");

                    b.HasIndex("GenerosFK");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Artistas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNameId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Generos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Musicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("ArtistasFK")
                        .HasColumnType("int");

                    b.Property<string>("Compositor")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistasFK");

                    b.ToTable("Musicas");
                });

            modelBuilder.Entity("AlbunsMusicas", b =>
                {
                    b.HasOne("Colecao_Musica.Models.Albuns", null)
                        .WithMany()
                        .HasForeignKey("ListaDeAlbunsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colecao_Musica.Models.Musicas", null)
                        .WithMany()
                        .HasForeignKey("ListaDeMusicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Colecao_Musica.Models.Albuns", b =>
                {
                    b.HasOne("Colecao_Musica.Models.Artistas", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistasFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colecao_Musica.Models.Generos", "Genero")
                        .WithMany("ListaDeAlbuns")
                        .HasForeignKey("GenerosFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Musicas", b =>
                {
                    b.HasOne("Colecao_Musica.Models.Artistas", "Artista")
                        .WithMany("ListaDeMusicas")
                        .HasForeignKey("ArtistasFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Artistas", b =>
                {
                    b.Navigation("ListaDeMusicas");
                });

            modelBuilder.Entity("Colecao_Musica.Models.Generos", b =>
                {
                    b.Navigation("ListaDeAlbuns");
                });
#pragma warning restore 612, 618
        }
    }
}