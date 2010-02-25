using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorProjeto.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            // Configura tempariamente o funcionamento da ferramenta para projetos vinculados a empresa "1".
            Session["EmpresaId"] = 1;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
