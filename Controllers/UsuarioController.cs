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
    public class UsuarioController : ControllerBase
    {
        public UsuarioServices _usuarioService;
        public UsuarioController(UsuarioServices usuarioServices)
        {
            _usuarioService = usuarioServices;
        }

        //listar usuarios
        [HttpGet("Listar todas las usuarios")]
        public IActionResult Getallusuario()
        {
            var allusuario = _usuarioService.GetUsuarios();
            return Ok(allusuario);
        }

        //buscar usaurio
        [HttpGet("Buscar usuario/{id}")]
        public IActionResult GetusaurioById(int id)
        {
            var usuario = _usuarioService.GetUsuarioById(id);
            return Ok(usuario);
        }

        //agregar usuario
        [HttpPost("Agregar usuario")]
        public IActionResult Addusuario([FromBody] UsuarioVM usuario)
        {
            _usuarioService.AddUsuario(usuario);
            return Ok();
        }

        //Editar usuario
        [HttpPut("Modificar usuario/{id}")]
        public IActionResult UpdateusuarioById(int id, [FromBody] UsuarioVM usuario)
        {
            var updateusuario = _usuarioService.UpdateUsuarioById(id, usuario);
            return Ok(updateusuario);
        }

        //Eliminar usuario
        [HttpDelete("Eliminar usuario/{id}")]
        public IActionResult DeleteUsaurioById(int id)
        {
            _usuarioService.DeleteusuarioById(id);
            return Ok();
        }
    }
}
