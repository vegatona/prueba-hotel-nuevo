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
    public class DetallesReservaController : ControllerBase
    {
        public DetallesReservaServices _detallesreservaservice;
        public DetallesReservaController(DetallesReservaServices detalleServices)
        {
            _detallesreservaservice = detalleServices;
        }

        // Listar todos los detalles de las reservaciones
        [HttpGet("Listar todas las detalles de las reservaciones")]
        public IActionResult GetAllDetalles()
        {
            try
            {
                var alldetalles = _detallesreservaservice.GetDetalles();
                return Ok(alldetalles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Buscar detalles de la reservación por ID
        [HttpGet("Buscar detalles/{id}")]
        public IActionResult GetDetallesById(int id)
        {
            try
            {
                var detalle = _detallesreservaservice.GetDetallesById(id);
                if (detalle == null)
                {
                    return NotFound("Detalle de reservación no encontrado");
                }
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
