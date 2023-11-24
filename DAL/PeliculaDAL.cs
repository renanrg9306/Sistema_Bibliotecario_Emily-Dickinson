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
    public class PeliculaDAL
    {
        public static DataTable ShowPelicula()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowPelicula";

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

        public static int InsertMaterial(PeliculaEntity oPelicula)
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
                sqlcmd.Parameters["idRegEntrada"].Value = oPelicula.RegEntradaEntity.IdRegEntrada;
                sqlcmd.Parameters.Add("idClasificacion", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idClasificacion"].Value = oPelicula.ClasificacionEntity.IdClasificacion;
                sqlcmd.Parameters.Add("Nombre", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Nombre"].Value = oPelicula.Nombre;
                sqlcmd.Parameters.Add("Cantidad", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Cantidad"].Value = oPelicula.Cantidad;
                sqlcmd.Parameters.Add("Condicion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Condicion"].Value = oPelicula.Condicion;
                sqlcmd.Parameters.Add("Fecha_Recep", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Fecha_Recep"].Value = oPelicula.Fecha_Recep;
                sqlcmd.Parameters.Add("Descripcion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Descripcion"].Value = oPelicula.Desripcion;
                sqlcmd.Parameters.Add("Prestado", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Prestado"].Value = oPelicula.Prestado;
                sqlcmd.Parameters.Add("Reservado", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Reservado"].Value = oPelicula.Reservado;
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oPelicula.Estado;
                sqlcmd.Parameters.Add("ImgMaterial", SqlDbType.VarBinary).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["ImgMaterial"].Value = oPelicula.ImgMaterial;
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
        public static bool InsertPelicula(PeliculaEntity oPelicula)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertPelicula";
            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                oPelicula.IdMaterial = InsertMaterial(oPelicula);
                sqlcmd.Parameters.AddWithValue("idMaterial", oPelicula.IdMaterial);
                sqlcmd.Parameters.AddWithValue("idGenero", oPelicula.GeneroEntity.IdGenero);
                sqlcmd.Parameters.AddWithValue("idDirector", oPelicula.DirectorEntity.IdDirector);
                sqlcmd.Parameters.AddWithValue("idProtagonista", oPelicula.Protagonista.IdProtagonistra);
                sqlcmd.Parameters.AddWithValue("Duracion", oPelicula.Duracion1);
                sqlcmd.Parameters.AddWithValue("Sinopsis", oPelicula.Sinopsis);
                sqlcmd.Parameters.AddWithValue("Subtitulo", oPelicula.Subtitulo);
                sqlcmd.Parameters.AddWithValue("Anio", oPelicula.Anio);
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

        public static PeliculaEntity GetPelicula(int idPelicula)
        {
            SqlConnection cn = new SqlConnection();
            PeliculaEntity oPel = new PeliculaEntity();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetAllDataPelicula";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idPelicula", idPelicula);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    oPel.IdMaterial = Convert.ToInt32(dt.Rows[0]["idMaterial"]);
                    oPel.Nombre = dt.Rows[0]["Nombre"].ToString();
                    oPel.Sinopsis = dt.Rows[0]["Sinopsis"].ToString();
                    oPel.RegEntradaEntity.IdRegEntrada = Convert.ToInt32(dt.Rows[0]["idRegEntrada"]);
                    oPel.ClasificacionEntity.IdClasificacion = Convert.ToInt32(dt.Rows[0]["idClasificacion"]);
                    oPel.Protagonista.IdProtagonistra = Convert.ToInt32(dt.Rows[0]["idProtagonista"]);
                    oPel.DirectorEntity.IdDirector = Convert.ToInt32(dt.Rows[0]["idDirector"]);
                    oPel.GeneroEntity.IdGenero = Convert.ToInt32(dt.Rows[0]["idGenero"]);
                    oPel.Condicion = dt.Rows[0]["Codicion"].ToString();
                    oPel.Subtitulo = Convert.ToBoolean(dt.Rows[0]["Subtitulo"]);
                    oPel.Duracion1 = dt.Rows[0]["Duracion"].ToString();
                    oPel.Anio = Convert.ToInt32(dt.Rows[0]["Anio"]);
                    oPel.Desripcion =  dt.Rows[0]["Descrpcion"].ToString();
                    oPel.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                }

                return oPel;
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
        public static bool UpdateMaterial(MaterialEntity oPelicula)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdateMaterial";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idMaterial", oPelicula.IdMaterial);
                sqlcmd.Parameters.AddWithValue("idRegEntrada", oPelicula.RegEntradaEntity.IdRegEntrada);
                sqlcmd.Parameters.AddWithValue("idClasificacion", oPelicula.ClasificacionEntity.IdClasificacion);
                sqlcmd.Parameters.AddWithValue("Nombre", oPelicula.Nombre);
                sqlcmd.Parameters.AddWithValue("Descripcion", oPelicula.Desripcion);
                sqlcmd.Parameters.AddWithValue("Cantidad", oPelicula.Cantidad);
                sqlcmd.Parameters.AddWithValue("Condicion", oPelicula.Condicion);
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
        public static bool UpdatePelicula(PeliculaEntity oPel)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdatePelicula";

            try
            {
                if(UpdateMaterial(oPel))
                {
                    cn = oFn.GetConnection();
                    SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    sqlcmd.Parameters.AddWithValue("idPelicula", oPel.IdPelicula);
                    sqlcmd.Parameters.AddWithValue("idGenero", oPel.GeneroEntity.IdGenero);
                    sqlcmd.Parameters.AddWithValue("idDirector", oPel.DirectorEntity.IdDirector);
                    sqlcmd.Parameters.AddWithValue("idProtagonista", oPel.Protagonista.IdProtagonistra);
                    sqlcmd.Parameters.AddWithValue("Duracion", oPel.Duracion1);
                    sqlcmd.Parameters.AddWithValue("Sinopsis", oPel.Sinopsis);
                    sqlcmd.Parameters.AddWithValue("Subtitulo", oPel.Subtitulo);
                    sqlcmd.Parameters.AddWithValue("Anio", oPel.Anio);
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

        public static bool DeletePelicula(PeliculaEntity oPelicula)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_DeleteMaterial";

            try
            {
                cn = oFn.GetConnection();
                cn.Open();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;               
                sqlcmd.Parameters.AddWithValue("idMaterial", oPelicula.IdMaterial);
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

        public static DataTable ShowMaterialPelicula()
        {
            return oFn.Leer("Sp_ShowMaterialPelicula");
        }

        public static PeliculaEntity GetCantidadPelicula(int idMaterial)
        {
            try
            {
                PeliculaEntity oPelicula = new PeliculaEntity();
                DataTable dt = new DataTable();
                dt = oFn.Leer("Sp_GetCantidadMaterial " + idMaterial);
                if (dt.Rows.Count > 0)
                {
                    oPelicula.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                    oPelicula.Prestado = Convert.ToInt32(dt.Rows[0]["Prestado"]);
                    oPelicula.Nombre = dt.Rows[0]["Nombre"].ToString();
                }

                return oPelicula;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool AsignarCantidadPrestadaPelicula(PeliculaEntity oPelicula)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_AsignarCantidadMaterialPrestado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idMaterial", oPelicula.IdMaterial);
                sqlcmd.Parameters.AddWithValue("Prestado", oPelicula.Prestado);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ReportePeliculaxProtagonista(int idProtagonista)
        {
            return oFn.Leer("Sp_ReportePeliculaxProtagonista " + idProtagonista);
        }

        public static DataTable ReportePeliculaxClasificacion(int idClasificacion)
        {
            return oFn.Leer("Sp_ReportePeliculaxClasificacion " + idClasificacion);
        }

        public static DataTable ReportePexClayPro(int idClasificacion, int idProtagonista)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ReportePeliculaxClayPro";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idClasificacion", idClasificacion);
                sqlcmd.Parameters.AddWithValue("idProtagonista", idProtagonista);
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
