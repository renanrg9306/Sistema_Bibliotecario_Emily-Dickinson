using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;
using OtherFunction;

namespace BLL
{
    public class EdicionDAL
    {

        public static int InsertAnio(EdicionEntity oEdicion)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertAnio";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.Add("idAnio", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("Anio", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Anio"].Value = oEdicion.AnioEntity.Anio;
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oEdicion.AnioEntity.Estado;
                sqlcmd.ExecuteNonQuery();
                return Convert.ToInt32(sqlcmd.Parameters["idAnio"].Value);
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

        public static bool InsertEdicion(EdicionEntity oEdicion)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertEdicion";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                oEdicion.AnioEntity.IdAnio = InsertAnio(oEdicion);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                //sqlcmd.Parameters.Add("idEdicion", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("idAnio",SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idAnio"].Value = oEdicion.AnioEntity.IdAnio;
                sqlcmd.Parameters.Add("Edicion", SqlDbType.VarChar,80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Edicion"].Value = oEdicion.Edicion;
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oEdicion.Estado;
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

        public static DataTable ShowEdicion()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowEdicion";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataAdapter da= new SqlDataAdapter(sqlcmd);
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
