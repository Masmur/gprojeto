using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;

namespace GerenciadorProjeto.Controllers
{
    public class BacklogTaskController : Controller
    {

        //Repositorio do produto.
        private IBacklogTaskRepository repBacklogTask;

        // Cria Istancia da classe no contructor.
        public BacklogTaskController()
            : this(new BacklogTaskRepository())
        {

        }

        // Configura estrutura do repositorio para ser ultiilizada.
        public BacklogTaskController(IBacklogTaskRepository Repository)
        {
            repBacklogTask = Repository;
        }

        //
        // GET: /BacklogTask/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BacklogTask/List/5

        public ActionResult List(long BacklogItemId)
        {
            ViewData["BacklogItemId"] = BacklogItemId;
            return PartialView("List", repBacklogTask.GetAllBacklogTasks(BacklogItemId));
        }

        //
        // GET: /BacklogTask/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BacklogTask/Create

        public ActionResult Create(long BacklogItemId)
        {
            ViewData["BacklogItemId"] = BacklogItemId;
            return PartialView("Create");
        } 

        //
        // POST: /BacklogTask/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "BacklogTaskId")]BacklogTask novoBaklogTask)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["BacklogItemId"] = novoBaklogTask.BacklogItemId;

                repBacklogTask.AddBacklogTask(novoBaklogTask);

                return PartialView("List", repBacklogTask.GetAllBacklogTasks(novoBaklogTask.BacklogItemId));
            }
            catch
            {
                return PartialView("List", repBacklogTask.GetAllBacklogTasks(novoBaklogTask.BacklogItemId));
            }
        }

        //
        // GET: /BacklogTask/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BacklogTask/Edit/5

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
        // POST: /BacklogTask/Delete/5
        public ActionResult Delete(long BacklogTaskId, long BacklogItemId)
        {
            ViewData["BacklogItemId"] = BacklogItemId;

            repBacklogTask.DeleteABacklogTask(BacklogTaskId, BacklogItemId);

            return PartialView("List", repBacklogTask.GetAllBacklogTasks(BacklogItemId));
        }


    }
}
