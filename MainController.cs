using AppCS1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCS1.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tema1()
        {
            return View();
        }
        public JsonResult Info()
        {
            var notas = new Notas[] { new Notas("Ciencias", 90), new Notas("Programacion", 80) };
            return Json(notas, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Show(ContactViewModel contact)
        {
            if (ModelState.IsValid)
                return View(contact);
            else
            {
                ViewBag.error = "faltan datos";
                return View("Tema1", contact);
            }
                
        }
	}
}