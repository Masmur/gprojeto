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

        public ActionResult Edit(int BacklogItemId)
        {

            var backLogItemToEdit = (from m in _model.BacklogItems
                                 where m.BacklogItemId == BacklogItemId
                                 select m).FirstOrDefault();

            ViewData["ProdutoId"] = backLogItemToEdit.ProdutoId;
            return PartialView(backLogItemToEdit);
        }

        //
        // POST: /Backlog/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([Bind(Exclude="Data")]int BacklogItemId, BacklogItem BackLotItemEdited)
        {
            try
            {
                // TODO: Add update logic here

                ViewData["ProdutoId"] = BackLotItemEdited.ProdutoId;
                if (!ModelState.IsValid)
                {
                    return PartialView("List", _model.BacklogItems.Where(p => p.ProdutoId == BackLotItemEdited.ProdutoId));
                }

                _model.BacklogItems.First(p => p.BacklogItemId == BacklogItemId).Nome = BackLotItemEdited.Nome;
                _model.BacklogItems.First(p => p.BacklogItemId == BacklogItemId).Estimativa = BackLotItemEdited.Estimativa;
                _model.BacklogItems.First(p => p.BacklogItemId == BacklogItemId).Nota = BackLotItemEdited.Nota;

                _model.SubmitChanges();

                return PartialView("List", _model.BacklogItems.Where(p => p.ProdutoId == BackLotItemEdited.ProdutoId));
            }
            catch
            {
                return PartialView("List", _model.BacklogItems.Where(p => p.ProdutoId == BackLotItemEdited.ProdutoId));
            }
        }
        //
        // POST: /Backlog/Delete/5
        public ActionResult Delete(int BacklogItemId, int ProdutoId)
        {
            ViewData["ProdutoId"] = ProdutoId;
            _model.BacklogItems.DeleteOnSubmit(_model.BacklogItems.First(p => p.BacklogItemId == BacklogItemId));

            _model.SubmitChanges();

            return PartialView("List", _model.BacklogItems.Where(p => p.BacklogItemId == ProdutoId));
        }
    }
}
