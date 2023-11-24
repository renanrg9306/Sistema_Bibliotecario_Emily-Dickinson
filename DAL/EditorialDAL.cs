using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OtherFunction;
using BLL;
using Entity;


namespace BLL
{
   public class EditorialDAL
    {
       public static DataTable GetEditorial(int idEditorial)
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_GetEditorial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idEditorial", idEditorial);
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
       public static DataTable ShowEditorial()
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_ShowEditorial";

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

       public static bool InsertEditorial(EditorialEntity oEditorial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_InsertEditorial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("Editorial", oEditorial.Editorial);
               sqlcmd.Parameters.AddWithValue("Estado", oEditorial.Estado);
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
