using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.ViewModels
{
    public class ReservaVM
    {
        public int IdUsuario { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        [RegularExpression("Pendiente|Confirmada|Cancelada", ErrorMessage = "El estado de la reservación debe ser 'Pendiente', 'Confirmada' o 'Cancelada'.")]
        public string estado { get; set; }
        public int total_pagado { get; set; }
    }
}
