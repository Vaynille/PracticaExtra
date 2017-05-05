using AppCS1.Model;
using AppCS1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCS1.Negocio
{
    public class ComentarioManager
    {
        public static IEnumerable<ComentarioViewModel> GetComentarios()
        {
            var db = new DbConnection();

            var comentarios = db.Get<ComentarioViewModel>
                ("select * from getComentarios()");

            return comentarios;
        }


        //public static ComentarioModel comentario(string coment, int idUsuario)
        //{
        //    var db = new DbConnection();
        ////    var comentario = db.Comentarios
        
        //}


       


    }
}
