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
        // Objeto que faz interação com o banco.
        ModelDataContext _model = new ModelDataContext();

        //
        // GET: /Colaborador/

        public ActionResult Index()
        {
            // Retorna lista.
            return PartialView(_model.Colaboradors.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }

        //
        // GET: /Colaborador/List
        public ActionResult List()
        {
            // Retorna lista.
            return PartialView("List", _model.Colaboradors.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
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
                _model.Colaboradors.InsertOnSubmit(novoColaborador);

                _model.SubmitChanges();

                return PartialView("List", _model.Colaboradors.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", _model.Colaboradors.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
        }

        //
        // GET: /Colaborador/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Colaborador/Edit/5

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

        //
        // POST: /Colaborador/Delete/5
        public ActionResult Delete(int ColaboradorId)
        {
            _model.Colaboradors.DeleteOnSubmit(_model.Colaboradors.First(p => p.ColaboradorId == ColaboradorId));

            _model.SubmitChanges();

            return PartialView("List", _model.Colaboradors.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }
    }
}
