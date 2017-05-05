using AppCS1.Negocio;
using AppCS1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCS1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Entrar(LoginViewModel login)
        {
            var validar = LoginManager.Login(login.user, login.password);

            if (validar != null)
            {/*accion, contrlador*/
                Request.RequestContext.HttpContext.Session.Add("user", validar);
                return RedirectToAction("ListadoComentarios", "comentario");
            }
            else
            {
                ViewBag.Message = "Usuario o contraseña incorrectos";
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            Request.RequestContext.HttpContext.Session["user"] = null;
            return RedirectToAction("Index");
        }
	}
}