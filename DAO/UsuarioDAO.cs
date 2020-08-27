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

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM Usuarios WHERE Email = {0}",email), conn.cnn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(ds);
            var existeEmail = ds.Tables[0].Rows.Count;
                if (existeEmail > 0)
                    return true;
                else
                    return false;

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