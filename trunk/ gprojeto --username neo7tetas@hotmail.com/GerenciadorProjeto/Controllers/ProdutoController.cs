using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;

namespace GerenciadorProjeto.Controllers
{
    public class ProdutoController : Controller
    {
        // Objeto que faz interação com o banco.
        ModelDataContext _model = new ModelDataContext();

        //
        // GET: /Produto/

        public ActionResult Index()
        {
            // Retorna lista de projetos da empresa na sessão.
            return View(_model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }

        //
        // GET: /Produto/List
        public ActionResult List()
        {
            // Retorna lista de projetos da empresa na sessão.
            return PartialView("List",_model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }

        //
        // GET: /Produto/Details/5

        public ActionResult Details(int ProdutoId)
        {
            // Retornar o Produto informado no cabeçalho da função.
            var produtoToDetail = _model.Produtos.Where(p => p.ProdutoId == ProdutoId).First();
            ViewData["ProdutoId"] = ProdutoId;
            ViewData["titulo"] = produtoToDetail.Nome;
            return View(produtoToDetail);
        }

        //
        // GET: /Produto/Create

        public ActionResult Create(int EmpresaId)
        {
            ViewData["EmpresaId"] = EmpresaId;
            return PartialView("Create");
        } 

        //
        // POST: /Produto/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude="ProdutoId, Data")]Produto novoProduto)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["EmpresaId"] = novoProduto.EmpresaId;
                _model.Produtos.InsertOnSubmit(novoProduto);

                _model.SubmitChanges();

                return PartialView("List", _model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", _model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
        }

        //
        // GET: /Produto/Edit/5
 
        public ActionResult Edit(int ProdutoId)
        {
            var produtoToEdit =  (from m in _model.Produtos
                                 where m.ProdutoId == ProdutoId
                                 select m).FirstOrDefault();

            ViewData["EmpresaId"] = produtoToEdit.EmpresaId;

            return PartialView(produtoToEdit);
        }

        //
        // POST: /Produto/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int produtoId, Produto produtoEdited)
        {
            try
            {
                // TODO: Add update logic here

                ViewData["EmpresaId"] = produtoEdited.EmpresaId;
                if (!ModelState.IsValid)
                {
                    return PartialView("List", _model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
                }

                _model.Produtos.First(p => p.ProdutoId == produtoId).Nome = produtoEdited.Nome;

                _model.SubmitChanges();

                return PartialView("List", _model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", _model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
        }

        //
        // POST: /Produto/Delete/5
        public ActionResult Delete(int ProdutoId)
        {
            _model.Produtos.DeleteOnSubmit(_model.Produtos.First(p => p.ProdutoId == ProdutoId));

            _model.SubmitChanges();

            return PartialView("List", _model.Produtos.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }
    }
}
