using pruebahotel.Data.ViewModels;
using pruebahotel.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace pruebahotel.Data.Services
{
    public class UsuarioServices
    {
        private AppDbContext _context;
        public UsuarioServices(AppDbContext context)
        {
            _context = context;
        }
        //agregar
        public void AddUsuario(UsuarioVM usuario)
        {
            var _usuario = new Usuario()
            {
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                NumTel = usuario.NumTel,
                rol = usuario.rol,
                password = usuario.password
            };
            _context.usuarios.Add(_usuario);
            _context.SaveChanges();
        }
        //listar
        public List<Usuario> GetUsuarios() => _context.usuarios.ToList();
        //bustar
        public Usuario GetUsuarioById(int idusuario) => _context.usuarios.FirstOrDefault(n => n.id_usuario == idusuario);
        //editar
        public Usuario UpdateUsuarioById(int idusuario, UsuarioVM usuario)
        {
            var _usuario = _context.usuarios.FirstOrDefault(n => n.id_usuario == idusuario);
            if (_usuario != null)
            {
                _usuario.nombre = usuario.nombre;
                _usuario.apellido = usuario.apellido;
                _usuario.NumTel = usuario.NumTel;
                _usuario.rol = usuario.rol;
                _usuario.password = usuario.password;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("El usuario no se puede modificar!");
            }
            return _usuario;
        }
        //eliminar
        public void DeleteusuarioById(int idusuario)
        {
            var _usuario = _context.usuarios.FirstOrDefault(n => n.id_usuario == idusuario);
            if (_usuario != null)
            {
                _context.usuarios.Remove(_usuario);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El usuario con el id {idusuario} no existe!");
            }
        }
    }
}
