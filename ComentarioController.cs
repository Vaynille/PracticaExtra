using AppCS1.Filter;
using AppCS1.Model;
using AppCS1.Negocio;
using AppCS1.Services;
using AppCS1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCS1.Controllers
{
    public class ComentarioController : Controller
    {   
     
             [LoginFilter]
             public ActionResult ListadoComentarios()
             {
                 DbConnection conn = new DbConnection();
                 ViewBag.Nombre = ((UsuarioModel)Request.RequestContext.HttpContext.Session["user"]).Nombre;
                 var listacomentarios = conn.Comentarios;
                 return View(listacomentarios);
             }
        /*Buscar Comentario por letra*/
             public JsonResult Buscar(string termino)
             {
                 DbConnection conn = new DbConnection();
                 var resut = conn.BuscarComentario(termino);

                 return Json(resut, JsonRequestBehavior.AllowGet);
             }
     
        /*Nuevo Buscar los comentarios por idUsuarios*/
                public JsonResult BuscaridUser(int iduser)
                {
                    DbConnection conn = new DbConnection();
                    var resultadoid = conn.BusquedadidUser(iduser);
                    return Json(resultadoid, JsonRequestBehavior.AllowGet);
                }

                /*poner todos los usuarios en el select o combo*/
                public JsonResult BuscarUsuario()
                {

                    DbConnection conn = new DbConnection();
                    var resultadoUsuario = conn.BusquedaUsuarios();
                    return Json(resultadoUsuario, JsonRequestBehavior.AllowGet);
                }

            [HttpPost]
            [LoginFilter]
          public ActionResult GuardarComentario(ComentarioModel Coment)
          {
              Coment.IdUsuario = ((UsuarioModel)Request.RequestContext.HttpContext.Session["user"]).IdUsuario;
              DbConnection conn = new DbConnection();
              conn.InsertComentario(Coment);
              ViewBag.message = "Comentario Guardado";
              return RedirectToAction("ListadoComentarios");
          }

	}
}