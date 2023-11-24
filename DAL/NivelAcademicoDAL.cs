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
    public class NivelAcademicoDAL
    {
        public static DataTable ShowNivelAcad()
        {
            return oFn.ShowNivelAcademico("Sp_ShowNivelAca");
        }

        public static DataTable GetNivelAca(int idNivelAca)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_GetNivelAca";
            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idNivelAca", idNivelAca);
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

        public static bool InsertNivelAca(NivelAcademicoEntity oNivelAca)
        { 
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertNivelAca";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("Descripcion",oNivelAca.NivelAca);
                sqlcmd.Parameters.AddWithValue("Estado", oNivelAca.Estado);
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

        public static NivelAcademicoEntity GetNivelAcaById(int pidNivelAca)
        {
            NivelAcademicoEntity oNivelAca = new NivelAcademicoEntity();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_GetNivelAcaById";
            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("idNivelAca", pidNivelAca);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    oNivelAca.IdNivelAca = pidNivelAca;
                    oNivelAca.NivelAca = dt.Rows[0]["Descripcion"].ToString(); ;
                }
                return oNivelAca;

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

        public static bool ActualizarNivelAca(NivelAcademicoEntity oNivelAca)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdateNivelAca";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idNivelAca", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idNivelAca"].Value = oNivelAca.IdNivelAca;
                sqlcmd.Parameters.Add("NivelAca", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["NivelAca"].Value = oNivelAca.NivelAca.ToString();
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

        public static bool DeleteNivelAca(NivelAcademicoEntity oNivelAca)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_DeleteNivelAca";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idNivelAca",oNivelAca.IdNivelAca);
                sqlcmd.Parameters.AddWithValue("Estado", oNivelAca.Estado);
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
