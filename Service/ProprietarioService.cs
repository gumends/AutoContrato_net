using AutoContrato_net.Context;
using AutoContrato_net.DTO;
using AutoContrato_net.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoContrato_net.Service
{
    public class ProprietarioService
    {
        private readonly AppDbContext _context;

        public ProprietarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Proprietario>> GetAllProprietarios(bool status, string nome, int page, int pageSize)
        {
            var u = _context.Proprietarios.Where(p => p.Status == status && p.Nome.Contains(nome));

            int totalItems = await u.CountAsync();
            var proprietarios = await u
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<Proprietario>(proprietarios, totalItems, page, pageSize);
        }

        public async Task<Proprietario> CriarProprietario(ProprietarioDTO proprietarioDTO){
            Proprietario proprietario = new Proprietario();

            proprietario.Nome = proprietarioDTO.Nome;
            proprietario.Cpf = proprietarioDTO.Cpf;
            proprietario.Nascimento = proprietarioDTO.Nascimento;
            proprietario.Rg = proprietarioDTO.Rg;
            proprietario.Nacionalidade = proprietarioDTO.Nacionalidade;

            await _context.AddAsync(proprietario);
            await _context.SaveChangesAsync();
            return proprietario;
        }

        public async Task<Proprietario> GetOneProprietario(Guid id){
            return await _context.Proprietarios.FindAsync(id);
        }

        public async Task<Proprietario> UpdateProprietario(ProprietarioDTO proprietarioDTO, Guid id){
            var p = await _context.Proprietarios.FindAsync(id);
            if (p == null) return null;

            p.Nome = proprietarioDTO.Nome;
            p.Cpf = proprietarioDTO.Cpf;
            p.Nascimento = proprietarioDTO.Nascimento;
            p.Rg = proprietarioDTO.Rg;
            p.Nacionalidade = proprietarioDTO.Nacionalidade;

            _context.Proprietarios.Update(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<string> DesativarProprietario(Guid id){
            var p = await _context.Proprietarios.FindAsync(id);
            p.Status = !p.Status;
            
            _context.Proprietarios.Update(p);
            await _context.SaveChangesAsync();
            return "Status do proprietário alterado com sucesso";
        }

    }
}