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
        // GET: /Sprint/Backlog/5

        public ActionResult SprintBacklog(int SprintId)
        {
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = _model.Sprints.Where(p => p.SprintId == SprintId).First();
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
            var sprintToDetail = _model.Sprints.Where(p => p.SprintId == SprintId).First();
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            return View(sprintToDetail);
        }

        //
        // GET: /Sprint/Calendario/5

        public ActionResult Calendario(int SprintId)
        {

            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = _model.Sprints.Where(p => p.SprintId == SprintId).First();
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
            var sprintToDetail = _model.Sprints.Where(p => p.SprintId == SprintId).First();
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
 
        public ActionResult Edit(int SprintId)
        {
            var sprintToEdit = (from m in _model.Sprints
                                 where m.SprintId == SprintId
                                 select m).FirstOrDefault();

            ViewData["EmpresaId"] = sprintToEdit.EmpresaId;

            return PartialView(sprintToEdit);
        }

        //
        // POST: /Sprint/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int SprintId, Sprint SprintEdited)
        {
            try
            {
                // TODO: Add update logic here

                ViewData["EmpresaId"] = SprintEdited.EmpresaId;
                if (!ModelState.IsValid)
                {
                    return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
                }

                _model.Sprints.First(p => p.SprintId == SprintId).Objetivo = SprintEdited.Objetivo;

                _model.SubmitChanges();

                return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
            catch
            {
                return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
            }
        }

        //
        // POST: /Sprint/Delete/5
        public ActionResult Delete(int SprintId)
        {
            _model.Sprints.DeleteOnSubmit(_model.Sprints.First(p => p.SprintId == SprintId));

            _model.SubmitChanges();

            return PartialView("List", _model.Sprints.Where(p => p.EmpresaId == Convert.ToInt64(Session["EmpresaId"])));
        }
    }
}
