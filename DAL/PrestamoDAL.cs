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
    public class PrestamoDAL
    {
        public static int InsertPrestamo(EntregaPrestamoEntity oPrestamo)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertPrestamo";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.Add("idPrestamo", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("idMaterial", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idMaterial"].Value = oPrestamo.MaterialEntity.IdMaterial;
                sqlcmd.Parameters.Add("idTipoPrestamo", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idTipoPrestamo"].Value = oPrestamo.TipoPrestamo.IdTipoPrestamo;
                sqlcmd.Parameters.Add("idEmpleado", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idEmpleado"].Value = oPrestamo.EmpleadoEntity.IdEmpleado;
                sqlcmd.Parameters.Add("idVisitante", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idVisitante"].Value = oPrestamo.VisitanteEntity.IdVisitante;
                sqlcmd.Parameters.Add("Fecha_Prestamo", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Fecha_Prestamo"].Value = oPrestamo.FechaPrestamo;
                sqlcmd.Parameters.Add("Cantidad", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Cantidad"].Value = oPrestamo.Cantidad;
                sqlcmd.ExecuteNonQuery();
                return Convert.ToInt32(sqlcmd.Parameters["idPrestamo"].Value);
             
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

        public static int EntregaPrestamo(EntregaPrestamoEntity oPrestamo)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertEntregaPrestamo";

            try
            {
                ProrrogaPrestamoEntity oProrroga = new ProrrogaPrestamoEntity();
               
                oPrestamo.IdPrestamo = InsertPrestamo(oPrestamo);

                oProrroga.CantidadProrroga = 0;
                oProrroga.PrestamoEntity.IdPrestamo = oPrestamo.IdPrestamo;
                oPrestamo.ProrrogaEntity.IdProrroga = ProrrogaPrestamoDAL.AsignarProrroga(oProrroga);
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idPrestamo",oPrestamo.IdPrestamo);
                sqlcmd.Parameters.AddWithValue("idProrroga", oPrestamo.ProrrogaEntity.IdProrroga);
                sqlcmd.Parameters.AddWithValue("Fecha_Entrega", oPrestamo.FechaDevolucion);
                sqlcmd.Parameters.AddWithValue("POR", oPrestamo.POR);
                sqlcmd.ExecuteNonQuery();
                return oPrestamo.Cantidad;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
            
            }
        
        }

        public static DataTable ShowPrestamos()
        {
            return oFn.Leer("Sp_ShowPrestamos");
        }

        public static DataTable MaterialRecepcionado()
        {
            return oFn.Leer("Sp_ShowMaterialRecepcionado");
        }

        public static int VerificarMatrialEnPrestamo(int idMaterial)
        {
            int Cantidad = 0;
         try
          {
             DataTable dt = new DataTable();
             dt = oFn.Leer("Sp_VerificarMaterialEnPrestamo " + idMaterial);
                if (dt.Rows.Count > 0) {
                  Cantidad = dt.Rows.Count; 
                 }
                return Cantidad;
           }
         catch (Exception ex)
           {
             throw ex;
            }
        
        }

        public static DataTable ShowPrestamosPrendientes(int idVisitante)
        {
            return oFn.Leer("Sp_ShowPrestamosPedienteVisitante " + idVisitante);
        }

        public static DataTable ShowPrestamosEntregados(int idVisitante)
        {
            return oFn.Leer("Sp_ShowPrestamosEntregadosVisitante " + idVisitante);
        }

        public static DataTable RptPrestamosRealizados(DateTime Fecha1, DateTime Fecha2, int idEmpleado)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_ShowPrestamos_RangoFecha";
            try
            {
                
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("Fecha1", Fecha1);
                sqlcmd.Parameters.AddWithValue("Fecha2", Fecha2);
                sqlcmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
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

        public static DataTable RptPrestamosRecepcionados(DateTime Fecha1, DateTime Fecha2, string NombreEmpleado)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_RptMaterialRecepcionado";
            try
            {

                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("Fecha1", Fecha1);
                sqlcmd.Parameters.AddWithValue("Fecha2", Fecha2);
                sqlcmd.Parameters.AddWithValue("NombreEmpleado", NombreEmpleado);
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

        public static DataTable RptHistorialMa(DateTime Fecha1, DateTime Fecha2, int idMaterial)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_RptHistPreMaterial";
            try
            {

                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("Fecha1", Fecha1);
                sqlcmd.Parameters.AddWithValue("Fecha2", Fecha2);
                sqlcmd.Parameters.AddWithValue("idMaterial",idMaterial);
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

        public static DataTable RptHistorialVisitante(DateTime Fecha1, DateTime Fecha2, int idVisitante)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_RptHistPreVisitante";
            try
            {

                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("Fecha1", Fecha1);
                sqlcmd.Parameters.AddWithValue("Fecha2", Fecha2);
                sqlcmd.Parameters.AddWithValue("idVisitante", idVisitante);
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

        public static DataTable RptPrePro(DateTime Fecha1, DateTime Fecha2)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_RptPrestamos_Prorroga";
            try
            {

                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("Fecha1", Fecha1);
                sqlcmd.Parameters.AddWithValue("Fecha2", Fecha2);
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
