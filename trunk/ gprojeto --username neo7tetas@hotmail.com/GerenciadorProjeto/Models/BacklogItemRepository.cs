using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Models
{
    public class BacklogItemRepository : IBacklogRepository
    {
        //Cria o contexto do banco.
        private ModelDataContext _modelBacklogItem;

        public BacklogItemRepository()
        {
            _modelBacklogItem = new ModelDataContext();
        }

        public IQueryable<BacklogItem> GetAllBacklogItens(long ProdutoId)
        {
            var query = from backlogItem in _modelBacklogItem.BacklogItems
                        where backlogItem.ProdutoId == ProdutoId
                        select backlogItem;

            return query.AsQueryable();
        }

        public void DeleteABaklogItem(long BacklogItemId, long ProdutoId)
        {
            var query = from backlogItem in _modelBacklogItem.BacklogItems
                        where backlogItem.BacklogItemId == BacklogItemId
                        select backlogItem;
            _modelBacklogItem.BacklogItems.DeleteOnSubmit(query.FirstOrDefault());

            _modelBacklogItem.SubmitChanges();
        }

        public void AddBacklogItem(BacklogItem NewBacklogItem)
        {
            _modelBacklogItem.BacklogItems.InsertOnSubmit(NewBacklogItem);
            _modelBacklogItem.SubmitChanges();
        }

        public void EditBacklogItem(BacklogItem BacklogItemEdited)
        {
            _modelBacklogItem.BacklogItems.First(p => p.BacklogItemId == BacklogItemEdited.BacklogItemId).Nome = BacklogItemEdited.Nome;
            _modelBacklogItem.BacklogItems.First(p => p.BacklogItemId == BacklogItemEdited.BacklogItemId).Estimativa = BacklogItemEdited.Estimativa;
            _modelBacklogItem.BacklogItems.First(p => p.BacklogItemId == BacklogItemEdited.BacklogItemId).Nota = BacklogItemEdited.Nota;

            _modelBacklogItem.SubmitChanges();
        }

        public BacklogItem GetBaklogItemById(long BacklogItemId)
        {
            return _modelBacklogItem.BacklogItems.Where(p => p.BacklogItemId == BacklogItemId).FirstOrDefault();
        }

        public Produto GetProdutoById(long ProdutoId)
        {
            return _modelBacklogItem.Produtos.Where(p => p.ProdutoId == ProdutoId).FirstOrDefault();
        }

    }
}
