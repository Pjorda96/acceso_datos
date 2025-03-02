﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using placeMyBet.Models;

namespace placeMyBet.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    [Migration("20191108155723_migration01")]
    partial class migration01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlaceMyBet.Models.Apuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cuota");

                    b.Property<DateTime>("Fecha");

                    b.Property<double>("Importe");

                    b.Property<int>("MercadoId");

                    b.Property<int>("TipoApuesta");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Mercado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("COver");

                    b.Property<double>("CUnder");

                    b.Property<int>("PartidoId");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.ToTable("Mercados");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Hora");

                    b.Property<string>("Local");

                    b.Property<string>("Visitante");

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("placeMyBet.Models.DatosBanco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<int>("Cvv");

                    b.Property<DateTime>("ExpTime");

                    b.Property<string>("Numero");

                    b.Property<int>("Tipo");

                    b.Property<string>("Titular");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("DatosBancos");
                });

            modelBuilder.Entity("placeMyBet.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Apellidos");

                    b.Property<DateTime>("BirtdhDate");

                    b.Property<string>("DNI");

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.Property<double>("Saldo");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Apuesta", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Mercado", "Mercado")
                        .WithMany("Apuesta")
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("placeMyBet.Models.Usuario", "Usuario")
                        .WithMany("Apuesta")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlaceMyBet.Models.Mercado", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Partido", "Partido")
                        .WithMany("Mercado")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("placeMyBet.Models.DatosBanco", b =>
                {
                    b.HasOne("placeMyBet.Models.Usuario", "Usuario")
                        .WithMany("DatosBanco")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
