﻿using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisAPI.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<IEnumerable<Estoque>> ListaEstoque();
        Task<Estoque> BuscaEstoquePorId(int idEstoque);
        Task<bool> CadastrarEstoque(Estoque estoque);
        Task<bool> AtualizarEstoque(Estoque estoque);
    }
}