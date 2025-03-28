using AutoContrato_net.Context;
using AutoContrato_net.DTO;
using AutoContrato_net.Model;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AutoContrato_net.Service
{
    public class UsuariosServices
    {
        private readonly AppDbContext _context;

        public UsuariosServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CadastraUsuario(UsuarioDTO u)
        {
            Usuario usuario = new Usuario();

            usuario.Id = Guid.NewGuid();
            usuario.CPF = u.CPF;
            usuario.Email = u.Email;
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(u.Senha);
            usuario.Role = u.Role;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<PagedList<Usuario>> FindAllUsuarios(int page, int pageSize)
        {
            var u = _context.Usuarios;

            int totalItems = await u.CountAsync();
            var users = await u
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PagedList<Usuario>(users, totalItems, page, pageSize);
        }


        public async Task<Usuario> FindById(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> UpdateUsuario(UsuarioDTO u, Guid id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return null;
            }

            usuario.Nome = u.Nome;
            usuario.CPF = u.CPF;
            usuario.Email = u.Email;
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(u.Senha);
            usuario.Role = u.Role;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<PagedList<Usuario>> FindByNome(string nome, int page, int pageSize)
        {
            var u = _context.Usuarios.Where(u => u.Nome.Contains(nome));

            int totalItems = await u.CountAsync();
            var users = await u
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<Usuario>(users, totalItems, page, pageSize);
        }

        public async Task<string> ExcluirUsuario(Guid id)
        {
            var usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return "Usuário excluído com sucesso";
        }
    }
}