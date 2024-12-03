using System.ComponentModel.DataAnnotations;
using System;

namespace pruebahotel.Data.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre { get; set;}
        public string apellido { get; set;}
        public int NumTel { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
    }
}
