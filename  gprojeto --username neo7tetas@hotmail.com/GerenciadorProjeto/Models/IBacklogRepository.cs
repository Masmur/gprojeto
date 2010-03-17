using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface IBacklogRepository
    {
        IQueryable<BacklogItem> GetAllBacklogItens(long BacklogItemId);
        void DeleteABaklogItem(long BacklogItemId, long ProdutoId);
        void AddBacklogItem(BacklogItem NewBacklogItem);
        void EditBacklogItem(BacklogItem BacklogItemEdited);
        BacklogItem GetBaklogItemById(long BacklogItemId);
        Produto GetProdutoById(long ProdutoId);
    }
}
