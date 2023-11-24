using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using OtherFunction;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProgramDAL
    {
        public static bool InsertProgram(ProgramEntity oProgram)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertProgram";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("Descripcion",oProgram.Descripcion);
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

        public static DataTable ShowProgram()
        {
            return oFn.Leer("Sp_ShowProgram"); 
        }

    }
}
