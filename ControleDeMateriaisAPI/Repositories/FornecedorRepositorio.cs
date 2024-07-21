using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeMateriaisAPI.Repositories
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly ControleDeMateriaisContext _context;

        public FornecedorRepositorio(ControleDeMateriaisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fornecedor>> ListaFornecedor()
        {
            return await _context.Fornecedores.ToListAsync();
        }
        public async Task<Fornecedor> BuscaFornecedorPorId(int idFornecedor)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.IdFornecedor == idFornecedor);
            return fornecedor;
        }
        public async Task<bool> CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AtualizarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var findFornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.IdFornecedor == fornecedor.IdFornecedor);
                if (findFornecedor == null)
                {
                    return false;
                }
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var deleteFornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.IdFornecedor == fornecedor.IdFornecedor);
                if (deleteFornecedor == null)
                {
                    return false;
                }
                deleteFornecedor.Status = false;
                _context.Fornecedores.Update(deleteFornecedor);
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
