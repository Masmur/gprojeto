using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> GetAllProdutos(int EmpresaId);
        void DeleteAProduto(int ProdutoId);
        void AddProduto(Produto NewProduto);
        void EditProduto(Produto ProdutoEdited);
        Produto GetProdutoById(int ProdutoId);
    }
}
