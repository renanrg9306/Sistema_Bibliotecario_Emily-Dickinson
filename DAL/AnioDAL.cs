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
   public class AnioDAL
    {

       public static DataTable ShowAnio()
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_ShowAnio";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
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

     
    }
}
