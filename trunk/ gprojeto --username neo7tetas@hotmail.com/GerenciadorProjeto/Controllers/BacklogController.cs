using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;

namespace GerenciadorProjeto.Controllers
{
    public class BacklogController : Controller
    {
        // Objeto que faz interação com o banco.
        ModelDataContext _model = new ModelDataContext();

        //
        // GET: /Backlog/

        public ActionResult Index(int ProdutoId)
        {
            // Retorna Backlog do produto.
            var produtoToDetail = _model.Produtos.Where(p => p.ProdutoId == ProdutoId).First();
            ViewData["ProdutoId"] = ProdutoId;
            ViewData["titulo"] = produtoToDetail.Nome;
            return View(_model.BacklogItems.Where(p => p.ProdutoId == ProdutoId));
        }

        //
        // GET: /Backlog/List/5

        public ActionResult List(int ProdutoId)
        {
            // Retorna Backlog do produto.
            ViewData["ProdutoId"] = ProdutoId;
            return PartialView("List",_model.BacklogItems.Where(p => p.ProdutoId == ProdutoId));
        }

        //
        // GET: /Backlog/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Backlog/Create

        public ActionResult Create(int ProdutoId)
        {
            ViewData["ProdutoId"] = ProdutoId;
            return PartialView("Create");
        } 

        //
        // POST: /Backlog/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(BacklogItem novoBackLogItem)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["ProdutoId"] = novoBackLogItem.ProdutoId;
                _model.BacklogItems.InsertOnSubmit(novoBackLogItem);

                _model.SubmitChanges();

                return PartialView("List", _model.BacklogItems.Where(p => p.ProdutoId == novoBackLogItem.ProdutoId));
            }
            catch
            {
                return PartialView("List", _model.BacklogItems.Where(p => p.ProdutoId == novoBackLogItem.ProdutoId));
            }
        }

        //
        // GET: /Backlog/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Backlog/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
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
