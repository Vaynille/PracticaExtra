using AppCS1.Filter;
using AppCS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCS1.Controllers
{
    public class ActualizarUserController : Controller
    {
        //
        // GET: /ActualizarUser/
        [LoginFilter]
        public ActionResult updateU()
        { 
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult updateU(UsuarioModel user)
        {
            
            user.IdUsuario = ((UsuarioModel)Request.RequestContext.HttpContext.Session["user"]).IdUsuario;
            DbConnection conn = new DbConnection();
            conn.ActulizarUsuario(user);
            ViewBag.message = "Datos Actualizados";
            return View();
        }


	}
}

