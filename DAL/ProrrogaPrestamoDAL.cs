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
    public class ProrrogaPrestamoDAL
    {
        public static bool PrimeraProrroga(ProrrogaPrestamoEntity oProrroga)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_PrimerProrroga";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.Add("idProrroga", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idProrroga"].Value = oProrroga.IdProrroga;
                sqlcmd.Parameters.Add("Prorroga", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Prorroga"].Value = Convert.ToDateTime(oProrroga.Prorroga1).ToString("yyyy/MM/dd");
                sqlcmd.Parameters.Add("CantidadProrroga", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["CantidadProrroga"].Value = oProrroga.CantidadProrroga;
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

        public static bool SegundaProrroga(ProrrogaPrestamoEntity oProrroga)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_SegundaProrroga";
            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idProrroga", oProrroga.IdProrroga);
                sqlcmd.Parameters.AddWithValue("Prorroga2", oProrroga.Prorroga2);
                sqlcmd.Parameters.AddWithValue("CantidadProrroga", oProrroga.CantidadProrroga);
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



        public static ProrrogaPrestamoEntity GetIdProrrogaC(int idEntregaPrestamo)
        {
            try
            {
                ProrrogaPrestamoEntity oProrroga = new ProrrogaPrestamoEntity();
                DataTable dt = new DataTable();
                dt = oFn.Leer("Sp_GetProrrogaValues " + idEntregaPrestamo);
                if (dt.Rows.Count > 0)
                {
                    oProrroga.IdProrroga = Convert.ToInt32(dt.Rows[0]["idProrroga"]);
                    oProrroga.CantidadProrroga = Convert.ToInt32(dt.Rows[0]["CantidadProrroga"]);
                }
                return oProrroga;

            }
            catch (Exception ex)
            {
                throw ex;
            }
           




        }

        public static ProrrogaPrestamoEntity GetPrimeraProrroga(int idProrroga)
        {
            try
            {
                ProrrogaPrestamoEntity oProrroga = new ProrrogaPrestamoEntity();
                DataTable dt = new DataTable();
                dt = oFn.Leer("Sp_GetPrimeraProrroga " + idProrroga);
                if (dt.Rows.Count > 0)
                {
                    oProrroga.Prorroga1 = Convert.ToDateTime(dt.Rows[0]["Prorroga"]);
                }
                return oProrroga;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ProrrogaPrestamoEntity GetSegundaProrroga(int idProrroga)
        {
            try
            {
                ProrrogaPrestamoEntity oProrroga = new ProrrogaPrestamoEntity();
                DataTable dt = new DataTable();
                dt = oFn.Leer("Sp_GetSegundaProrroga " + idProrroga);
                if (dt.Rows.Count > 0)
                {
                    oProrroga.Prorroga2 = Convert.ToDateTime(dt.Rows[0]["Prorroga2"]);
                }
                return oProrroga;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int AsignarProrroga(ProrrogaPrestamoEntity oProrroga)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_AsignarProrroga";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.Add("idProrroga", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("idPrestamo", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idPrestamo"].Value = oProrroga.PrestamoEntity.IdPrestamo;
                sqlcmd.Parameters.Add("CantidadProrroga", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["CantidadProrroga"].Value = oProrroga.CantidadProrroga;
                sqlcmd.ExecuteNonQuery();
                return Convert.ToInt32(sqlcmd.Parameters["idProrroga"].Value);
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
