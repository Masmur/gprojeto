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
            return View();
        }

        //
        // POST: /Produto/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int ProdutoId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
