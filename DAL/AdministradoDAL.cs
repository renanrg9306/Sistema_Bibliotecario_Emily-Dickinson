using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using OtherFunction;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AdministradoDAL
    {
        public static DataTable FnGetAdmin(string pUser, string pPassword)// OBTIENE LOS DATOS DEL USUARIO QUE ESTA LOGEANDO
        {
            try
            {
                return oFn.FuctionSessionStar("Sp_GetUserAdmin", pUser, pPassword);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int GetNumberofAdmin(int id, DateTime Anio)
        {
            return oFn.CantidadRegistros("Sp_GetNumberofAdmins", "@idAdministrador", id, Anio);
        }
    



        public static DataTable FnShowAdmin(string pCodUsuario)// MUESTRA LOS DATOS DE LOS ADMINISTRADORES EXCEPTO EL MISMO
        {
            try
            {
                return oFn.FnShowAdmin("Sp_ShowAdmins", pCodUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string GetDatosAdminByCodUsuario(string pCodUsuario)
        {
            return oFn.GetDatosUserByCodUsuario("Sp_GetDatosAdminByCodUsuario", pCodUsuario);
        
        }

        public static int GetIdAdmi(string pCodUsuario)
        {
            return oFn.GetIdUser("Sp_GetIdUser", pCodUsuario);
        }

        public static int GetIdAminByCodUsuario(string pCodUsuario)
        {
            return oFn.GetIdAdmin("Sp_GetIdAdminByCodUsuario", pCodUsuario);
        }

        public static int InsertEmpleado(AdministradorEntity oAdmin)//ES UNA FUNCION DE TIPO ENTERO DADO QUE RETORNA EL ID DEL EMPLEADO
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_InsertEmpleado";
            
            try
            {
               
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idEmpleado", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("idNivelAca", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["idNivelAca"].Value = oAdmin.NivelAcademicoEntity.IdNivelAca;
                sqlcmd.Parameters.Add("Nombres", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Nombres"].Value = oAdmin.Nombres;
                sqlcmd.Parameters.Add("Apellidos", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Apellidos"].Value = oAdmin.Apellidos;
                sqlcmd.Parameters.Add("Cedula", SqlDbType.VarChar, 16).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Cedula"].Value = oAdmin.Cedula;
                sqlcmd.Parameters.Add("Edad", SqlDbType.SmallInt).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Edad"].Value = oAdmin.Edad;
                sqlcmd.Parameters.Add("Genero", SqlDbType.Char, 1).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Genero"].Value = oAdmin.Genero;
                sqlcmd.Parameters.Add("Direccion", SqlDbType.VarChar, 80).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Direccion"].Value = oAdmin.Direccion;
                sqlcmd.Parameters.Add("Telefono", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Telefono"].Value = oAdmin.Telefono;
                sqlcmd.Parameters.Add("Correo", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Correo"].Value = oAdmin.Correo;
                sqlcmd.Parameters.Add("FechaIngreso", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["FechaIngreso"].Value = oAdmin.FechaIngreso.ToShortDateString();
                sqlcmd.Parameters.Add("Estado", SqlDbType.Bit).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Estado"].Value = oAdmin.Estado;
                sqlcmd.Parameters.Add("CantidadPrestamosRealizados", SqlDbType.Int).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["CantidadPrestamosRealizados"].Value = oAdmin.CantidadPrestamosRealizados;
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

        public static int InsertAdmin(AdministradorEntity oAdmin)
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_InsertAdmin";

            try
            {
                    cn = oFn.GetConnection();
                    SqlCommand sqlcmd = new SqlCommand(sp, cn);
                    oAdmin.IdEmpleado = InsertEmpleado(oAdmin);
                    cn.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add("idAdministrador", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlcmd.Parameters.Add("idEmpleado", SqlDbType.Int).Direction = ParameterDirection.Input;
                    sqlcmd.Parameters["idEmpleado"].Value = oAdmin.IdEmpleado;
                    sqlcmd.ExecuteNonQuery();
                    return Convert.ToInt32(sqlcmd.Parameters["idAdministrador"].Value);
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

        public static int InsertAutenticacion(AdministradorEntity oAdmin)
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_InsertAutenticacion";
            try
            {
                cn = oFn.GetConnection();
                
                SqlCommand sqlcmd = new SqlCommand(sp,cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add("CodUsuario", SqlDbType.VarChar, 16).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["CodUsuario"].Value = oAdmin.AutenticacionEntity.CodUsuario;
                sqlcmd.Parameters.Add("Contra", SqlDbType.VarChar, 20).Direction = ParameterDirection.Input;
                sqlcmd.Parameters["Contra"].Value = oAdmin.AutenticacionEntity.Password;
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

        public static bool AutenticacionAdministrador(AdministradorEntity oAdmin)
        {
            SqlConnection cn = new SqlConnection();
            string sp = "Sp_AsignarCodUsuarioAdmin";

            try
            {
                oAdmin.AutenticacionEntity.IdUsuario = InsertAutenticacion(oAdmin);
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@idAdministrador", oAdmin.IdAdministador);
                sqlcmd.Parameters.AddWithValue("@idUsuario", oAdmin.AutenticacionEntity.IdUsuario);
                sqlcmd.Parameters.AddWithValue("@CodUsuario", oAdmin.CodUsuario);
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

        public static string CreateCodUsuarioAdmin(DateTime pAnio, int pCantidad, char pGenero)
        {
            return oFn.GenerandoCarnet(pAnio, pCantidad, 'A', pGenero);
        }

        public static string GenerandoClave(string pTelefono)
        {
            return oFn.InvertirTexto(pTelefono);
        }

        public static DataTable SearchAdminByName(string NombreCompleto)
        { 
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string Sp = "Sp_SearchAdminByName";

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

        public static AdministradorEntity GetAllDataAdmin(int idAdministrador)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_GetAllDataAdmmin";
            AdministradorEntity oAdmin = new AdministradorEntity();

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idAdministrador", idAdministrador);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    oAdmin.IdAdministador = idAdministrador;
                    oAdmin.IdEmpleado = Convert.ToInt32(dt.Rows[0]["idEmpleado"]);
                    oAdmin.NivelAcademicoEntity.IdNivelAca = Convert.ToInt32(dt.Rows[0]["idNivelAca"]);
                    oAdmin.AutenticacionEntity.IdUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
                    oAdmin.Nombres = dt.Rows[0]["Nombres"].ToString();
                    oAdmin.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                    oAdmin.Cedula = dt.Rows[0]["Cedula"].ToString();
                    oAdmin.Edad = Convert.ToInt16(dt.Rows[0]["Edad"]);
                    oAdmin.Direccion = dt.Rows[0]["Direccion"].ToString();
                    oAdmin.Telefono = dt.Rows[0]["Telefono"].ToString();
                    oAdmin.Correo = dt.Rows[0]["Correo"].ToString();
                    oAdmin.NivelAcademicoEntity.NivelAca = dt.Rows[0]["Descripcion"].ToString();
                    oAdmin.AutenticacionEntity.CodUsuario = dt.Rows[0]["CodUsuario"].ToString();
                    oAdmin.AutenticacionEntity.Password = dt.Rows[0]["Contra"].ToString();
                    oAdmin.Estado = true;
                }

                return oAdmin;
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

        public static bool UpdateEmpleadoAdmin(AdministradorEntity oAdmin)
        {
            
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdateEmpleado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", oAdmin.IdEmpleado);
                sqlcmd.Parameters.AddWithValue("idNivelAca", oAdmin.NivelAcademicoEntity.IdNivelAca);
                sqlcmd.Parameters.AddWithValue("Nombres", oAdmin.Nombres.ToString());
                sqlcmd.Parameters.AddWithValue("Apellidos", oAdmin.Apellidos.ToString());
                sqlcmd.Parameters.AddWithValue("Cedula", oAdmin.Cedula.ToString());
                sqlcmd.Parameters.AddWithValue("Edad", Convert.ToInt16(oAdmin.Edad));
                sqlcmd.Parameters.AddWithValue("Direccion", oAdmin.Direccion.ToString());
                sqlcmd.Parameters.AddWithValue("Correo", oAdmin.Correo.ToString());
                sqlcmd.Parameters.AddWithValue("Telefono", oAdmin.Telefono.ToString());
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdatePassword(AdministradorEntity oAdmin)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_UpdatePassword";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idUsuario", oAdmin.AutenticacionEntity.IdUsuario);
                sqlcmd.Parameters.AddWithValue("Contra", oAdmin.AutenticacionEntity.Password);
                sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AsignarCantidadPrestamosRealizados(AdministradorEntity oAdmin)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_AsignarCantidaPrestada";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", oAdmin.IdEmpleado);
                sqlcmd.Parameters.AddWithValue("CantidadPrestamosRealizados", oAdmin.CantidadPrestamosRealizados);
                sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool DeleteAdmin(AdministradorEntity oAdmin)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_DeleteEmpleado";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", oAdmin.IdEmpleado);
                sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string RecoverPasswordAdmin(string CodUsuario,string Correo)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_RecoverAcountAdmin";

            try
            {
                string CodAndPassword = "";
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                
                sqlcmd.Parameters.AddWithValue("CodUsuario",CodUsuario);
                sqlcmd.Parameters.AddWithValue("Correo", Correo);
                sqlcmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count>0)
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

        public static int VerificarPrestamosEmpleado(int idEmpleado) 
        {
            return oFn.VeficarPrestamosdeEmpleados(idEmpleado);
        
        }

        public static int VerificarCedulaAdmin(int idEmpleado, string Cedula)
        {
            return oFn.VerificarCedulaEmpleado(idEmpleado, Cedula);
        }

        //public static int EiliminarEmpleadoErrorCedula(int idEmpleado)
        //{
        //     return oFn.DeleteEmAfterCedulaMistake(idEmpleado);
        //}

        //public static bool EliminarEmpleadoTableEmpleado(int idEmpleado)
        //{
        //    return oFn.DeleteEmpleado(idEmpleado);
        //}
       
    }
}
