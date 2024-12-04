﻿using pruebahotel.Data.ViewModels;
using pruebahotel.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
                IdUsuario = reserva.IdUsuario,
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
                _reserva.IdUsuario = reserva.IdUsuario;
                _reserva.fecha_inicio = reserva.fecha_inicio;
                _reserva.fecha_final = reserva.fecha_final;
                _reserva.estado = reserva.estado;
                _reserva.total_pagado = reserva.total_pagado;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("La reservacion no se puede modificar");
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
            else
            {
                throw new Exception($"La reservacion con el id {idreserva} no existe!");
            }
        }

        // Validar estado de la reservación
        public bool ValidarEstadoReservacion(int idReserva, string nuevoEstado)
        {
            var reserva = _context.Reservaciones.FirstOrDefault(r => r.id_reservacion == idReserva);
            if (reserva == null)
            {
                throw new Exception("Reservación no encontrada.");
            }

            // Si la reservación está cancelada, no puede ser cambiada
            if (reserva.estado == "Cancelada")
            {
                throw new Exception("No se puede modificar una reservación cancelada.");
            }

            // Validar que no se puede poner una reservación confirmada como pendiente
            if (reserva.estado == "Confirmada" && nuevoEstado == "Pendiente")
            {
                throw new Exception("No se puede cambiar una reservación confirmada a pendiente.");
            }

            // Validar que el total pagado sea mayor a 0 antes de confirmar
            if (nuevoEstado == "Confirmada" && reserva.total_pagado <= 0)
            {
                throw new Exception("El total pagado debe ser mayor a 0 para confirmar la reservación.");
            }
            // Cambiar el estado
            reserva.estado = nuevoEstado;
            _context.SaveChanges();
            return true;
        }
    }
}