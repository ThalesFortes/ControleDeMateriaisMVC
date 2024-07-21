using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;

namespace ControleDeMateriaisAPI.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ControleDeMateriaisContext _context;

        public ProdutoRepositorio(ControleDeMateriaisContext context)
        {
            _context = context;
        }
    }
    
}
