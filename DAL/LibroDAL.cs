using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OtherFunction;
using Entity;

namespace DAL
{
   public class LibroDAL
    {

       public static int InsertMaterial(LibroEntity oLibro)
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
               sqlcmd.Parameters["idRegEntrada"].Value = oLibro.RegEntradaEntity.IdRegEntrada;
               sqlcmd.Parameters.Add("idClasificacion", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idClasificacion"].Value = oLibro.ClasificacionEntity.IdClasificacion;
               sqlcmd.Parameters.Add("Nombre", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Nombre"].Value = oLibro.Nombre;
               sqlcmd.Parameters.Add("Cantidad", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Cantidad"].Value = oLibro.Cantidad;
               sqlcmd.Parameters.Add("Condicion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Condicion"].Value = oLibro.Condicion;
               sqlcmd.Parameters.Add("Fecha_Recep", SqlDbType.DateTime).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Fecha_Recep"].Value = oLibro.Fecha_Recep;
               sqlcmd.Parameters.Add("Descripcion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Descripcion"].Value = oLibro.Desripcion;
               sqlcmd.Parameters.Add("Prestado", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Prestado"].Value = oLibro.Prestado;
               sqlcmd.Parameters.Add("Reservado", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Reservado"].Value = oLibro.Reservado;
               sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["Estado"].Value = oLibro.Estado;
               sqlcmd.Parameters.Add("ImgMaterial", SqlDbType.VarBinary).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["ImgMaterial"].Value = oLibro.ImgMaterial;
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

       public static bool InsertLibro(LibroEntity oLibro)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_InsertLibro";

           try
           {
               cn = oFn.GetConnection();
               oLibro.IdMaterial = InsertMaterial(oLibro);
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.Add("idMaterial", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idMaterial"].Value = oLibro.IdMaterial;
               sqlcmd.Parameters.Add("idEditorial", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idEditorial"].Value = oLibro.EditorialEntity.IdEditorial;
               sqlcmd.Parameters.Add("idAutor", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idAutor"].Value = oLibro.AutorEntity.IdAutor;
               sqlcmd.Parameters.Add("idEdicion", SqlDbType.Int).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["idEdicion"].Value = oLibro.EdicionEntity.IdEdicion;
               sqlcmd.Parameters.Add("ISBN", SqlDbType.VarChar,80).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["ISBN"].Value = oLibro.ISBN;
               sqlcmd.Parameters.Add("CuentaconCD", SqlDbType.Bit).Direction = ParameterDirection.Input;
               sqlcmd.Parameters["CuentaconCD"].Value = oLibro.CuentaConCD;
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
           string Sp = "Sp_ShowLibros";

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

       public static LibroEntity GetLibro(int idLibro)
       {
           SqlConnection cn = new SqlConnection();
           LibroEntity oLibro = new LibroEntity();
           DataTable dt = new DataTable();
           string Sp = "Sp_GetAllDataLibro";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idLibro", idLibro);
               sqlcmd.ExecuteNonQuery();
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {

                   oLibro.EditorialEntity.IdEditorial = Convert.ToInt32(dt.Rows[0]["idEditorial"]);
                   oLibro.ClasificacionEntity.IdClasificacion = Convert.ToInt32(dt.Rows[0]["idClasificacion"]);
                   oLibro.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(dt.Rows[0]["idRegEntrada"]);
                   oLibro.EdicionEntity.IdEdicion = Convert.ToInt32(dt.Rows[0]["idEdicion"]);
                   oLibro.AnioEntity.IdAnio = Convert.ToInt32(dt.Rows[0]["idAnio"]);
                   oLibro.AutorEntity.IdAutor = Convert.ToInt32(dt.Rows[0]["idAutor"]);
                   oLibro.IdLibro = Convert.ToInt32(dt.Rows[0]["idLibro"]);
                   oLibro.IdMaterial = Convert.ToInt32(dt.Rows[0]["idMaterial"]);
                   oLibro.Nombre = dt.Rows[0]["Nombre"].ToString();
                   //oLibro.ClasificacionEntity.Clasificacion = dt.Rows[0]["Clasificacion"].ToString();
                   //oLibro.EditorialEntity.Editorial = dt.Rows[0]["Editorial"].ToString();
                   //oLibro.EdicionEntity.Edicion = dt.Rows[0]["idEdicion"].ToString();
                   //oLibro.AnioEntity.Anio = Convert.ToInt32(dt.Rows[0]["Anio"]);
                   oLibro.Desripcion = dt.Rows[0]["Descrpcion"].ToString();
                   oLibro.ISBN = dt.Rows[0]["ISBN"].ToString();
                   oLibro.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);                  
               }
               return oLibro;

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

       public static bool UpdateMaterial(MaterialEntity oLibro)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_UpdateMaterial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oLibro.IdMaterial);
               sqlcmd.Parameters.AddWithValue("idRegEntrada", oLibro.RegEntradaEntity.IdRegEntrada);
               sqlcmd.Parameters.AddWithValue("idClasificacion", oLibro.ClasificacionEntity.IdClasificacion);
               sqlcmd.Parameters.AddWithValue("Nombre", oLibro.Nombre);
               sqlcmd.Parameters.AddWithValue("Descripcion", oLibro.Desripcion);
               sqlcmd.Parameters.AddWithValue("Cantidad", oLibro.Cantidad);
               sqlcmd.Parameters.AddWithValue("Condicion", oLibro.Condicion);
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

       public static bool UpdateLibro(LibroEntity oLibro)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_UpdateLibro";

           try
           {
               cn = oFn.GetConnection();

               if (UpdateMaterial(oLibro))
               {
                   SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                   cn.Open();
                   sqlcmd.CommandType = CommandType.StoredProcedure;
                   sqlcmd.Parameters.AddWithValue("idLibro", oLibro.IdLibro);
                   sqlcmd.Parameters.AddWithValue("idEditorial", oLibro.EditorialEntity.IdEditorial);
                   sqlcmd.Parameters.AddWithValue("idAutor",oLibro.AutorEntity.IdAutor);
                   sqlcmd.Parameters.AddWithValue("idEdicion",oLibro.EdicionEntity.IdEdicion);
                   sqlcmd.Parameters.AddWithValue("ISBN", oLibro.ISBN);
                   sqlcmd.Parameters.AddWithValue("CuentaconCD", oLibro.CuentaConCD);
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

       public static bool DeleteLibro(LibroEntity oLibro)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_DeleteMaterial";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idMaterial", oLibro.IdMaterial);
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

       public static DataTable ShowMaterialLibro()
       {
           return oFn.Leer("Sp_ShowMaterialLibro");
       }

       public static LibroEntity GetCantidadLibro(int idMaterial)
       {
           try
           {
               LibroEntity oLibro = new LibroEntity();
               DataTable dt = new DataTable();
               dt = oFn.Leer("Sp_GetCantidadMaterial "+idMaterial);
               if (dt.Rows.Count > 0)
               {
                   oLibro.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                   oLibro.Prestado = Convert.ToInt32(dt.Rows[0]["Prestado"]);
                   oLibro.Nombre = dt.Rows[0]["Nombre"].ToString();
               }

               return oLibro;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       
       }

       public static bool AsignarCantidadPrestadaLibro(LibroEntity oLibro)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_AsignarCantidadMaterialPrestado";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idMaterial", oLibro.IdMaterial);
               sqlcmd.Parameters.AddWithValue("Prestado", oLibro.Prestado);
               sqlcmd.ExecuteNonQuery();
               return true;

           }
           catch (Exception ex)
           {
               throw ex;
           }


       
       }

       public static bool VerificarMatrialISBN(int idLibro,string ISBN)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_VerificarISBNLibro";
           DataTable dt = new DataTable();
           bool Valor = true;


           try
           {

               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idLibro", idLibro);
               sqlcmd.Parameters.AddWithValue("ISBN", ISBN);
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               int cantidad = dt.Rows.Count;
               if (cantidad > 0)
               {
                   Valor = false;

               }
               return Valor;
           }
           catch (Exception ex)
           {
               throw ex;
           }

           finally {
               cn.Close();
           }
       }

       public static DataTable ReporteLibroxAutor(int idAutor)
       {
           return oFn.Leer("Sp_ReporteLibroxAutor " + idAutor);
       }

       public static DataTable ReporteLibroxClasificacion(int idClasificacion)
       {
           return oFn.Leer("Sp_ReporteLibroxClasificacion " + idClasificacion);
       }

       public static DataTable ReporteLibroxClayAutor(int idClasificacion, int idAutor)
       {
           SqlConnection cn = new SqlConnection();
           DataTable dt = new DataTable();
           string Sp = "Sp_ReporteLibroxClasificacionyAutor";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idClasificacion", idClasificacion);
               sqlcmd.Parameters.AddWithValue("idAutor", idAutor);
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
