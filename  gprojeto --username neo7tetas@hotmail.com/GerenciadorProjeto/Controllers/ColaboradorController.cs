using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;

namespace GerenciadorProjeto.Controllers
{
    public class ColaboradorController : Controller
    {

        //Repositorio do produto.
        private IColaboradorRepository repColaborador;

        // Cria Istancia da classe no contructor.
        public ColaboradorController()
            : this(new ColaboradorRepository())
        {

        }

        // Configura estrutura do repositorio para ser ultiilizada.
        public ColaboradorController(IColaboradorRepository Repository)
        {
            repColaborador = Repository;
        }


        //
        // GET: /Colaborador/

        public ActionResult Index()
        {
            var AllColaboradores = repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"]));
            return View(AllColaboradores);
        }

        //
        // GET: /Colaborador/List
        public ActionResult List()
        {
            return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
        }

        //
        // GET: /Colaborador/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Colaborador/Create

        public ActionResult Create(int EmpresaId)
        {
            ViewData["EmpresaId"] = EmpresaId;
            return PartialView("Create");
        } 

        //
        // POST: /Colaborador/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "ColaboradorId")]Colaborador novoColaborador)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["EmpresaId"] = novoColaborador.EmpresaId;

                repColaborador.AddColaborador(novoColaborador);

                return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
            }
        }

        //
        // GET: /Colaborador/Edit/5
 
        public ActionResult Edit(int ColaboradorId)
        {
            var colaboradorToEdit = repColaborador.GetColaboradorById(ColaboradorId);
            ViewData["EmpresaId"] = colaboradorToEdit.EmpresaId;

            return PartialView(colaboradorToEdit);
        }

        //
        // POST: /Colaborador/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Colaborador ColaboradorEdited)
        {
            try
            {
                // TODO: Add update logic here

                ViewData["EmpresaId"] = ColaboradorEdited.EmpresaId;
                if (!ModelState.IsValid)
                {
                    return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
                }

                repColaborador.EditColaborador(ColaboradorEdited);

                return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
            }
        }

        //
        // POST: /Colaborador/Delete/5
        public ActionResult Delete(int ColaboradorId)
        {
            repColaborador.DeleteAColaborador(ColaboradorId);
            return PartialView("List", repColaborador.GetAllColaboradores(Convert.ToInt32(Session["EmpresaId"])));
        }
    }
}
