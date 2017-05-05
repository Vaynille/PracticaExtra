using AppCS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCS1.Negocio
{
    public class LoginManager
    {
        public static UsuarioModel Login(string user, string password)
        {
            var db = new DbConnection();

            var usuario = db.Usuarios.FirstOrDefault(x=>x.Email.Equals(user) 
                && x.Password.Equals(password));

            return usuario;
        }
    }
}
