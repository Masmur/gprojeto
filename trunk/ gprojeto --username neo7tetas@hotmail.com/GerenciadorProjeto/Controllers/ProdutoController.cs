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
       
        //Repositorio do produto.
        private IProdutoRepository repProduto;

        // Cria Istancia da classe no contructor.
        public ProdutoController()
            : this(new ProdutoRepository())
        {

        }

        // Configura estrutura do repositorio para ser ultiilizada.
        public ProdutoController(IProdutoRepository Repository)
        {
            repProduto = Repository;
        }

        //
        // GET: /Produto/
        public ActionResult Index()
        {
            var AllProdutos = repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"]));
            return View(AllProdutos);
        }

        //
        // GET: /Produto/List
        public ActionResult List()
        {
            return PartialView("List", repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
        }

        //
        // GET: /Produto/Details/5
        public ActionResult Details(int ProdutoId)
        {
            var produtoToDetail = repProduto.GetProdutoById(ProdutoId);
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

                repProduto.AddProduto(novoProduto);

                return PartialView("List", repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
            }
        }

        //
        // GET: /Produto/Edit/5
        public ActionResult Edit(int ProdutoId)
        {
            var produtoToEdit = repProduto.GetProdutoById(ProdutoId);

            ViewData["EmpresaId"] = produtoToEdit.EmpresaId;

            return PartialView(produtoToEdit);
        }

        //
        // POST: /Produto/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Produto produtoEdited)
        {
            try
            {
                // TODO: Add update logic here
                ViewData["EmpresaId"] = produtoEdited.EmpresaId;
                repProduto.EditProduto(produtoEdited);

                return PartialView("List", repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
            }
        }

        //
        // POST: /Produto/Delete/5
        public ActionResult Delete(int ProdutoId)
        {
            repProduto.DeleteAProduto(ProdutoId);
            return PartialView("List", repProduto.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
        }
    }
}
