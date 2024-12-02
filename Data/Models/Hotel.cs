using System;

namespace pruebahotel.Data.Models
{
    public class Hotel
    {
        public int id_hotel { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public DateTime horarios { get; set; }
        public string descripcion { get; set; }
    }
}
