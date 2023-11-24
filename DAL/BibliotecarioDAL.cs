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
    public class BibliotecarioDAL
    {
        public static DataTable SesionBibliotecario(string pCodUsuario, string pContra)
        {
            return oFn.FuctionSessionStar("Sp_GetUserBibliotecario", pCodUsuario, pContra);
        }
        public static string CreateCodUsuarioBibliotecario(DateTime pAnio, int pCantidad, char pGenero)
        {
            return oFn.GenerandoCarnet(pAnio, pCantidad, 'B', pGenero);
        }

        public static string CreatePassword(string Telefono)
        {
            return oFn.InvertirTexto(Telefono);
        
        }
        public static string GetDatosBibliotByCodUsuario(string pCodUsuario)
        {
            return oFn.GetDatosUserByCodUsuario("Sp_GetDatosBibliotByCodUsuario", pCodUsuario);
        }

        public static int GetIdBibliotecarioByCodUsuario(string pCodUsuario)
        {
            return oFn.GetIdBibliotecario("Sp_GetIdBibliotecarioByCodUsuario", pCodUsuario);
        }

        public static DataTable ShowBibliotecarios()
        {
            return oFn.FnShowBibliotecario("Sp_ShowBibliotecarios");
                    
        }

        public static int InsertEmpleado(BibliotecarioEntity oBibliotecario)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertEmpleado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idEmpleado", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("idNivelAca", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idNivelAca"].Value = oBibliotecario.NivelAcademicoEntity.IdNivelAca;
                sqlcmd.Parameters.Add("Nombres", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Nombres"].Value = oBibliotecario.Nombres;
                sqlcmd.Parameters.Add("Apellidos", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Apellidos"].Value = oBibliotecario.Apellidos;
                sqlcmd.Parameters.Add("Cedula", SqlDbType.VarChar, 16).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Cedula"].Value = oBibliotecario.Cedula;
                sqlcmd.Parameters.Add("Edad", SqlDbType.SmallInt).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Edad"].Value = oBibliotecario.Edad;
                sqlcmd.Parameters.Add("Genero", SqlDbType.Char, 1).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Genero"].Value = oBibliotecario.Genero;
                sqlcmd.Parameters.Add("Direccion", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Direccion"].Value = oBibliotecario.Direccion;
                sqlcmd.Parameters.Add("Telefono", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Telefono"].Value = oBibliotecario.Telefono;
                sqlcmd.Parameters.Add("Correo", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Correo"].Value = oBibliotecario.Correo;
                sqlcmd.Parameters.Add("FechaIngreso", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["FechaIngreso"].Value = oBibliotecario.FechaIngreso.ToShortDateString();
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oBibliotecario.Estado;
                sqlcmd.Parameters.Add("CantidadPrestamosRealizados", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["CantidadPrestamosRealizados"].Value = oBibliotecario.CantidadPrestamosRealizados;
                sqlcmd.ExecuteNonQuery();

                return Convert.ToInt32(sqlcmd.Parameters["idEmpleado"].Value);

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

        public static int InsertEmpleadoBiblitecario(BibliotecarioEntity oBibliotecario)
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_InsertBibliotecario";

            try
            {
                oBibliotecario.IdEmpleado = InsertEmpleado(oBibliotecario);
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idBibliotecario", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("idEmpleado", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idEmpleado"].Value = oBibliotecario.IdEmpleado;
                sqlcmd.ExecuteNonQuery();
                return Convert.ToInt32(sqlcmd.Parameters["idBibliotecario"].Value);
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

        public static int InsertAutenticacion(BibliotecarioEntity oBibliotecario)
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_InsertAutenticacion";
            try
            {
                cn = oFn.GetConnection();

                SqlCommand sqlcmd = new SqlCommand(sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("CodUsuario", SqlDbType.VarChar, 16).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["CodUsuario"].Value = oBibliotecario.AutenticacionEntity.CodUsuario;
                sqlcmd.Parameters.Add("Contra", SqlDbType.VarChar, 20).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Contra"].Value = oBibliotecario.AutenticacionEntity.Password;
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

        public static bool AutenticacionBibliotecario(BibliotecarioEntity oBibliotecario)
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_AsignarCodUsuarioBibliotecario";

            try
            {
                oBibliotecario.AutenticacionEntity.IdUsuario = InsertAutenticacion(oBibliotecario);
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@idBibliotecario", oBibliotecario.IdBibliotecario);
                sqlcmd.Parameters.AddWithValue("@idUsuario", oBibliotecario.AutenticacionEntity.IdUsuario);
                sqlcmd.Parameters.AddWithValue("@CodUsuario", oBibliotecario.CodUsuario);
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

        public static BibliotecarioEntity GetAllDataBibliotecario(int idBibliotecario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_GetAllDataBibliotecario";
            BibliotecarioEntity oBiblio = new BibliotecarioEntity();

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idBibiotecario", idBibliotecario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    oBiblio.IdBibliotecario = idBibliotecario;
                    oBiblio.IdEmpleado = Convert.ToInt32(dt.Rows[0]["idEmpleado"]);
                    oBiblio.AutenticacionEntity.IdUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
                    oBiblio.NivelAcademicoEntity.IdNivelAca = Convert.ToInt32(dt.Rows[0]["idNivelAca"]);
                    oBiblio.Nombres = dt.Rows[0]["Nombres"].ToString();
                    oBiblio.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                    oBiblio.Cedula = dt.Rows[0]["Cedula"].ToString();
                    oBiblio.Edad = Convert.ToInt16(dt.Rows[0]["Edad"]);
                    oBiblio.Direccion = dt.Rows[0]["Direccion"].ToString();
                    oBiblio.Telefono = dt.Rows[0]["Telefono"].ToString();
                    oBiblio.Correo = dt.Rows[0]["Correo"].ToString();
                    oBiblio.NivelAcademicoEntity.NivelAca = dt.Rows[0]["Descripcion"].ToString();
                    oBiblio.AutenticacionEntity.CodUsuario = dt.Rows[0]["CodUsuario"].ToString();
                    oBiblio.AutenticacionEntity.Password = dt.Rows[0]["Contra"].ToString();
                    oBiblio.Estado = true;
                }

                return oBiblio;
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

        public static DataTable SearchBibliotecarioByName(string NombreCompleto)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_SearchBibliotecarioByName";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("NombreCompleto", NombreCompleto);
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

        public static bool UpdateEmpleadoBibliotecario(BibliotecarioEntity oBiblio)
        {

            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdateEmpleado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", oBiblio.IdEmpleado);
                sqlcmd.Parameters.AddWithValue("idNivelAca", oBiblio.NivelAcademicoEntity.IdNivelAca);
                sqlcmd.Parameters.AddWithValue("Nombres", oBiblio.Nombres.ToString());
                sqlcmd.Parameters.AddWithValue("Apellidos", oBiblio.Apellidos.ToString());
                sqlcmd.Parameters.AddWithValue("Cedula", oBiblio.Cedula.ToString());
                sqlcmd.Parameters.AddWithValue("Edad", Convert.ToInt16(oBiblio.Edad));
                sqlcmd.Parameters.AddWithValue("Direccion", oBiblio.Direccion.ToString());
                sqlcmd.Parameters.AddWithValue("Correo", oBiblio.Correo.ToString());
                sqlcmd.Parameters.AddWithValue("Telefono", oBiblio.Telefono.ToString());
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdatePassword(BibliotecarioEntity oBiblio)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdatePassword";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idUsuario", oBiblio.AutenticacionEntity.IdUsuario);
                sqlcmd.Parameters.AddWithValue("Contra", oBiblio.AutenticacionEntity.Password);
                sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteBibliotecario(BibliotecarioEntity oBiblio)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_DeleteEmpleado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", oBiblio.IdEmpleado);
                sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string RecoverPasswordBibliotecario(string CodUsuario, string Correo)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_RecoverAcountBiblio";
            AdministradorEntity oAdmin = new AdministradorEntity();

            try
            {
                string CodAndPassword = "";
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("CodUsuario", CodUsuario);
                sqlcmd.Parameters.AddWithValue("Correo", Correo);
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

        public static bool AsignarCantidadPrestamosRealizados(BibliotecarioEntity oBiblio)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_AsignarCantidaPrestada";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", oBiblio.IdEmpleado);
                sqlcmd.Parameters.AddWithValue("CantidadPrestamosRealizados", oBiblio.CantidadPrestamosRealizados);
                sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int VerificarPrestamosEmpleado(int idEmpleado)
        {
            return oFn.VeficarPrestamosdeEmpleados(idEmpleado);
        }

        public static DataTable ShowEmpleado()
        {
            return oFn.Leer("Sp_ShowEmpleados");
        
        }

        public static int VerificarCedulaBibliotecario(int idEmpleado, string Cedula)
        {
            return oFn.VerificarCedulaEmpleado(idEmpleado, Cedula);
        }
        
    }
}
