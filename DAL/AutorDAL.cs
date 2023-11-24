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
    public class AutorDAL
    {

        public static bool InsertAutor(AutorEntity oAutor)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertAutor";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("Nombre", oAutor.NombreAutor);
                sqlcmd.Parameters.AddWithValue("Apellido", oAutor.ApellidoAutor);
                sqlcmd.Parameters.AddWithValue("Estado", oAutor.Estado);
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

        public static DataTable GetAutor(int idAutor)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetAutor";

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
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteAutor(AutorEntity oAutor)
        {
            SqlConnection cn = new SqlConnection();
            
            string Sp = "Sp_DeleteAutor";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idAutor", oAutor.IdAutor);
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


        public static AutorEntity GetAutorById(int idAutor)
        {
            SqlConnection cn = new SqlConnection();
            AutorEntity oAutor = new AutorEntity();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetAutorById";

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
                if (dt.Rows.Count > 0)
                {
                    oAutor.NombreAutor = dt.Rows[0]["NombreAutor"].ToString();
                    oAutor.ApellidoAutor = dt.Rows[0]["ApellidoAutor"].ToString();
                }
                return oAutor;
              
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


        public static bool UpdateAutor(AutorEntity oAutor)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_UpdateAutor";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idAutor",oAutor.IdAutor);
                sqlcmd.Parameters.AddWithValue("NombreAutor", oAutor.NombreAutor);
                sqlcmd.Parameters.AddWithValue("ApellidoAutor", oAutor.ApellidoAutor);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
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

        public static DataTable ShowAutor()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowAutores";

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
