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
   public class MaterialDAL
    {
       public static bool ActualizarExistenciaMaterial(MaterialEntity oMaterial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_UpdatePrestadoRe";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oMaterial.IdMaterial);
               sqlcmd.Parameters.AddWithValue("Prestado", oMaterial.Prestado);
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
       public static byte[] MostrarImagen (int idMaterial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_GetImagenMaterial";
           byte[] Imagen = {0};
           DataTable dt = new DataTable();
           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", idMaterial);
               sqlcmd.ExecuteNonQuery();
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   Imagen = (byte[])dt.Rows[0]["ImgMaterial"];
               }
               

               return Imagen;

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

       public static bool AsignarReservacion (MaterialEntity oMaterial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_AsignarReservacion";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oMaterial.IdMaterial);
               sqlcmd.Parameters.AddWithValue("Reservado", oMaterial.Reservado);
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


       public static bool EntregarReservacion(MaterialEntity oMaterial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_EntregarReservacion";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oMaterial.IdMaterial);
               sqlcmd.Parameters.AddWithValue("Reservado", oMaterial.Reservado);
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

       public static DataTable ShowMaterial()
       {
           return oFn.Leer("Sp_ShowMaterial");
       }


       public static MaterialEntity GetCantidaMaterial(int idMaterial)
       {
           try
           {
               MaterialEntity oMaterial = new MaterialEntity();
               DataTable dt = new DataTable();
               dt = oFn.Leer("Sp_GetCantidadMaterial " + idMaterial);
               if (dt.Rows.Count > 0)
               {
                   oMaterial.IdMaterial = idMaterial;
                   oMaterial.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                   oMaterial.Prestado = Convert.ToInt32(dt.Rows[0]["Prestado"]);
                   oMaterial.Reservado = Convert.ToInt32(dt.Rows[0]["Reservado"]);
                   oMaterial.Nombre = dt.Rows[0]["Nombre"].ToString();
               }

               return oMaterial;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public static bool AsignarCantidadPrestadaMaterial(MaterialEntity oMaterial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_AsignarCantidadMaterialPrestado";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oMaterial.IdMaterial);
               sqlcmd.Parameters.AddWithValue("Prestado", oMaterial.Prestado);
               sqlcmd.ExecuteNonQuery();
               return true;

           }
           catch (Exception ex)
           {
               throw ex;
           }



       }



       public static bool ActualizarImgMaterial(MaterialEntity oMaterial)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_ActualizarImgMaterial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oMaterial.IdMaterial);
               sqlcmd.Parameters.AddWithValue("ImgMaterial", oMaterial.ImgMaterial);
               sqlcmd.ExecuteNonQuery();
               return true;

           }
           catch (Exception ex)
           {
               throw ex;
           }



       }

    }
}
