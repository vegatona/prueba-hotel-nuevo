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
                descripcion = hotel.descripcion
            };
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