using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.Context;
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

        public Usuario CadastraUsuario(Usuario usuario){
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
}