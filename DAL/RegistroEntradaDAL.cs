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
   public class RegistroEntradaDAL
    {
       public static bool InsertRegEntrada(RegEntradaEntity oRegE)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_InsertRegEntrada";
           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("Origen", oRegE.Origen);
               sqlcmd.Parameters.AddWithValue("Estado", oRegE.Estado);
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

       public static bool UpdateRegEntrada(RegEntradaEntity oRegE)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_UpdateRegEntrada";
           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idRegEntrada", oRegE.IdRegEntrada);
               sqlcmd.Parameters.AddWithValue("Origen", oRegE.Origen);
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

       public static RegEntradaEntity GetRegEntradaById(int idRegEntrada)
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_GetRegEntradaById";
           RegEntradaEntity oRegEn = new RegEntradaEntity();
           try
           {
               cn = oFn.GetConnection();          
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idRegEntrada", idRegEntrada);
               sqlcmd.ExecuteNonQuery();
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   oRegEn.IdRegEntrada = Convert.ToInt32(dt.Rows[0]["idRegEntrada"]);
                   oRegEn.Origen = dt.Rows[0]["Origen"].ToString();
               }
               return oRegEn;
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

       public static DataTable GetRegEntrada(int idRegEntrada)
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_GetRegEntrada";
           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idRegEntrada", idRegEntrada);
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

       public static bool DeleteRegEntrada(RegEntradaEntity oRegEn)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_DeleteRegEntrada";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idRegEntrada", oRegEn.IdRegEntrada);
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

       public static DataTable ShowRegEntrada()
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_ShowRegEntrada";

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

    }
}
