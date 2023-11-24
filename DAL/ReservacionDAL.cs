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
   public class ReservacionDAL
    {
       public static bool InsertReservacion(ReservacionEntity oReservacion) 
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_InsertReservacion";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               cn.Open();
               sqlcmd.CommandType = CommandType.StoredProcedure;
               sqlcmd.Parameters.AddWithValue("idMaterial", oReservacion.MaterialEntity.IdMaterial);
               sqlcmd.Parameters.AddWithValue("idVisitante", oReservacion.VisitanteEntity.IdVisitante);
               sqlcmd.Parameters.AddWithValue("FechaReserva", oReservacion.FechaReservacionDia);
               sqlcmd.Parameters.AddWithValue("Estado", oReservacion.Estado);
               sqlcmd.Parameters.AddWithValue("FechaEntrega", oReservacion.FechaReservacionEntrega);
               sqlcmd.Parameters.AddWithValue("Cantidad", oReservacion.Cantidad);
               sqlcmd.Parameters.AddWithValue("EstadoEliminado", oReservacion.EstadoEliminado);
               sqlcmd.ExecuteNonQuery();
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally {
               cn.Close();
           }
       
       
       
       }

       public static DataTable ShowAllReservaciones()
       {
           return oFn.Leer("Sp_ShowAllReservaciones");
       }

       public static ReservacionEntity ReservacionAPrestamo(int idReservacion)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_GetDatosReservacion_Prestamo";
           ReservacionEntity oReservacion = new ReservacionEntity();
           DataTable dt = new DataTable();

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idReserva", idReservacion);
               sqlcmd.ExecuteNonQuery();
               SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   oReservacion.MaterialEntity.IdMaterial = Convert.ToInt32(dt.Rows[0]["idMaterial"]);
                   oReservacion.VisitanteEntity.IdVisitante = Convert.ToInt32(dt.Rows[0]["idVisitante"]);
                   oReservacion.Cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
               }
               return oReservacion;
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


       public static bool EstadoEntregadoReservacion(ReservacionEntity oReservacion)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_EstadoEntregadoReservacion";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idReserva", oReservacion.IdResercacion);
               sqlcmd.Parameters.AddWithValue("Estado", oReservacion.Estado);
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

       public static bool DeleteReservacion(ReservacionEntity oReservacion)
       {
           SqlConnection cn = new SqlConnection();
           string Sp = "Sp_DeleteReservacion";

           try
           {
               cn = oFn.GetConnection();
               SqlCommand sqlcmd = new SqlCommand(Sp, cn);
               sqlcmd.CommandType = CommandType.StoredProcedure;
               cn.Open();
               sqlcmd.Parameters.AddWithValue("idReserva", oReservacion.IdResercacion);
               sqlcmd.Parameters.AddWithValue("EstadoEliminado", oReservacion.EstadoEliminado);
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

       public static DataTable ShowReservacionSinEntregarByVisitante(int idVisitante)
       {
           return oFn.Leer("Sp_ShowReservacionesSinEntregarByIdVisitante " + idVisitante);
       }


    }
}
