using AppCS1.Filter;
using AppCS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCS1.Controllers
{
    public class CrearUsuarioController : Controller
    {
        //
        // GET: /CrearUsuario/
        public ActionResult CrearUser()
        {
            return View();
        }

       [HttpPost]
        public ActionResult CrearUser(UsuarioModel user)
        {
           DbConnection conn= new DbConnection();
           conn.CrearUsuario(user);
           ViewBag.message = "Usuario Registrado";
            return View();
        }
        [HttpGet]
       public JsonResult VerificarDisponibilidad(string email)
       {
           var db = new DbConnection();

           var usuario = db.BuscarPorEmail(email);

           return Json(new { Existe = usuario != null, Mensaje = "Ejecucion exitosa" }, JsonRequestBehavior.AllowGet);
       }
	}
}