namespace AirBook.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdPasajero { get; set; }
        public Pasajero Pasajero { get; set; }
        public int IdVuelo { get; set; }
        public Vuelo Vuelo { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
        public ICollection<Itinerario> Itinerarios { get; set; }
    }
}
