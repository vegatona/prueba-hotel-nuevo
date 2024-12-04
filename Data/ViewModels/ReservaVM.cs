using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.ViewModels
{
    public class ReservaVM
    {
        public int IdUsuario { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public string estado { get; set; }
        public int total_pagado { get; set; }
    }
}
