﻿// <auto-generated />
using System;
using AirBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirBook.Migrations
{
    [DbContext(typeof(AirBookDbContext))]
    partial class AirBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirBook.Models.Aerolinea", b =>
                {
                    b.Property<int>("IdAerolinea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAerolinea"));

                    b.Property<string>("NombreAerolinea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAerolinea");

                    b.ToTable("Aerolineas");
                });

            modelBuilder.Entity("AirBook.Models.Itinerario", b =>
                {
                    b.Property<int>("IdItinerario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItinerario"));

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.HasKey("IdItinerario");

                    b.HasIndex("IdReserva");

                    b.ToTable("Itinerarios");
                });

            modelBuilder.Entity("AirBook.Models.Pasajero", b =>
                {
                    b.Property<int>("IdPasajero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPasajero"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPasajero");

                    b.ToTable("Pasajeros");
                });

            modelBuilder.Entity("AirBook.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPasajero")
                        .HasColumnType("int");

                    b.Property<int>("IdVuelo")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdPasajero");

                    b.HasIndex("IdVuelo");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("AirBook.Models.Vuelo", b =>
                {
                    b.Property<int>("IdVuelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVuelo"));

                    b.Property<int>("AerolineaId")
                        .HasColumnType("int");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HoraLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroVuelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdVuelo");

                    b.HasIndex("AerolineaId");

                    b.ToTable("Vuelos");
                });

            modelBuilder.Entity("AirBook.Models.Itinerario", b =>
                {
                    b.HasOne("AirBook.Models.Reserva", "Reserva")
                        .WithMany("Itinerarios")
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("AirBook.Models.Reserva", b =>
                {
                    b.HasOne("AirBook.Models.Pasajero", "Pasajero")
                        .WithMany("Reservas")
                        .HasForeignKey("IdPasajero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirBook.Models.Vuelo", "Vuelo")
                        .WithMany("Reservas")
                        .HasForeignKey("IdVuelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pasajero");

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("AirBook.Models.Vuelo", b =>
                {
                    b.HasOne("AirBook.Models.Aerolinea", "Aerolinea")
                        .WithMany("Vuelos")
                        .HasForeignKey("AerolineaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aerolinea");
                });

            modelBuilder.Entity("AirBook.Models.Aerolinea", b =>
                {
                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("AirBook.Models.Pasajero", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("AirBook.Models.Reserva", b =>
                {
                    b.Navigation("Itinerarios");
                });

            modelBuilder.Entity("AirBook.Models.Vuelo", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
