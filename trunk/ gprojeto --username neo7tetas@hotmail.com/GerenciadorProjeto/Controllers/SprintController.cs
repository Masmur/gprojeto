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
        // GET: /Sprint/ListProduto/5
        public ActionResult ListProduto(long EmpresaId, long SprintId)
        {
            ViewData["SpritId"] = SprintId;
            return PartialView("ListProduto", repSprint.GetAllProdutos(Convert.ToInt32(Session["EmpresaId"])));
        }


        //
        // GET: /Sprint/Backlog/5
        public ActionResult SprintBacklog(long SprintId)
        {
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            return View(sprintToDetail);
        }

        //
        // GET: /Sprint/SprintBackLogList
        public ActionResult SprintBackLogList(long SprintId)
        {
            return PartialView("SprintBackLogList", repSprint.ListSprintBacklog(SprintId)); 
        }

        //
        // GET: /Sprint/ProdutoBackLogList
        public ActionResult ProdutoBackLogList(long ProdutoId, long SprintId)
        {
            ViewData["SprintId"] = SprintId;
            return PartialView("ProdutoBackLogList", repSprint.ListProdutoBacklog(ProdutoId));
        }

        //
        // GET: /Sprint/Details/5
        public ActionResult Details(long SprintId)
        {
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            return View(sprintToDetail);
        }

        //
        // GET: /Sprint/BackLogItemNaoPlanejado/5
        public ActionResult BackLogItemNaoPlanejado(long SprintId)
        {
            // Retornar o Sprint informado no cabeçalho da função.
            var sprintToDetail = repSprint.GetSprintById(SprintId);
            ViewData["SprintId"] = SprintId;
            ViewData["titulo"] = sprintToDetail.Objetivo;
            return View(sprintToDetail);
        }

        //
        // GET: /Sprint/Calendario/5
        public ActionResult Calendario(long SprintId)
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

        public ActionResult Calendar(long SprintId, int ano, int mes)
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

        public ActionResult Create(long EmpresaId)
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
        public ActionResult Delete(long SprintId)
        {
            repSprint.DeleteASprint(SprintId);

            return PartialView("List", repSprint.GetAllSprints(Convert.ToInt32(Session["EmpresaId"])));
        }

        //
        // POST: /Sprint/AdicionarBackLogItem/5
        public ActionResult AdicionarBackLogItem(long SprintId, long BackLogItemId, long ProdutoId)
        {
            repSprint.AddToSprint(SprintId, BackLogItemId);
            ViewData["SprintId"] = SprintId;

            return PartialView("ProdutoBackLogList", repSprint.ListProdutoBacklog(ProdutoId));
        }

        //
        // POST: /Sprint/RemoverBackLogItem/5
        public ActionResult RemoverBackLogItem(long SprintId, long BacklogItemId)
        {
            repSprint.RemoveBackLogItem(BacklogItemId);

            return PartialView("SprintBackLogList", repSprint.ListSprintBacklog(SprintId)); 
        }

    }
}
