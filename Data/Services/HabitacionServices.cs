using pruebahotel.Data.ViewModels;
using pruebahotel.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace pruebahotel.Data.Services
{
    public class HabitacionServices
    {
        private AppDbContext _context;
        public HabitacionServices(AppDbContext context)
        {
            _context = context;
        }
        //agregar
        public void AddHabitacion(HabitacionVM habitacion)
        {
            var _habitacion = new Habitacion()
            {
                id_hotel = habitacion.id_hotel,
                Numero_habitacion = habitacion.Numero_habitacion,
                tipo = habitacion.tipo,
                capacidad = habitacion.capacidad,
                precio_noche = habitacion.precio_noche,
                estado = habitacion.estado,
            };
            _context.habitaciones.Add(_habitacion);
            _context.SaveChanges();

        }
        //listar
        public List<Habitacion> GetHabitacions() => _context.habitaciones.ToList();
        //bustar
        public Habitacion GetHabitacionById(int idhabitacion) => _context.habitaciones.FirstOrDefault(n => n.Id_habitacion == idhabitacion);
        //editar
        public Habitacion UpdateHabitacionById(int idhabitacion, HabitacionVM habitacion)
        {
            var _habitacion = _context.habitaciones.FirstOrDefault(n => n.Id_habitacion == idhabitacion);
            if (_habitacion != null)
            {
                _habitacion.id_hotel = habitacion.id_hotel;
                _habitacion.Numero_habitacion = habitacion.Numero_habitacion;
                _habitacion.tipo = habitacion.tipo;
                _habitacion.capacidad = habitacion.capacidad;
                _habitacion.precio_noche = habitacion.precio_noche;
                _habitacion.estado = habitacion.estado;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("La habitacion no se pudo modificar!");
            }
            return _habitacion;
        }
        //eliminar
        public void DeleteHabitacionById(int idhabitacion)
        {
            var _habitacion = _context.habitaciones.FirstOrDefault(n => n.Id_habitacion == idhabitacion);
            if (_habitacion != null)
            {
                _context.habitaciones.Remove(_habitacion);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La habitacion con el id {idhabitacion} no existe!");
            }
        }

        // Validar estado de la habitación
        public bool ValidarEstadoHabitacion(int idHabitacion, string nuevoEstado)
        {
            var habitacion = _context.habitaciones.FirstOrDefault(h => h.Id_habitacion == idHabitacion);
            if (habitacion == null)
            {
                throw new Exception("Habitación no encontrada.");
            }
            if (habitacion.estado == "Ocupado" && nuevoEstado == "Disponible")
            {
                throw new Exception("No se puede cambiar una habitación ocupada a disponible mientras está asociada a una reserva.");
            }
            if (habitacion.estado == "Ocupado" && nuevoEstado == "Mantenimiento")
            {
                throw new Exception("No se puede poner una habitación en mantenimiento mientras está ocupada.");
            }
            // Cambiar el estado
            habitacion.estado = nuevoEstado; 
            _context.SaveChanges();
            return true;
        }
    }
}