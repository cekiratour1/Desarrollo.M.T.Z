using DesarrolloMTZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesarrolloMTZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Desarrollo_MTZ_MV desarrollo_MTZ)
        {
            if (desarrollo_MTZ != null)
            {
                if (desarrollo_MTZ.datosI != null)
                {
                    var logica = new Logica.LogicaMTZ();

                    var result = logica.Calcular(desarrollo_MTZ);
                   
                    return View(result);
                }
                
            }
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}