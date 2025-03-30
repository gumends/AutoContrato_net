using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoContrato_net.Context;
using AutoContrato_net.DTO;
using AutoContrato_net.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoContrato_net.Service
{
    public class LocatarioService
    {

        private readonly AppDbContext _context;

        public LocatarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Locatario>> GetAllLocatarios(bool status, string nome, int page, int pageSize)
        {
            var u = _context.Locatarios
            .Where(p => p.Status == status && p.Nome.Contains(nome))
            .Include(p => p.Propriedade);

            int totalItems = await u.CountAsync();
            var locatarios = await u
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<Locatario>(locatarios, totalItems, page, pageSize);
        }

        public async Task<Locatario> CreateLocatario(LocatarioDTO locatarioDTO)
        {
            Locatario l = new Locatario();

            l.Nome = locatarioDTO.Nome;
            l.Rg = locatarioDTO.Rg;
            l.Cpf = locatarioDTO.Cpf;
            l.Nascimento = locatarioDTO.Nascimento;
            if (locatarioDTO.PropriedadeId.HasValue)
            {
                l.PropriedadeId = locatarioDTO.PropriedadeId.Value;
            }

            _context.Locatarios.Add(l);

            await _context.SaveChangesAsync();

            return l;
        }

        public async Task<Locatario> GetOneLocatario(Guid id)
        {
            return await _context.Locatarios.FindAsync(id);
        }

        public async Task<Locatario> UpdateLocatario(LocatarioDTO locatarioDTO, Guid id)
        {
            var l = await _context.Locatarios.FindAsync(id);
            if (l == null) return null;

            l.Nome = locatarioDTO.Nome;
            l.Rg = locatarioDTO.Rg;
            l.Cpf = locatarioDTO.Cpf;
            l.Nascimento = locatarioDTO.Nascimento;
            if (locatarioDTO.PropriedadeId.HasValue)
            {
                l.PropriedadeId = locatarioDTO.PropriedadeId.Value;
            }

            _context.Locatarios.Update(l);
            await _context.SaveChangesAsync();

            return l;
        }

        public async Task<string> DesativarLocatario(Guid id)
        {
            var l = await _context.Locatarios.FindAsync(id);

            l.Status = !l.Status;
            
            await _context.SaveChangesAsync();

            return "Status do locatário alterado com sucesso";
        }
    }
}