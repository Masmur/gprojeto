using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;

namespace GerenciadorProjeto.Controllers
{
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Empresa/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Empresa/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Empresa/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Produto novoProduto)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Empresa/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Empresa/Edit/5

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
