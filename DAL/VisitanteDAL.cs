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
  public class VisitanteDAL
 {
      public static DataTable GetUserVisitante(string CodUsuario, string Pass)
      {
          try
          {
              return oFn.FuctionSessionStar("Sp_GetUserVisitante", CodUsuario, Pass);
          }
          catch (Exception ex)
          {
              throw ex;          
          }
      }

      public static string GenerarCarnetVisitante(DateTime pAnio, int pCantidad, char pGenero)
      {
          return oFn.GenerandoCarnet(pAnio, pCantidad,'V', pGenero);
      }

      public static string CreatePassword(string Telefono)
      {
          return oFn.InvertirTexto(Telefono);
      }

      public static string GetDatoUserByCodUsuario(string CodUsuario)
      {
          try
          {
              return oFn.GetDatosUserByCodUsuario("Sp_GetDatosVisitanteByCodUsuario", CodUsuario);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public static DataTable ShowVisitante()
      {
          return oFn.Leer("Sp_ShowVisitante");
      }


      public static int InsertAutenticacion(VisitanteEntity oVisitante)
      {
          
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_InsertAutenticacion";

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              cn.Open();
              sqlcmd.CommandType = CommandType.StoredProcedure;
              sqlcmd.Parameters.Add("idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
              sqlcmd.Parameters.Add("CodUsuario", SqlDbType.VarChar, 16).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["CodUsuario"].Value = oVisitante.AutenticacionEntity.CodUsuario;
              sqlcmd.Parameters.Add("Contra", SqlDbType.VarChar, 40).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Contra"].Value = oVisitante.AutenticacionEntity.Password;
              sqlcmd.ExecuteNonQuery();
              return Convert.ToInt32(sqlcmd.Parameters["idUsuario"].Value);
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

      public static int InsertVisitante(VisitanteEntity oVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_InsertVisitante";

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              cn.Open();
              sqlcmd.CommandType = CommandType.StoredProcedure;
              sqlcmd.Parameters.Add("idVisitante", SqlDbType.Int).Direction = ParameterDirection.Output;
              sqlcmd.Parameters.Add("idProgram", SqlDbType.Int).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["idProgram"].Value = oVisitante.ProgramEntity.IdProgram;
              sqlcmd.Parameters.Add("idOcupacion", SqlDbType.Int).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["idOcupacion"].Value = oVisitante.OcupacionEntity.IdOcupacion;
              sqlcmd.Parameters.Add("Nombres", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Nombres"].Value = oVisitante.Nombre;
              sqlcmd.Parameters.Add("Apellidos", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Apellidos"].Value = oVisitante.Apellido;
              sqlcmd.Parameters.Add("Cedula", SqlDbType.VarChar, 16).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Cedula"].Value = oVisitante.Cedula;
              sqlcmd.Parameters.Add("Edad", SqlDbType.SmallInt).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Edad"].Value = oVisitante.Edad;
              sqlcmd.Parameters.Add("Genero", SqlDbType.Char).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Genero"].Value = oVisitante.Genero;
              sqlcmd.Parameters.Add("Direccion", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Direccion"].Value = oVisitante.Direccion;
              sqlcmd.Parameters.Add("Telefono", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Telefono"].Value = oVisitante.Telefono;
              sqlcmd.Parameters.Add("Email", SqlDbType.VarChar, 40).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Email"].Value = oVisitante.Email;
              sqlcmd.Parameters.Add("FechaIngreso", SqlDbType.DateTime).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["FechaIngreso"].Value = oVisitante.FechaIngreso;
              sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Estado"].Value = oVisitante.Estado;
              sqlcmd.Parameters.Add("Prestado", SqlDbType.Int).Direction = ParameterDirection.Input;
              sqlcmd.Parameters["Prestado"].Value = oVisitante.Prestado;
              sqlcmd.ExecuteNonQuery();
              return Convert.ToInt32(sqlcmd.Parameters["idVisitante"].Value);
            
             
                          
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

      public static bool AutenticacionVisitante(VisitanteEntity oVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string sp = "Sp_AsignarCodUsuarioVisitante";

          try
          {
              oVisitante.AutenticacionEntity.IdUsuario = InsertAutenticacion(oVisitante);
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(sp, cn);
              cn.Open();
              sqlcmd.CommandType = CommandType.StoredProcedure;
              sqlcmd.Parameters.AddWithValue("@idVisitante", oVisitante.IdVisitante);
              sqlcmd.Parameters.AddWithValue("@idUsuario", oVisitante.AutenticacionEntity.IdUsuario);
              sqlcmd.Parameters.AddWithValue("@CodUsuario", oVisitante.CodUsuario);
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

      public static VisitanteEntity GetVisitante(int idVisitante)
      {
          VisitanteEntity oVisitante = new VisitanteEntity();
          string Sp = "Sp_GetAllDataVisitante ";
          try
          {
             DataTable dt = oFn.Leer(Sp + idVisitante);
             if (dt.Rows.Count > 0)
             {
                 oVisitante.IdVisitante = Convert.ToInt32(dt.Rows[0]["idVisitante"]);
                 oVisitante.OcupacionEntity.IdOcupacion = Convert.ToInt32(dt.Rows[0]["idOcupacion"]);
                 oVisitante.ProgramEntity.IdProgram = Convert.ToInt32(dt.Rows[0]["idProgram"]);
                 oVisitante.AutenticacionEntity.IdUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
                 oVisitante.Nombre = dt.Rows[0]["Nombres"].ToString();
                 oVisitante.Apellido = dt.Rows[0]["Apellidos"].ToString();
                 oVisitante.Cedula = dt.Rows[0]["Cedula"].ToString();
                 oVisitante.Edad = Convert.ToInt16(dt.Rows[0]["Edad"]);
                 oVisitante.Direccion = dt.Rows[0]["Direccion"].ToString();
                 oVisitante.Email = dt.Rows[0]["Email"].ToString();
                 oVisitante.Telefono = dt.Rows[0]["Telefono"].ToString();
                 oVisitante.AutenticacionEntity.CodUsuario = dt.Rows[0]["CodUsuario"].ToString();
                 oVisitante.AutenticacionEntity.Password = dt.Rows[0]["Contra"].ToString();
             }
             return oVisitante;
          }
             
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public static bool UdpateVisitante(VisitanteEntity oVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_UpdateVisitante";

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              cn.Open();
              sqlcmd.CommandType = CommandType.StoredProcedure;
              sqlcmd.Parameters.AddWithValue("idVisitante", oVisitante.IdVisitante);
              sqlcmd.Parameters.AddWithValue("idProgram", oVisitante.ProgramEntity.IdProgram);
              sqlcmd.Parameters.AddWithValue("idOcupacion", oVisitante.OcupacionEntity.IdOcupacion);
              sqlcmd.Parameters.AddWithValue("Cedula", oVisitante.Cedula);
              sqlcmd.Parameters.AddWithValue("Edad", oVisitante.Edad);
              sqlcmd.Parameters.AddWithValue("Telefono", oVisitante.Telefono);
              sqlcmd.Parameters.AddWithValue("Direccion", oVisitante.Direccion);
              sqlcmd.Parameters.AddWithValue("Email", oVisitante.Email);
              sqlcmd.ExecuteNonQuery();
              return true;
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally
          { 
          
          }

      }

      public static bool UpdatePassword(VisitanteEntity oVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_UpdatePassword";

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              sqlcmd.CommandType = CommandType.StoredProcedure;
              cn.Open();
              sqlcmd.Parameters.AddWithValue("idUsuario", oVisitante.AutenticacionEntity.IdUsuario);
              sqlcmd.Parameters.AddWithValue("Contra", oVisitante.AutenticacionEntity.Password);
              sqlcmd.ExecuteNonQuery();
              return true;

          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public static bool DeleteVisitante(VisitanteEntity oVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_DeleteVisitante";

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              sqlcmd.CommandType = CommandType.StoredProcedure;
              cn.Open();
              sqlcmd.Parameters.AddWithValue("idVisitante", oVisitante.IdVisitante);
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

      public static int GetIdVisitante(string pCodUsuario)
      {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_GetIdVisitante";
            int Id = 0;
            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("CodUsuario", pCodUsuario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["idVisitante"]);
                }

                return Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally {
                cn.Close();
            
            }
      
      }

      public static string RecoverPasswordVisitante(string CodUsuario, string Correo)
      {
          DataTable dt = new DataTable();
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_RecoverAcountVisitante";

          try
          {
              string CodAndPassword = "";
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              sqlcmd.CommandType = CommandType.StoredProcedure;
              cn.Open();

              sqlcmd.Parameters.AddWithValue("CodUsuario", CodUsuario);
              sqlcmd.Parameters.AddWithValue("Correo", Correo);
              sqlcmd.ExecuteNonQuery();
              SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
              da.Fill(dt);
              if (dt.Rows.Count > 0)
              {
                  CodAndPassword = "Codigo de Acceso: " + dt.Rows[0]["CodUsuario"] + " Clave de Acceso: " + dt.Rows[0]["Contra"];
              }
              return CodAndPassword;


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

      public static int VerificarPrestamosVisitante(int idVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_VerificarPrestamosVisitante";
          DataTable dt = new DataTable();
          int Cantidad = 0;

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              sqlcmd.CommandType = CommandType.StoredProcedure;
              cn.Open();
              sqlcmd.Parameters.AddWithValue("idVisitante", idVisitante);
              SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
              da.Fill(dt);
              if (dt.Rows.Count > 0)
              {
                  Cantidad = Convert.ToInt32(dt.Rows[0]["CantidadDePrestamos"]);
              }
              return Cantidad;
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

      public static bool AsignarCantidadPrestamosRealizados(VisitanteEntity oVisitante)
      {
          SqlConnection cn = new SqlConnection();
          string Sp = "Sp_AsignarCantidaPrestadaVisitante";

          try
          {
              cn = oFn.GetConnection();
              SqlCommand sqlcmd = new SqlCommand(Sp, cn);
              sqlcmd.CommandType = CommandType.StoredProcedure;
              cn.Open();
              sqlcmd.Parameters.AddWithValue("idVisitante", oVisitante.IdVisitante);
              sqlcmd.Parameters.AddWithValue("Prestado", oVisitante.Prestado);
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
