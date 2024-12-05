using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace pruebahotel.Data.Models
{
    public class reservaciones
    {
        [Key]
        public int id_reservacion { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public DateTime fecha_inicio { get; set; }
        [Required]
        public DateTime fecha_final { get; set; }
        [Required]
        [RegularExpression("Pendiente|Confirmada|Cancelada", ErrorMessage = "El estado de la reservación debe ser 'Pendiente', 'Confirmada' o 'Cancelada'.")]
        public string estado { get; set; }
        public int total_pagado { get; set; }
        // Relación con usuario
        public Usuario Usuario { get; set; }
        // Relación con detalles
        public ICollection<DetalleReservacion> DetallesReservacion { get; set; }

    }
}