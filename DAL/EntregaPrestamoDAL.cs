using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using OtherFunction;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class EntregaPrestamoDAL
    {
        public static EntregaPrestamoEntity GetCantidadPrestamo(int idEntrega_Prestamo)
        {
           
            try
            {
                EntregaPrestamoEntity oEP = new EntregaPrestamoEntity();
                DataTable dt = new DataTable();
                dt = oFn.Leer("Sp_GetPrestamoCantidad "+idEntrega_Prestamo);
                if (dt.Rows.Count > 0)
                {
                    oEP.IdEntregaP = Convert.ToInt32(dt.Rows[0]["idEntrega_Prestamo"]);
                    oEP.IdPrestamo = Convert.ToInt32(dt.Rows[0]["idPrestamo"]);
                    oEP.EmpleadoEntity.IdEmpleado = Convert.ToInt32(dt.Rows[0]["idEmpleado"]);
                    oEP.VisitanteEntity.IdVisitante = Convert.ToInt32(dt.Rows[0]["idVisitante"]);
                    oEP.MaterialEntity.IdMaterial = Convert.ToInt32(dt.Rows[0]["idMaterial"]);
                    oEP.MaterialEntity.Cantidad = Convert.ToInt32(dt.Rows[0]["CantidadMaterial"]);
                    oEP.MaterialEntity.Prestado = Convert.ToInt32(dt.Rows[0]["Prestado"]);
                    oEP.Cantidad = Convert.ToInt32(dt.Rows[0]["CantidadPrestamo"]);
                }
                return oEP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public static string GetFechaDevolucion(int IdEntregaPrestamo)
        {

            string FechaDevolucion = "";
            
            try
            {
                DataTable dt = new DataTable();
                
                dt = oFn.Leer("Sp_GetFechaDevolucion " + IdEntregaPrestamo);
                if (dt.Rows.Count > 0)
                {
                    FechaDevolucion = dt.Rows[0]["Fecha_Entrega"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return FechaDevolucion;
        }


        public static bool UMaterialRecepcionado(EntregaPrestamoEntity oEP)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_MaterialRecepcionado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEntrega_Prestamo", oEP.IdEntregaP);
                sqlcmd.Parameters.AddWithValue("POR", oEP.POR);
                sqlcmd.Parameters.AddWithValue("Fecha_Recepcion", oEP.Fecha_Recepcion);
                sqlcmd.Parameters.AddWithValue("Recepcionado_Por", oEP.Recepcionado_Por);
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

        //public static int AsignarProrroga(ProrrogaPrestamoEntity oProrroga)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    string Sp = "Sp_AsignarProrroga";

        //    try
        //    {
        //        cn = oFn.GetConnection();
        //        SqlCommand sqlcmd = new SqlCommand(Sp, cn);
        //        sqlcmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        sqlcmd.Parameters.Add("idProrroga", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        sqlcmd.Parameters.Add("Prorroga", SqlDbType.DateTime).Direction = ParameterDirection.Input;
        //        sqlcmd.Parameters["Prorroga"].Value = oProrroga.Prorroga1;
        //        sqlcmd.Parameters.Add("CantidadProrroga", SqlDbType.Int).Direction = ParameterDirection.Input;
        //        sqlcmd.Parameters["CantidadProrroga"].Value = oProrroga.CantidadProrroga;
        //        sqlcmd.ExecuteNonQuery();
        //        return Convert.ToInt32(sqlcmd.Parameters["idProrroga"].Value);



        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }

        //}
    }
}
