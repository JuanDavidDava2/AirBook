namespace AirBook.Models
{
    public class Aerolinea
    {
        public int IdAerolinea { get; set; }
        public string NombreAerolinea { get; set; }
        public ICollection<Vuelo>? Vuelos { get; set; } = default!;
    }
}
