using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace AppCS1.Model
{
    public class DbConnection
    {
        private IDbConnection connection;
        public DbConnection()
        {
            connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PagWeb;Data Source=.");
        }
        public IEnumerable<UsuarioModel> Usuarios
        {
            get
            {
                return connection.Query<UsuarioModel>("SELECT * FROM Usuario");
            }
        }
        public IEnumerable<ComentarioModel> BuscarComentario(string termino)
        {
            return connection.Query<ComentarioModel>("select * from Comentarios where Comentario like '%' + @comentario + '%'", new { comentario = termino });
            
        }

        /*busquedad para el select usuarios*/
        public IEnumerable<UsuarioModel> BusquedaUsuarios()
        {

            return connection.Query<UsuarioModel>("select * from Usuario");

        }

        /*Busquedad por id usuarios*/
        public IEnumerable<ComentarioModel> BusquedadidUser(int termino)
        {
            return connection.Query<ComentarioModel>("select * from Comentarios where IdUsuario like @Idusuario", new { Idusuario = termino });
        }

        public IEnumerable<ComentarioModel> Comentarios
        {
            get
            {
                return connection.Query<ComentarioModel>("SELECT * FROM Comentarios");
            }
        }
    
        public void InsertComentario(ComentarioModel comentario) {
            connection.Execute
                ("INSERT INTO Comentarios(Comentario, IdUsuario) VALUES(@Comentario,@IdUsuario)", comentario);
        }

        public void CrearUsuario(UsuarioModel usuario)
        {
            connection.Execute
                ("insert into usuario(Email,Password) values(@Email,@Password)", usuario);
        }

        public void ActulizarUsuario(UsuarioModel actUser)
        {
            connection.Execute("update usuario set Nombre=@nombre,Apellido=@apellido,Telefono=@telefono,Email=@email,Password=@password", actUser);
        }

        public UsuarioModel BuscarPorEmail(string email)
        {
            return connection.Query<UsuarioModel>("SELECT top 1 * FROM Usuario where Email = @Email", new { Email=email }).FirstOrDefault();
        }
        public IEnumerable<T> Get<T>(string query)
        {
            return connection.Query<T>(query);
        }




    }
}
