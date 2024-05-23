namespace AirBook.Models
{
    public class Pasajero
    {
        public int IdPasajero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public ICollection<Reserva>? Reservas { get; set; } = default!;
    }
}
