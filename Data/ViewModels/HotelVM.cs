using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.ViewModels
{
    public class HotelVM
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public DateTime horarios { get; set; }
        public string descripcion { get; set; }
    }
}
