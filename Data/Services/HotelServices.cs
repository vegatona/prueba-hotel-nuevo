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
            if (_context.hotels.Any(h => h.nombre.ToLower() == hotel.nombre.ToLower()))
                throw new Exception("Ya existe un hotel con el mismo nombre.");

            var _hotel = new Hotel()
            {
                nombre = hotel.nombre,
                direccion = hotel.direccion,
                telefono = hotel.telefono,
                descripcion = hotel.descripcion
            };

            //hoarios
            if (!System.Text.RegularExpressions.Regex.IsMatch(hotel.horarios, @"Check-in: \d{2}:\d{2}, Check-out: \d{2}:\d{2}"))
                throw new Exception("El formato de horarios debe ser 'Check-in: HH:mm, Check-out: HH:mm'.");

            _context.hotels.Add(_hotel);
            _context.SaveChanges();
        }
        //listar
        public List<Hotel> GetHotels() => _context.hotels.ToList();
        //bustar
        public Hotel GetHotelById(int idhotel) => _context.hotels.FirstOrDefault(n => n.id_hotel == idhotel);
        //editar
        public Hotel UpdateHotelById(int idhotel, HotelVM hotel)
        {

            var _hotel = _context.hotels.FirstOrDefault(n => n.id_hotel == idhotel);
            // Actualizar los campos
            hotel.nombre = hotel.nombre ?? hotel.nombre;
            hotel.direccion = hotel.direccion ?? hotel.direccion;
            hotel.telefono = hotel.telefono > 0 ? hotel.telefono : hotel.telefono;
            hotel.horarios = hotel.horarios ?? hotel.horarios;
            hotel.descripcion = hotel.descripcion ?? hotel.descripcion;

            // Validar formato del horario si se actualiza
            if (!string.IsNullOrEmpty(hotel.horarios) &&
                !System.Text.RegularExpressions.Regex.IsMatch(hotel.horarios, @"Check-in: \d{2}:\d{2}, Check-out: \d{2}:\d{2}"))
                throw new Exception("El formato de horarios debe ser 'Check-in: HH:mm, Check-out: HH:mm'.");

            if (_hotel != null)
            {
                _hotel.nombre = hotel.nombre;
                _hotel.direccion = hotel.direccion;
                _hotel.telefono = hotel.telefono;
                _hotel.descripcion = hotel.descripcion;

                _context.SaveChanges();
            }

            else
            {
                throw new Exception("El hotel no se pudo modificar!");
            }
            return _hotel;
        }
        //eliminar
        public void DeleteHotelById(int idhotel)
        {
            var _hotel = _context.hotels.FirstOrDefault(n => n.id_hotel == idhotel);
            if (_hotel != null)
            {
                _context.hotels.Remove(_hotel);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El hotel con el id {idhotel} no existe!");
            }
        }
    }
}