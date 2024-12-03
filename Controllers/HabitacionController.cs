using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebahotel.Data.Services;
using pruebahotel.Data.ViewModels;

namespace pruebahotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        public HabitacionServices _habitacionService;
        public HabitacionController(HabitacionServices habitacionServices)
        {
            _habitacionService = habitacionServices;
        }

        //listar habitaciones
        [HttpGet("Listar todas las habitaciones")]
        public IActionResult Getallhabitacion()
        {
            var allhabitaciones = _habitacionService.GetHabitacions();
            return Ok(allhabitaciones);
        }

        //buscar habitaciones
        [HttpGet("Buscar habitacion/{id}")]
        public IActionResult GethabitacionById(int id)
        {
            var habitaciones = _habitacionService.GetHabitacionById(id);
            return Ok(habitaciones);
        }

        //agregar habitaciones
        [HttpPost("Agregar habitacion")]
        public IActionResult AddHabitacion([FromBody]HabitacionVM habitacion)
        {
            _habitacionService.AddHabitacion(habitacion);
            return Ok();
        }

        //Editar habitacion
        [HttpPut("Modificar habitacion/{id}")]
        public IActionResult UpdateHabitacionById(int id, [FromBody] HabitacionVM habitacion)
        {
            var updatehabitacion = _habitacionService.UpdateHabitacionById(id, habitacion);
            return Ok(updatehabitacion);
        }

        //Eliminar habitacion
        [HttpDelete("Eliminar habitacion/{id}")]
        public IActionResult DeleteHabitacionById(int id)
        {
            _habitacionService.DeleteHabitacionById(id);
            return Ok();
        }

    }
}
