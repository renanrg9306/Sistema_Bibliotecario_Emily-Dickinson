using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;
using OtherFunction;
namespace DAL
{
    public class ClasificacionDAL
    {
        public static int InsertClasificacion(ClasificacionEntity oCla)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertClasificacion";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idClasificacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("Clasificacion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Clasificacion"].Value = oCla.Clasificacion;
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oCla.Estado;
                sqlcmd.Parameters.Add("Descripcion", SqlDbType.VarChar,100).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Descripcion"].Value = oCla.Descripcion;
                sqlcmd.ExecuteNonQuery();
                return Convert.ToInt32(sqlcmd.Parameters["idClasificacion"].Value);
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

        public static ClasificacionEntity GetClasificacionById(int idClasificacion)
        {
            SqlConnection cn = new SqlConnection();
            ClasificacionEntity oCla = new ClasificacionEntity();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetClasificacionById";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idClasificacion", idClasificacion);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                    if(dt.Rows.Count>0)
                    {
                        //oCla.IdClasificacion = Convert.ToInt32(dt.Rows[0]["idClasificacion"]);
                        oCla.Clasificacion = dt.Rows[0]["Clasificacion"].ToString();
                        oCla.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    }
                    return oCla;
                
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

        public static bool DeleteClasificacion(ClasificacionEntity oCla)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_DeleteClasificacion";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp,cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idClasificacion", oCla.IdClasificacion);
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

        public static DataTable GetClasificacion(int idClasificacion)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetClasificacion";

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
            finally
            {
                cn.Close();
            }
        }

        public static DataTable ShowClasificacion()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowClasificacion";

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

        public static DataTable SearchClasificacion(string Clasificacion)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_SearchClasificacion";
            DataTable dt = new DataTable();

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("Clasificacion", Clasificacion);
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

        public static bool UpdateClasificacion(ClasificacionEntity oCla)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdateClasificacion";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idClasificacion", oCla.IdClasificacion);
                sqlcmd.Parameters.AddWithValue("Clasificacion", oCla.Clasificacion);
                sqlcmd.Parameters.AddWithValue("Descripcion", oCla.Descripcion);
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
