using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.ViewModels
{
    public class HabitacionVM
    {
        public int Numero_habitacion { get; set; }
        public string tipo { get; set; }
        public int capacidad { get; set; }
        public int precio_noche { get; set; }
        public string estado { get; set; }
    }
}
