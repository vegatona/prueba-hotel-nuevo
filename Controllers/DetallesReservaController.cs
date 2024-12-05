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

        //listar hotel
        [HttpGet("Listar todas los detalles de las reservaciones")]
        public IActionResult GetallDetalles()
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

        //buscar hotel
        [HttpGet("Buscar detalles/{id}")]
        public IActionResult GetalldetallesById(int id)
        {
            try
            {
                var detalle = _detallesreservaservice.GetDetallesById(id);
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
