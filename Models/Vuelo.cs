namespace AirBook.Models
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public string NumeroVuelo { get; set; }
        public int AerolineaId { get; set; }
        public Aerolinea? Aerolinea { get; set; } = default!;
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public decimal Precio { get; set; }
        public ICollection<Reserva>? Reservas { get; set; } = default!;
    }
}
