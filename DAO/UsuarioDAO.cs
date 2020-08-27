using PharmaCO_MVC.DB;
using PharmaCO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCO_MVC.DAO
{
    public class UsuarioDAO
    {
        public static bool VerificaEmail(string email)
        {
            DBConnection conn = new DBConnection();
            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM Usuarios WHERE Email = '{0}'", email), conn.cnn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(ds);
            var existeEmail = ds.Tables[0].Rows.Count;
            if (existeEmail > 0)
                return true;
            else
                return false;

        }
        public static Usuario VerificaLogin(string login, string senha)
        {
            DBConnection conn = new DBConnection();
            DataSet ds = new DataSet();
            Usuario usuario = null;

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM Usuarios WHERE Usuario = '{0}' AND Senha = '{1}'", login, senha), conn.cnn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(ds);
            var existelogin = ds.Tables[0].Rows.Count;
            if (existelogin > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                usuario = new Usuario();
                usuario.UsuarioId = Convert.ToInt32(dr["UsuarioId"].ToString());
                usuario.Nome = dr["Nome"].ToString();
                usuario.Idade = Convert.ToInt32(dr["Idade"].ToString());
                usuario.Login = dr["Usuario"].ToString();
                usuario.Senha = dr["Senha"].ToString();
                usuario.Email = dr["Email"].ToString();
            }

            return usuario;

        }
        public static void InsertUsuario(Usuario usuario)
        {
            DBConnection conn = new DBConnection();

            SqlCommand cmd = new SqlCommand("InsertUsuario", conn.cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 50).Value = usuario.Nome;
            cmd.Parameters.Add("@Idade", SqlDbType.Int, 50).Value = usuario.Idade;
            cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario.Login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 50).Value = usuario.Senha;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = usuario.Email;

            cmd.ExecuteNonQuery();
        }
    }
}