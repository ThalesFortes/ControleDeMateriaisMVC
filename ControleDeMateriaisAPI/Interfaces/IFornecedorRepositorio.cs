using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisAPI.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<IEnumerable<Fornecedor>> ListaFornecedor();
        Task<Fornecedor> BuscaFornecedorPorId(int idFornecedor);
        Task<bool> CadastrarFornecedor(Fornecedor fornecedor);
        Task<bool> AtualizarFornecedor(Fornecedor fornecedor);
        Task<bool> DeletarFornecedor(Fornecedor fornecedor);
    }
}
