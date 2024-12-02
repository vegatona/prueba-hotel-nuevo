using Microsoft.VisualBasic;
using System;

namespace pruebahotel.Data.Models
{
    public class reservaciones
    {
        public int id_reservacion { get; set; }
        public int id_habitacion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public string estado { get; set; }
        public int total_pagado { get; set; }
    }
}