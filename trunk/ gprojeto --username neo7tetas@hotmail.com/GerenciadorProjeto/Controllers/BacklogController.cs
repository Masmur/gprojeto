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
        //Repositorio do produto.
        private IBacklogRepository repBackLogItem;

        // Cria Istancia da classe no contructor.
        public BacklogController()
            : this(new BacklogItemRepository())
        {

        }

        // Configura estrutura do repositorio para ser ultiilizada.
        public BacklogController(IBacklogRepository Repository)
        {
            repBackLogItem = Repository;
        }

        //
        // GET: /Backlog/

        public ActionResult Index(int ProdutoId)
        {
            // Retorna Backlog do produto.
            var produtoToDetail = repBackLogItem.GetProdutoById(ProdutoId);
            ViewData["ProdutoId"] = ProdutoId;
            ViewData["titulo"] = produtoToDetail.Nome;

            var AllProdutos = repBackLogItem.GetAllBacklogItens(ProdutoId);
            return View(AllProdutos);
        }

        //
        // GET: /Backlog/List/5

        public ActionResult List(int ProdutoId)
        {
            // Retorna Backlog do produto.
            ViewData["ProdutoId"] = ProdutoId;
            return PartialView("List", repBackLogItem.GetAllBacklogItens(ProdutoId));
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

                repBackLogItem.AddBacklogItem(novoBackLogItem);

                return PartialView("List", repBackLogItem.GetAllBacklogItens(novoBackLogItem.ProdutoId));
            }
            catch
            {
                return PartialView("List", repBackLogItem.GetAllBacklogItens(novoBackLogItem.ProdutoId));
            }
        }

        //
        // GET: /Backlog/Edit/5

        public ActionResult Edit(long BacklogItemId)
        {

            var backLogItemToEdit = repBackLogItem.GetBaklogItemById(BacklogItemId);

            ViewData["ProdutoId"] = backLogItemToEdit.ProdutoId;
            return PartialView(backLogItemToEdit);
        }

        //
        // POST: /Backlog/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([Bind(Exclude="Data")] BacklogItem BackLogItemEdited)
        {
            try
            {
                // TODO: Add update logic here

                ViewData["ProdutoId"] = BackLogItemEdited.ProdutoId;
                if (!ModelState.IsValid)
                {
                    return PartialView("List", repBackLogItem.GetAllBacklogItens(BackLogItemEdited.ProdutoId));
                }

                repBackLogItem.EditBacklogItem(BackLogItemEdited);

                return PartialView("List", repBackLogItem.GetAllBacklogItens(BackLogItemEdited.ProdutoId));
            }
            catch
            {
                return PartialView("List", repBackLogItem.GetAllBacklogItens(BackLogItemEdited.ProdutoId));
            }
        }

        //
        // POST: /Backlog/Delete/5
        public ActionResult Delete(long BacklogItemId, long ProdutoId)
        {
            ViewData["ProdutoId"] = ProdutoId;

            repBackLogItem.DeleteABaklogItem(BacklogItemId, ProdutoId);

            return PartialView("List", repBackLogItem.GetAllBacklogItens(ProdutoId));
        }
    }
}
