using pruebahotel.Data.Models;
using pruebahotel.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.Services
{
    public class HotelServices
    {
        private AppDbContext _context;
        public HotelServices(AppDbContext context)
        {
            _context = context;
        }
        //agregar
        public void AddHoteles(HotelVM hotel)
        {
            var _hotel = new Hotel()
            {
                nombre = hotel.nombre,
                direccion = hotel.direccion,
                telefono = hotel.telefono,
                horarios = hotel.horarios,
                descripcion = hotel.descripcion
            };
            _context.hotels.Add(_hotel);
            _context.SaveChanges();
        }/*
        //listar
        public List<Hotel> GetHotels() => _context.hotels.ToList();
        //bustar
        public Hotel GetHotelById(int idhabitacion) => _context.habitaciones.FirstOrDefault(n => n.Id_habitacion == idhabitacion);
        //editar
        public Habitacion UpdateHabitacionById(int idhabitacion, HabitacionVM habitacion)
        {
            var _habitacion = _context.habitaciones.FirstOrDefault(n => n.Id_habitacion == idhabitacion);
            if (_habitacion != null)
            {
                _habitacion.Numero_habitacion = habitacion.Numero_habitacion;
                _habitacion.tipo = habitacion.tipo;
                _habitacion.capacidad = habitacion.capacidad;
                _habitacion.precio_noche = habitacion.precio_noche;
                _habitacion.estado = habitacion.estado;

                _context.SaveChanges();
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
        }*/
    }
}
