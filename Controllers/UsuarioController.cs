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
            try
            {
                var allusuario = _usuarioService.GetUsuarios();
                return Ok(allusuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //buscar usaurio
        [HttpGet("Buscar usuario/{id}")]
        public IActionResult GetusaurioById(int id)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //agregar usuario
        [HttpPost("Agregar usuario")]
        public IActionResult Addusuario([FromBody] UsuarioVM usuario)
        {
            try
            {
                _usuarioService.AddUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Editar usuario
        [HttpPut("Modificar usuario/{id}")]
        public IActionResult UpdateusuarioById(int id, [FromBody] UsuarioVM usuario)
        {
            try
            {
                var updateusuario = _usuarioService.UpdateUsuarioById(id, usuario);
                return Ok(updateusuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Eliminar usuario
        [HttpDelete("Eliminar usuario/{id}")]
        public IActionResult DeleteUsaurioById(int id)
        {
            try
            {
                _usuarioService.DeleteusuarioById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}