using AirBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Data
{
    public class AirBookDbContext : DbContext
    {
        public AirBookDbContext(DbContextOptions<AirBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Aerolinea> Aerolineas { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Pasajero)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.IdPasajero);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Vuelo)
                .WithMany(v => v.Reservas)
                .HasForeignKey(r => r.IdVuelo);

            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.Aerolinea)
                .WithMany(a => a.Vuelos)
                .HasForeignKey(v => v.AerolineaId);

            modelBuilder.Entity<Itinerario>()
                .HasOne(i => i.Reserva)
                .WithMany(r => r.Itinerarios)
                .HasForeignKey(i => i.IdReserva);

            modelBuilder.Entity<Pasajero>().HasKey(p => p.IdPasajero);

            modelBuilder.Entity<Vuelo>().HasKey(v => v.IdVuelo);

            modelBuilder.Entity<Reserva>().HasKey(r => r.IdReserva);

            modelBuilder.Entity<Aerolinea>().HasKey(a => a.IdAerolinea);

            modelBuilder.Entity<Itinerario>().HasKey(i => i.IdItinerario);
        }
    }
}
