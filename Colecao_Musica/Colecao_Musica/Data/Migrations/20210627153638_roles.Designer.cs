﻿// <auto-generated />
using System;
using Colecao_Musica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Colecao_Musica.Data.Migrations
{
    [DbContext(typeof(Colecao_MusicaBD))]
    [Migration("20210627153638_roles")]
    partial class roles
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

                    b.Property<string>("Título")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistasFK");

                    b.HasIndex("GenerosFK");

                    b.ToTable("Albuns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = "1976",
                            ArtistasFK = 1,
                            Cover = "HotelCaliforniaAlbumCover.png",
                            Duracao = "43",
                            Editora = "Asylom Records",
                            GenerosFK = 1,
                            NrFaixas = "9",
                            Título = "Hotel Califórnia"
                        },
                        new
                        {
                            Id = 2,
                            Ano = "1996",
                            ArtistasFK = 2,
                            Cover = "anightoperaCover.png",
                            Duracao = "60",
                            Editora = "Asylom Records",
                            GenerosFK = 1,
                            NrFaixas = "9",
                            Título = "A night at Opera"
                        },
                        new
                        {
                            Id = 3,
                            Ano = "1986",
                            ArtistasFK = 3,
                            Cover = "divisionbellCover.png",
                            Duracao = "80",
                            Editora = "Asylom Records",
                            GenerosFK = 1,
                            NrFaixas = "9",
                            Título = "Division Bell"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nacionalidade = "USA",
                            Nome = "Eagles",
                            Url = "https://eagles.com/"
                        },
                        new
                        {
                            Id = 2,
                            Nacionalidade = "UK",
                            Nome = "Queen",
                            Url = "https://queen.com/"
                        },
                        new
                        {
                            Id = 3,
                            Nacionalidade = "UK",
                            Nome = "Pink Floyd",
                            Url = "https://pinkfloyd.com/"
                        },
                        new
                        {
                            Id = 4,
                            Nacionalidade = "UK",
                            Nome = "Dire Straits",
                            Url = "https://direstraits.com/"
                        },
                        new
                        {
                            Id = 5,
                            Nacionalidade = "UK",
                            Nome = "Led Zeppelin",
                            Url = "https://ledzeppelin.com/"
                        },
                        new
                        {
                            Id = 6,
                            Nacionalidade = "Australia",
                            Nome = "AC/DC",
                            Url = "https://acdc.com/"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Designacao = "Rock"
                        },
                        new
                        {
                            Id = 2,
                            Designacao = "Pop"
                        },
                        new
                        {
                            Id = 3,
                            Designacao = "Dance"
                        },
                        new
                        {
                            Id = 4,
                            Designacao = "Classica"
                        },
                        new
                        {
                            Id = 5,
                            Designacao = "Fado"
                        },
                        new
                        {
                            Id = 6,
                            Designacao = "Ópera"
                        },
                        new
                        {
                            Id = 7,
                            Designacao = "Heavy Metal"
                        },
                        new
                        {
                            Id = 8,
                            Designacao = "Jazz"
                        });
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

                    b.Property<string>("Título")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistasFK");

                    b.ToTable("Musicas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = "1976",
                            ArtistasFK = 1,
                            Duracao = "4",
                            Título = "Hotel Califórnia"
                        },
                        new
                        {
                            Id = 2,
                            Ano = "1996",
                            ArtistasFK = 2,
                            Duracao = "7",
                            Título = "Bhoeamian Rapsody"
                        },
                        new
                        {
                            Id = 3,
                            Ano = "1986",
                            ArtistasFK = 3,
                            Duracao = "5",
                            Título = "Divisio Bell"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "a",
                            ConcurrencyStamp = "8758e080-27fa-4326-b961-2438c47537cc",
                            Name = "Artista",
                            NormalizedName = "ARTISTA"
                        },
                        new
                        {
                            Id = "g",
                            ConcurrencyStamp = "d21f13b0-c81f-4f5c-80a7-2b3cc7ffac67",
                            Name = "Gestor",
                            NormalizedName = "GESTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
