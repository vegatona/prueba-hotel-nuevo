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
    public class HotelController : ControllerBase
    {
        public HotelServices _hotelService;
        public HotelController(HotelServices hotelServices)
        {
            _hotelService = hotelServices;
        }

        //listar hotel
        [HttpGet("Listar todas las hoteles")]
        public IActionResult Getallhotel()
        {
            try
            {
                var allhoteles = _hotelService.GetHotels();
                return Ok(allhoteles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //buscar hotel
        [HttpGet("Buscar hotel/{id}")]
        public IActionResult GethotelById(int id)
        {
            try
            {
                var hotel = _hotelService.GetHotelById(id);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //agregar hotel
        [HttpPost("Agregar hotel")]
        public IActionResult Addhotel([FromBody] HotelVM hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { message = "Datos inválidos." });

                _hotelService.AddHoteles(hotel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Editar hotel
        [HttpPut("Modificar hotel/{id}")]
        public IActionResult UpdatehotelById(int id, [FromBody] HotelVM hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { message = "Datos inválidos." });

                var updatehotel = _hotelService.UpdateHotelById(id, hotel);
                return Ok(updatehotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Eliminar hotel
        [HttpDelete("Eliminar hotel/{id}")]
        public IActionResult DeletehotelById(int id)
        {
            try
            {
                _hotelService.DeleteHotelById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
