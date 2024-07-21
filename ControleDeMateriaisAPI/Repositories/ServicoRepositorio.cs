using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeMateriaisAPI.Repositories
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private readonly ControleDeMateriaisContext _context;

        public ServicoRepositorio(ControleDeMateriaisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servico>> ListaServico()
        {
            return await _context.Servicos.ToListAsync();
        }

        public async Task<Servico> BuscarServicoPorId(int idServico)
        {
            var servico = await _context.Servicos.FirstOrDefaultAsync(x => x.IdServico == idServico);
            return servico;
        }

        public async Task<bool> CadastrarServico(Servico servico)
        {
            try
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AtualizarServico(Servico servico)
        {
            try
            {
                var findServico = await _context.Servicos.FirstOrDefaultAsync(x => x.IdServico == servico.IdServico);
                if (findServico == null)
                {
                    return false;
                }
                _context.Add(findServico);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarServico(Servico servico)
        {
            try
            {
                var deleteServico = await _context.Servicos.FirstOrDefaultAsync(x => x.IdServico == servico.IdServico);
                if (deleteServico == null)
                {
                    return false;
                }
                _context.Servicos.Remove(deleteServico);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
         

        }
    }
}
