using pruebahotel.Data.ViewModels;
using pruebahotel.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace pruebahotel.Data.Services
{
    public class ReservacionServices
    {
        private AppDbContext _context;
        public ReservacionServices(AppDbContext context)
        {
            _context = context;
        }
        //agregar
        public void AddReservacion(ReservaVM reserva)
        {
            var _reserva = new reservaciones()
            {
                id_habitacion = reserva.id_habitacion,
                fecha_inicio = reserva.fecha_inicio,
                fecha_final = reserva.fecha_final,
                estado = reserva.estado,
                total_pagado = reserva.total_pagado
            };
            _context.Reservaciones.Add(_reserva);
            _context.SaveChanges();
        }
        //listar
        public List<reservaciones> GetReservacion() => _context.Reservaciones.ToList();
        //bustar
        public reservaciones GetReservacionById(int idreserva) => _context.Reservaciones.FirstOrDefault(n => n.id_reservacion == idreserva);
        //editar
        public reservaciones UpdateReservacionById(int idresrva, ReservaVM reserva)
        {
            var _reserva = _context.Reservaciones.FirstOrDefault(n => n.id_reservacion == idresrva);
            if (_reserva != null)
            {
                _reserva.id_habitacion = reserva.id_habitacion;
                _reserva.fecha_inicio = reserva.fecha_inicio;
                _reserva.fecha_final = reserva.fecha_final;
                _reserva.estado = reserva.estado;
                _reserva.total_pagado = reserva.total_pagado;

                _context.SaveChanges();
            }
            return _reserva;
        }
        //eliminar
        public void DeletereservaById(int idreserva)
        {
            var _reserva = _context.Reservaciones.FirstOrDefault(n => n.id_reservacion == idreserva);
            if (_reserva != null)
            {
                _context.Reservaciones.Remove(_reserva);
                _context.SaveChanges();
            }
        }
    }
}
