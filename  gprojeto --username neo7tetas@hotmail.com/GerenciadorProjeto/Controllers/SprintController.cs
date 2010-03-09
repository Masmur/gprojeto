using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GerenciadorProjeto.Models;
using GerenciadorProjeto.Classes;
using System.Globalization;

namespace GerenciadorProjeto.Controllers
{
    public class SprintController : Controller
    {

        ModelDataContext _model = new ModelDataContext();

        //Repositorio do Sprint.
        private ISprintRepository repSprint;

        // Cria Istancia da classe no contructor.
        public SprintController()
            : this(new SprintRepository())
        {

        }
        
        // Configura estrutura do repositorio para ser ultiilizada.
        public SprintController(ISprintRepository Repository)
        {
            repSprint = Repository;
        }

        //
        // GET: /Sprint/
        public ActionResult Index()
        {
            var AllSprints = repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"]));
            return View(AllSprints);
        }

        //
        // GET: /Sprint/List
        public ActionResult List()
        {
            return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
        }

        //
        // GET: /Sprint/Backlog/5

        public ActionResult SprintBacklog(int SprintId)
        {
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            return View(sprintToDetail);
        }

        //
        // GET: /Sprint/SprintBackLogList
        public ActionResult SprintBackLogList(int SprintId)
        {
            // Retorna lista.
            return PartialView("SprintBackLogList", _model.vSprintBackLogs.Where(p => p.SprintId == SprintId)); 
        }

        //
        // GET: /Sprint/Details/5

        public ActionResult Details(int SprintId)
        {
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            return View(sprintToDetail);
        }

        //
        // GET: /Sprint/Calendario/5

        public ActionResult Calendario(int SprintId)
        {

            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["mes"] = DateTime.Now.Month;
            ViewData["ano"] = DateTime.Now.Year;
            ViewData["titulo"] = sprintToDetail.Objetivo;

            int qtdDias = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            Calendario _calendario = new Calendario();

            for (int i = 0; i < qtdDias; i++)
            {
                DateTime dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i + 1);
                _calendario.Adddia(i + 1, dia.DayOfWeek.ToString());
            }

            ViewData["mes-nome"] = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);

            return View(_calendario);
        }

        public ActionResult Calendar(int SprintId, int ano, int mes)
        {
            
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            ViewData["mes"] = mes;
            ViewData["ano"] = ano;

            int qtdDias = DateTime.DaysInMonth(ano, mes);

            Calendario _calendario = new Calendario();

            for (int i = 0; i < qtdDias; i++)
            {
                DateTime dia = new DateTime(ano,mes, i + 1);
                _calendario.Adddia(i + 1, dia.DayOfWeek.ToString());
            }

            ViewData["mes-nome"] = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);

            return PartialView(_calendario);
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

                repSprint.AddSprint(novoSprint);

                return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
            }
        }

        //
        // GET: /Sprint/Edit/5
 
        public ActionResult Edit(int SprintId)
        {

            var sprintToEdit = repSprint.GetSprintById(SprintId);

            ViewData["EmpresaId"] = sprintToEdit.EmpresaId;

            return PartialView(sprintToEdit);
        }

        //
        // POST: /Sprint/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Sprint SprintEdited)
        {
            try
            {
                // TODO: Add update logic here

                ViewData["EmpresaId"] = SprintEdited.EmpresaId;

                repSprint.EditSprint(SprintEdited);

                return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
            }
        }

        //
        // POST: /Sprint/Delete/5
        public ActionResult Delete(int SprintId)
        {
            repSprint.DeleteASprint(SprintId);

            return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
        }
    }
}
