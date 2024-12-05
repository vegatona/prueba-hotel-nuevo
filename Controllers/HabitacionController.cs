using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebahotel.Data.Services;
using pruebahotel.Data.ViewModels;
using pruebahotel.Data.Models;

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
            try
            {
                var allhabitaciones = _habitacionService.GetHabitacions();
                return Ok(allhabitaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //buscar habitaciones
        [HttpGet("Buscar habitacion/{id}")]
        public IActionResult GethabitacionById(int id)
        {
            try
            {
                var habitaciones = _habitacionService.GetHabitacionById(id);
                return Ok(habitaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //agregar habitaciones
        [HttpPost("Agregar habitacion")]
        public IActionResult AddHabitacion([FromBody] HabitacionVM habitacion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { message = "Datos inválidos." });
                _habitacionService.AddHabitacion(habitacion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Editar habitacion
        [HttpPut("Modificar habitacion/{id}")]
        public IActionResult UpdateHabitacionById(int id, [FromBody] HabitacionVM habitacion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { message = "Datos inválidos." });

                var updatehabitacion = _habitacionService.UpdateHabitacionById(id, habitacion);
                return Ok(updatehabitacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Eliminar habitacion
        [HttpDelete("Eliminar habitacion/{id}")]
        public IActionResult DeleteHabitacionById(int id)
        {
            try
            {
                _habitacionService.DeleteHabitacionById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}