using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisAPI.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<Produto>> ListaProduto();
        Task<Produto> BuscaProdutoPorId(int idProduto);
        Task<bool> CadastrarProduto(Produto produto);
        Task<bool> AtualizarProduto(Produto produto);
        Task<bool> DeletarProduto(Produto produto);
    }
}
