using pruebahotel.Data.Models;
using pruebahotel.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.Services
{
    public class DetallesReservaServices
    {
        private AppDbContext _context;
        public DetallesReservaServices(AppDbContext context)
        {
            _context = context;
        }

        //listar
        public List<DetalleReservacion> GetDetalles() => _context.DetallesReservacion.ToList();
        //bustar
        public DetalleReservacion GetDetallesById(int iddetalles) => _context.DetallesReservacion.FirstOrDefault(n => n.IdReserva == iddetalles);
    }
}
