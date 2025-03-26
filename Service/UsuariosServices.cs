using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.Context;
using AutoContrato_net.DTO;
using AutoContrato_net.Model;

namespace AutoContrato_net.Service
{
    public class UsuariosServices
    {
        private readonly UsuarioContext _context;

        public UsuariosServices(UsuarioContext context)
        {
            _context = context;
        }

        public Usuario CadastraUsuario(UsuarioDTO u){
            Usuario usuario = new Usuario();
            usuario.Id = Guid.NewGuid();
            usuario.CPF = u.CPF;
            usuario.Email = u.Email;
            usuario.Senha = u.Senha;
            usuario.Role = u.Role;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public List<Usuario> findAllUsuarios(){
            return _context.Usuarios.ToList();
        }

        public Usuario FindById(Guid id){
            return _context.Usuarios.Find(id);
        }

        public Usuario AlterarUsuario(UsuarioDTO u, Guid id){
            var usuario = _context.Usuarios.Find(id);

            usuario.Nome = u.Nome;
            usuario.CPF = u.CPF;
            usuario.Email = u.Email;
            usuario.Senha = u.Senha;
            usuario.Role = u.Role;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}