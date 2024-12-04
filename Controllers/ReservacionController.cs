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
    public class ReservacionController : ControllerBase
    {
        public ReservacionServices _reservacionService;
        public ReservacionController(ReservacionServices reservacionServices)
        {
            _reservacionService = reservacionServices;
        }

        //listar reservaciones
        [HttpGet("Listar todas las reservaciones")]
        public IActionResult Getallreservacion()
        {
            try
            {
                var allreservaciones = _reservacionService.GetReservacion();
                return Ok(allreservaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //buscar reservacion
        [HttpGet("Buscar reservacion/{id}")]
        public IActionResult GetreservacionById(int id)
        {
            try
            {
                var reservacion = _reservacionService.GetReservacionById(id);
                return Ok(reservacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //agregar reservacion
        [HttpPost("Agregar reservacion")]
        public IActionResult Addreservacion([FromBody] ReservaVM reservacion)
        {
            try
            {
                _reservacionService.AddReservacion(reservacion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Editar reservacion
        [HttpPut("Modificar reservacion/{id}")]
        public IActionResult UpdatereservacionById(int id, [FromBody] ReservaVM reservacion)
        {
            try
            {
                var updatereservacion = _reservacionService.UpdateReservacionById(id, reservacion);
                return Ok(updatereservacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Eliminar reservacion
        [HttpDelete("Eliminar reservacion/{id}")]
        public IActionResult DeletereservacionById(int id)
        {
            try
            {
                _reservacionService.DeletereservaById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}