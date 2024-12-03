using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.ViewModels
{
    public class UsuarioVM
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int NumTel { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
    }
}
