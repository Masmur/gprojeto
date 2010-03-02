using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;

namespace GerenciadorProjeto.Controllers
{
    public class SprintController : Controller
    {
        // Objeto que faz interação com o banco.
        ModelDataContext _model = new ModelDataContext();

        //
        // GET: /Sprint/

        public ActionResult Index()
        {
            // Retorna lista de sprints vinculados a empresa.
            return View(_model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }

        //
        // GET: /Sprint/List
        public ActionResult List()
        {
            // Retorna lista.
            return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }

        //
        // GET: /Sprint/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Sprint/Create

        public ActionResult Create(int EmpresaId)
        {
            ViewData["EmpresaId"] = EmpresaId;
            return PartialView("Create");
        } 

        //
        // POST: /Sprint/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude="SprintId, Data")]Sprint novoSprint)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["EmpresaId"] = novoSprint.EmpresaId;
                _model.Sprints.InsertOnSubmit(novoSprint);

                _model.SubmitChanges();

                return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
        }

        //
        // GET: /Sprint/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Sprint/Edit/5

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
