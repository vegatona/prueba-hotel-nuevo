using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace pruebahotel.Data.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        [Required]
        public string nombre { get; set;}
        public string apellido { get; set;}
        [Required]
        public int NumTel { get; set; }
        [Required]
        public string rol { get; set; }
        [Required]
        public string password { get; set; }
        // Relación con reservaciones
        public ICollection<reservaciones> Reservaciones { get; set; }

    }
}
