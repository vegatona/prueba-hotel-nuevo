using Microsoft.EntityFrameworkCore;
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

        // Listar todos los detalles de las reservaciones
        public List<DetalleReservacion> GetDetalles()
        {
            return _context.DetallesReservacion
                .Include(d => d.Habitacion)
                .Include(d => d.Reservaciones) 
                .ToList();
        }

        // Buscar detalle por ID de la reservación
        public DetalleReservacion GetDetallesById(int id)
        {
            return _context.DetallesReservacion
                .Include(d => d.Habitacion)
                .Include(d => d.Reservaciones)
                .FirstOrDefault(n => n.IdReserva == id);
        }
    }
}
