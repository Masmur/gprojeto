using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Models
{
    public class ProdutoRepository : IProdutoRepository
    {
        //Cria o contexto do banco.
        private ModelDataContext _modelProduto;

        public ProdutoRepository()
        {
            _modelProduto = new ModelDataContext();
        }

        public IQueryable<Produto> GetAllProdutos(long EmpresaId)
        {
            var query = from produto in _modelProduto.Produtos
                        where produto.EmpresaId == EmpresaId
                        select produto;

            return query.AsQueryable();
        }

        public void DeleteAProduto(long ProdutoId)
        {
            var query = from produto in _modelProduto.Produtos
                        where produto.ProdutoId == ProdutoId
                        select produto;
            _modelProduto.Produtos.DeleteOnSubmit(query.FirstOrDefault());

            _modelProduto.SubmitChanges();
        }

        public void AddProduto(Produto newProduto)
        {
            _modelProduto.Produtos.InsertOnSubmit(newProduto);
            _modelProduto.SubmitChanges();
        }

        public Produto GetProdutoById(long ProdutoId)
        {
            return _modelProduto.Produtos.Where(p => p.ProdutoId == ProdutoId).FirstOrDefault();
        }

        public void EditProduto(Produto ProdutoEdited)
        {
            _modelProduto.Produtos.First(p => p.ProdutoId == ProdutoEdited.ProdutoId).Nome = ProdutoEdited.Nome;

            _modelProduto.SubmitChanges();
        }
    }
}
