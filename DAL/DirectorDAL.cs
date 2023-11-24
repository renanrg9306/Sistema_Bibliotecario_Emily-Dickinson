using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;
using OtherFunction;

namespace DAL
{
    public class DirectorDAL
    {
        public static DataTable ShowDirector()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowDirector";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool InsertDirector(DirectorEntity oDirec)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertDirector";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("NombreDirector", oDirec.NombreDirector);
                sqlcmd.Parameters.AddWithValue("ApellidoDirector",oDirec.ApellidosDirector);
                sqlcmd.Parameters.AddWithValue("Estado", oDirec.Estado);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
