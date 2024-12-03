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
            var allhoteles = _hotelService.GetHotels();
            return Ok(allhoteles);
        }

        //buscar hotel
        [HttpGet("Buscar hotel/{id}")]
        public IActionResult GethotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            return Ok(hotel);
        }

        //agregar hotel
        [HttpPost("Agregar hotel")]
        public IActionResult Addhotel([FromBody] HotelVM hotel)
        {
            _hotelService.AddHoteles(hotel);
            return Ok();
        }

        //Editar hotel
        [HttpPut("Modificar hotel/{id}")]
        public IActionResult UpdatehotelById(int id, [FromBody] HotelVM hotel)
        {
            var updatehotel = _hotelService.UpdateHotelById(id, hotel);
            return Ok(updatehotel);
        }

        //Eliminar hotel
        [HttpDelete("Eliminar hotel/{id}")]
        public IActionResult DeletehotelById(int id)
        {
            _hotelService.DeleteHotelById(id);
            return Ok();
        }
    }
}
