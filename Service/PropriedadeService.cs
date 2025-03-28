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
    public class PropriedadeService
    {
        private readonly AppDbContext _context;

        public PropriedadeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Propriedade>> GetAllPropriedades(bool status, string rua, int page, int pageSize)
        {
            var p = _context.Propriedades
            .Where(p => p.Status == status && p.Rua.Contains(rua))
            .Include(p => p.Proprietario)
            .Include(p => p.Locatario);

            int totalItems = await p.CountAsync();
            var propriedades = await p
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<Propriedade>(propriedades, totalItems, page, pageSize);
        }


        public async Task<Propriedade> CreatePropriedade(PropriedadeDTO propriedade){
            Propriedade p = new Propriedade();

            p.Rua = propriedade.Rua;
            p.Numero = propriedade.Numero;
            p.NumCasa = propriedade.NumCasa;
            p.Bairro = propriedade.Bairro;
            p.Cep = propriedade.Cep;
            p.Localizacao = propriedade.Localizacao;
            if (propriedade.ProprietarioId.HasValue)
            {
                p.ProprietarioId = propriedade.ProprietarioId.Value;
            }

            _context.Propriedades.Add(p);
            await _context.SaveChangesAsync();

            return p;
        }
    }
}