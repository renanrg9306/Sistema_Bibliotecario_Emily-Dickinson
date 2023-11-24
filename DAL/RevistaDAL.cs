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
    public class RevistaDAL
    {
        public static int InsertMaterial(RevistaEntity oRevista)
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
                sqlcmd.Parameters["idRegEntrada"].Value = oRevista.RegEntradaEntity.IdRegEntrada;
                sqlcmd.Parameters.Add("idClasificacion", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idClasificacion"].Value = oRevista.ClasificacionEntity.IdClasificacion;
                sqlcmd.Parameters.Add("Nombre", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Nombre"].Value = oRevista.Nombre;
                sqlcmd.Parameters.Add("Cantidad", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Cantidad"].Value = oRevista.Cantidad;
                sqlcmd.Parameters.Add("Condicion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Condicion"].Value = oRevista.Condicion;
                sqlcmd.Parameters.Add("Fecha_Recep", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Fecha_Recep"].Value = oRevista.Fecha_Recep;
                sqlcmd.Parameters.Add("Descripcion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Descripcion"].Value = oRevista.Desripcion;
                sqlcmd.Parameters.Add("Prestado", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Prestado"].Value = oRevista.Prestado;
                sqlcmd.Parameters.Add("Reservado", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Reservado"].Value = oRevista.Reservado;
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oRevista.Estado;
                sqlcmd.Parameters.Add("ImgMaterial", SqlDbType.VarBinary).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["ImgMaterial"].Value =  oRevista.ImgMaterial;
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

        public static bool InsertRevista(RevistaEntity oRevista)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertRevista";

            try
            {
                oRevista.IdMaterial = InsertMaterial(oRevista);
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idMaterial", oRevista.IdMaterial);
                sqlcmd.Parameters.AddWithValue("idAutor",oRevista.AutorEntity.IdAutor);
                sqlcmd.Parameters.AddWithValue("idEdicion", oRevista.EdicionEntity.IdEdicion);
                sqlcmd.Parameters.AddWithValue("idEditorial",oRevista.EditorialEntity.IdEditorial);
                sqlcmd.Parameters.AddWithValue("Volumen", oRevista.Volumen);
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

        public static DataTable ShowRevista()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowRevista";

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

        public static DataTable ReporteRevistaxAu(int idAutor)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ReporteRevistaxAu";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
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

        public static DataTable ReporteRevistaxCla(int idClasificacion)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ReporteRevistaxCla";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idClasificacion", idClasificacion);
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

        public static DataTable ReporteRevistaxAuyCla(int idAutor, int idClasificacion)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ReporteRevistaxAuyCla";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idAutor", idClasificacion);
                sqlcmd.Parameters.AddWithValue("idClasificacion", idClasificacion);
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

        public static RevistaEntity GetRevista(int idRevista)
        {
            SqlConnection cn = new SqlConnection();
            RevistaEntity oRevista = new RevistaEntity();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetAllDataRevista";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idRevista", idRevista);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    oRevista.EditorialEntity.IdEditorial = Convert.ToInt32(dt.Rows[0]["idEditorial"]);
                    oRevista.ClasificacionEntity.IdClasificacion = Convert.ToInt32(dt.Rows[0]["idClasificacion"]);
                    oRevista.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(dt.Rows[0]["idRegEntrada"]);
                    oRevista.EdicionEntity.IdEdicion = Convert.ToInt32(dt.Rows[0]["idEdicion"]);
                    oRevista.AutorEntity.IdAutor = Convert.ToInt32(dt.Rows[0]["idAutor"]);
                    oRevista.IdRevista = Convert.ToInt32(dt.Rows[0]["idRevista"]);
                    oRevista.IdMaterial = Convert.ToInt32(dt.Rows[0]["idMaterial"]);
                    oRevista.Nombre = dt.Rows[0]["Nombre"].ToString();
                    oRevista.Desripcion = dt.Rows[0]["Descrpcion"].ToString();
                    oRevista.Volumen = dt.Rows[0]["Volumen"].ToString();
                    oRevista.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                }
                return oRevista;

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

         private static bool UpdateMaterial(MaterialEntity oRevista)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdateMaterial";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idMaterial", oRevista.IdMaterial);
                sqlcmd.Parameters.AddWithValue("idRegEntrada", oRevista.RegEntradaEntity.IdRegEntrada);
                sqlcmd.Parameters.AddWithValue("idClasificacion", oRevista.ClasificacionEntity.IdClasificacion);
                sqlcmd.Parameters.AddWithValue("Nombre", oRevista.Nombre);
                sqlcmd.Parameters.AddWithValue("Descripcion", oRevista.Desripcion);
                sqlcmd.Parameters.AddWithValue("Cantidad", oRevista.Cantidad);
                sqlcmd.Parameters.AddWithValue("Condicion", oRevista.Condicion);
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

         public static bool UpdateRevista(RevistaEntity oRevista)
         {
             SqlConnection cn = new SqlConnection();
             string Sp = "Sp_UpdateRevista";

             try
             {
                 cn = oFn.GetConnection();

                 if (UpdateMaterial(oRevista))
                 {
                     SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                     cn.Open();
                     sqlcmd.CommandType = CommandType.StoredProcedure;
                     sqlcmd.Parameters.AddWithValue("idRevista", oRevista.IdRevista);
                     sqlcmd.Parameters.AddWithValue("idEditorial", oRevista.EditorialEntity.IdEditorial);
                     sqlcmd.Parameters.AddWithValue("idAutor", oRevista.AutorEntity.IdAutor);
                     sqlcmd.Parameters.AddWithValue("idEdicion", oRevista.EdicionEntity.IdEdicion);
                     sqlcmd.Parameters.AddWithValue("Volumen", oRevista.Volumen);           
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

         public static bool DeleteRevista(RevistaEntity oRevista)
         {
             SqlConnection cn = new SqlConnection();
             string Sp = "Sp_DeleteMaterial";

             try
             {
                 cn = oFn.GetConnection();
                 cn.Open();
                 SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 sqlcmd.Parameters.AddWithValue("idMaterial", oRevista.IdMaterial);
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

         public static DataTable ShowMaterialRevista()
         {
             return oFn.Leer("Sp_ShowMaterialRevista");
         }

         public static RevistaEntity GetCantidadRevista(int idMaterial)
         {
             try
             {
                 RevistaEntity oRevista = new RevistaEntity();
                 DataTable dt = new DataTable();
                 dt = oFn.Leer("Sp_GetCantidadMaterial " + idMaterial);
                 if (dt.Rows.Count > 0)
                 {
                     oRevista.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                     oRevista.Prestado = Convert.ToInt32(dt.Rows[0]["Prestado"]);
                     oRevista.Reservado = Convert.ToInt32(dt.Rows[0]["Reservado"]);
                 }

                 return oRevista;
             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }

         public static bool AsignarCantidadPrestadaRevista(RevistaEntity oRevista)
         {
             SqlConnection cn = new SqlConnection();
             string Sp = "Sp_AsignarCantidadMaterialPrestado";

             try
             {
                 cn = oFn.GetConnection();
                 SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                 sqlcmd.CommandType = CommandType.StoredProcedure;
                 cn.Open();
                 sqlcmd.Parameters.AddWithValue("idMaterial", oRevista.IdMaterial);
                 sqlcmd.Parameters.AddWithValue("Prestado", oRevista.Prestado);
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
