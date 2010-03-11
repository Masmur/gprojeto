using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface IBacklogRepository
    {
        IQueryable<BacklogItem> GetAllProdutos(int EmpresaId);
        void DeleteABaklogItem(int ProdutoId);
        void AddBacklogItem(BacklogItem NewProduto);
        void EditBacklogItem(BacklogItem ProdutoEdited);
        Produto GetBaklogItemById(int ProdutoId);
    }
}
