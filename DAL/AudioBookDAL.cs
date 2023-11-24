using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;
using OtherFunction;
using System.IO;
namespace DAL
{
   public class AudioBookDAL
    {
       public static int InsertMaterial(AudioBookEntity oAB)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_InsertMaterial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.Add("idMaterial", SqlDbType.Int).Direction = ParameterDirection.Output;
               sqlcmd.Parameters.Add("idRegEntrada", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idRegEntrada"].Value = oAB.RegEntradaEntity.IdRegEntrada;
               sqlcmd.Parameters.Add("idClasificacion", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idClasificacion"].Value = oAB.ClasificacionEntity.IdClasificacion;
               sqlcmd.Parameters.Add("Nombre", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Nombre"].Value = oAB.Nombre;
               sqlcmd.Parameters.Add("Cantidad",SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Cantidad"].Value = oAB.Cantidad;
               sqlcmd.Parameters.Add("Condicion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Condicion"].Value = oAB.Condicion;
               sqlcmd.Parameters.Add("Fecha_Recep", SqlDbType.DateTime).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Fecha_Recep"].Value = oAB.Fecha_Recep;
               sqlcmd.Parameters.Add("Descripcion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Descripcion"].Value = oAB.Desripcion;
               sqlcmd.Parameters.Add("Prestado", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Prestado"].Value = oAB.Prestado;
               sqlcmd.Parameters.Add("Reservado", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Reservado"].Value = oAB.Reservado;
               sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Estado"].Value = oAB.Estado;
               sqlcmd.Parameters.Add("ImgMaterial", SqlDbType.VarBinary).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["ImgMaterial"].Value = oAB.ImgMaterial;
               sqlcmd.ExecuteNonQuery();
               return Convert.ToInt32(sqlcmd.Parameters["idMaterial"].Value);               
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

       public static bool InsertAudioBook(AudioBookEntity oAB)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_InsertAudioBook";

           try
           {
               cn = oFn.GetConnection();
               oAB.IdMaterial = InsertMaterial(oAB);
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.Add("idMaterial", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idMaterial"].Value = oAB.IdMaterial;
               sqlcmd.Parameters.Add("idAutor", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idAutor"].Value = oAB.AutorEntity.IdAutor;
               sqlcmd.Parameters.Add("Componentes", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Componentes"].Value = oAB.Componentes;
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

       public static DataTable ShowAudiobook()
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_ShowAudiobook";

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
       }

       public static DataTable ShowMaterialAudiobook()
       {
           return oFn.Leer("Sp_ShowMaterialAudiobook");
       }


       public static AudioBookEntity GetAllDataAudioBook(int idAudiobook)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_GetAllDataAudioBook";
           DataTable dt = new DataTable();
           AudioBookEntity oAB = new AudioBookEntity();

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idAudioBook", idAudiobook);
               sqlcmd.ExecuteNonQuery();
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   oAB.IdAudiobook = idAudiobook;
                   oAB.IdMaterial = Convert.ToInt32(dt.Rows[0]["idMaterial"]);
                   oAB.ClasificacionEntity.IdClasificacion = Convert.ToInt32(dt.Rows[0]["idClasificacion"]);
                   oAB.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(dt.Rows[0]["idRegEntrada"]);
                   oAB.AutorEntity.IdAutor = Convert.ToInt32(dt.Rows[0]["idAutor"]);
                   oAB.Nombre = dt.Rows[0]["Nombre"].ToString();
                   oAB.Desripcion = dt.Rows[0]["Descrpcion"].ToString();
                   oAB.Condicion = dt.Rows[0]["Codicion"].ToString();
                   oAB.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                   oAB.ClasificacionEntity.Clasificacion = dt.Rows[0]["Clasificacion"].ToString();
                   oAB.RegEntradaEntity.Origen = dt.Rows[0]["Origen"].ToString();
                   oAB.Componentes = dt.Rows[0]["Componentes"].ToString();
               }
               return oAB;

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

       public static bool UpdateMaterial(MaterialEntity oAB)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_UpdateMaterial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oAB.IdMaterial);
               sqlcmd.Parameters.AddWithValue("idRegEntrada", oAB.RegEntradaEntity.IdRegEntrada);
               sqlcmd.Parameters.AddWithValue("idClasificacion", oAB.ClasificacionEntity.IdClasificacion);
               sqlcmd.Parameters.AddWithValue("Nombre", oAB.Nombre);
               sqlcmd.Parameters.AddWithValue("Descripcion", oAB.Desripcion);
               sqlcmd.Parameters.AddWithValue("Cantidad", oAB.Cantidad);
               sqlcmd.Parameters.AddWithValue("Condicion", oAB.Condicion);
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

       public static bool UpdateAudioBook(AudioBookEntity oAB)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_UpdateAudioBook";

           try
           {
               cn = oFn.GetConnection();

               if (UpdateMaterial(oAB))
               {
                   SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                   cn.Open();
                   sqlcmd.CommandType = CommandType.StoredProcedure;
                   sqlcmd.Parameters.AddWithValue("idAudioBook", oAB.IdAudiobook);
                   sqlcmd.Parameters.AddWithValue("idAutor", oAB.AutorEntity.IdAutor);
                   sqlcmd.Parameters.AddWithValue("Componentes", oAB.Componentes);
                   sqlcmd.ExecuteNonQuery();
               }
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

       public static bool DeleteAudioBook(AudioBookEntity oAB)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_DeleteMaterial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idMaterial", oAB.IdMaterial);
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

       public static AudioBookEntity GetCantidadAudioBook(int idMaterial)
       {
           try
           {
               AudioBookEntity oAB = new AudioBookEntity();
               DataTable dt = new DataTable();
               dt = oFn.Leer("Sp_GetCantidadMaterial " + idMaterial);
               if (dt.Rows.Count > 0)
               {
                   oAB.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                   oAB.Prestado = Convert.ToInt32(dt.Rows[0]["Prestado"]);
                   oAB.Reservado = Convert.ToInt32(dt.Rows[0]["Reservado"]);
                   oAB.Nombre = dt.Rows[0]["Nombre"].ToString();
               }

               return oAB;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public static bool AsignarCantidadPrestadaAudioBooks(AudioBookEntity oAB)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_AsignarCantidadMaterialPrestado";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oAB.IdMaterial);
               sqlcmd.Parameters.AddWithValue("Prestado", oAB.Prestado);
               sqlcmd.ExecuteNonQuery();
               return true;

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static DataTable RptABByClasificacion_Autor(int idAutor, int idClasificacion)
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_RptByCla_Au_Both";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idAutor", idAutor);
               sqlcmd.Parameters.AddWithValue("idCla", idClasificacion);
               sqlcmd.ExecuteNonQuery();
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               return dt;
           }

           catch (Exception ex)
           {
               throw ex;
           }
       }

    }
}
