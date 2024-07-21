using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisAPI.Interfaces
{
    public interface IServicoRepositorio
    {
        Task<IEnumerable<Servico>> ListaServico();
        Task<Servico> BuscarServicoPorId(int idServico);
        Task<bool> CadastrarServico(Servico servico);
        Task<bool> AtualizarServico(Servico servico);
        Task<bool> DeletarServico(Servico servico);
    }
}
