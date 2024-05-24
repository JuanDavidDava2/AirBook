namespace AirBook.Models
{
    public class Itinerario
    {
        public int IdItinerario { get; set; }
        public int IdReserva { get; set; }
        public Reserva? Reserva { get; set; } = default!;
        public string Detalle { get; set; }
    }
}
