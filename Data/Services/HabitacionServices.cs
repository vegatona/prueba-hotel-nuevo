using pruebahotel.Data.ViewModels;
using pruebahotel.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
                Numero_habitacion = habitacion.Numero_habitacion,
                tipo = habitacion.tipo,
                capacidad = habitacion.capacidad,
                precio_noche = habitacion.precio_noche,
                estado = habitacion.estado
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
            if(_habitacion != null)
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
            if(_habitacion != null)
            {
                _context.habitaciones.Remove(_habitacion);
                _context.SaveChanges();
            }
        }
    }
}
