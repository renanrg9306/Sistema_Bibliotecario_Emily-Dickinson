using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;

namespace OtherFunction
{
    public class oFn
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                string strConnect = ConfigurationManager.ConnectionStrings["SysConnection"].ToString();

                return new SqlConnection(strConnect);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GenerandoCarnet(DateTime Anio, int Cantidad, char UserType, char Genero)
        {
            return Anio.Year.ToString() + Cantidad + UserType + Genero;

        }

        public static DataTable FuctionSessionStar(string SqlCmd, string User, string Password)// ES UNA FUNCION DE TIPO DATATABLE PORQUE RETORNARA UNA TABLA
        {
            DataTable dtreturn = new DataTable(); //ESTA ES LA TABLE DE RETORNO QUE CONTRENDRA LOS DATOS DEL USUARIO Q INICIARA SESION
            SqlConnection Cn = new SqlConnection();// HACEMOS UNA INSTANCIA DE VARIABLE DE TIPO CONECTION
            string Nsql = SqlCmd; // NSQL REPRESENTARA EL NOMBRE DEL PROCEDIMIENTO DEL ALMACENADO QUE SE ENVIAR'A POR PARAMENTRO

            try
            {
                Cn = oFn.GetConnection(); // ESTABLECEMOS CONEXION
                SqlCommand Cmd = new SqlCommand(SqlCmd, Cn);//INSTANCIAS LA VARIABLE DE TIPO SQLCOMMAND
                Cn.Open();//ABRE CONEXION

                Cmd.CommandType = CommandType.StoredProcedure;//SELECCIONA EL TIPO DE COMANDO,EL CUAL ES UN PROCEDIMIENTO DE ALMACENADO
                Cmd.Parameters.AddWithValue("@CodUsuario", User);//USARIO
                Cmd.Parameters.AddWithValue("@Contra", Password);//CLAVE
                SqlDataAdapter daSession = new SqlDataAdapter(Cmd);// 
                daSession.Fill(dtreturn);//LLENANDO LA TABLA RETORNO
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cn.Close();
            }

            return dtreturn;
        }


        public static DataTable Leer(string Cmd) //ESTA FUNCON LEER'A CUALQUIER COMANDO DE TIPO TRAN-SQL
        {
            DataTable dt = new DataTable();// CREAMOS UN VARIABLE DE TIPO TIPO YA QUE EL VALOR DE VUELTO SERA UNA TABLA
            SqlConnection Cn = new SqlConnection();// VARIABLE DE TIPO CONEXXION 
            SqlDataAdapter da = new SqlDataAdapter();// VARIABLE E INSTACIA DATAAPDATER 

            try
            {
                Cn = GetConnection(); // ESTABLECE CONEXION 
                da = new SqlDataAdapter(Cmd, Cn); // SE PASAN EL COMANDO Y LA CONEXION 
                Cn.Open(); // SE ABRE LA CONEXION 
                da.SelectCommand.Connection = Cn;
                da.Fill(dt);// LLENADO DE LA TABLA
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cn.Close();
            }     
        }

        public static DataTable FnShowAdmin(string Cmd, string CodUsario)//ESTA FUNCION PERMITIRA MOSTRAR LOS DATOS DE LOS ADMINISTRADORES EXCEPTO EL QUE SE ENCUENTRA LOGUEADO
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string nsqlcmd = Cmd;

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsqlcmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CodUsuario", CodUsario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return dt;
        }

        public static DataTable FnShowBibliotecario(string Cmd)//ESTA FUNCION PERMITIRA MOSTRAR LOS DATOS DE LOS BIBLIOTECARIO EXCEPTO EL QUE SE ENCUENTRA LOGUEADO
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(); 
            string nsqlcmd = Cmd;

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsqlcmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return dt;
        }

        public static string InvertirTexto(string Cadena)
        {
            char[] Invertir = Cadena.ToCharArray();
            Array.Reverse(Invertir);
            return new string(Invertir);
        }

        public static int VeficarPrestamosdeEmpleados(int idEmpleado)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_VerificarEmpleadosPrestamos";
            DataTable dt = new DataTable();
            int Cantidad = 0;
            
            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp,cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
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

        public static string GetDatosUserByCodUsuario(string cmd, string pCodUsuario)
        {

            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string nsqlcmd = cmd;
            string UserName = "";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsqlcmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CodUsuario", pCodUsuario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    UserName = dt.Rows[0]["Usuario"].ToString();
                }
                return UserName;
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

        public static int GetIdUser(string cmd, string pCodUsuario)
        {

            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string nsqlcmd = cmd;
            int IdUser=0;

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsqlcmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CodUsuario", pCodUsuario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    IdUser = Convert.ToInt32(dt.Rows[0]["idEmpleado"]);
                }
                return IdUser;
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
        public static int GetIdAdmin(string cmd, string pCodUsuario)
        {

            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string nsqlcmd = cmd;
            int IdUser = 0;

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsqlcmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CodUsuario", pCodUsuario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    IdUser = Convert.ToInt32(dt.Rows[0]["idAdministrador"]);
                }
                return IdUser;
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

        public static int GetIdBibliotecario(string cmd, string pCodUsuario)
        {

            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            string nsqlcmd = cmd;
            int IdUser = 0;

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsqlcmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CodUsuario", pCodUsuario);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    IdUser = Convert.ToInt32(dt.Rows[0]["idBibiotecario"]);
                }
                return IdUser;
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

        public static DataTable ShowNivelAcademico(string pcmd)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            string nsql = pcmd;

            try
            {
                cn = GetConnection();
                SqlCommand sqlcmd = new SqlCommand(nsql, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }

        public static int CantidadRegistros(string SpName, string Parametro, int idUser, DateTime Anio)
        {
            SqlConnection cn = new SqlConnection();
            int Cantidad = 0;
            string cmd = SpName;

            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmd, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue(Parametro, idUser);
                sqlcmd.Parameters.AddWithValue("@Anio", Anio);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.SelectCommand.Connection = cn;
                Cantidad = Convert.ToInt32(da.SelectCommand.ExecuteScalar());
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

        public static bool EnviarCorreo(string Subject, string BodyMsg, string Correo)
        {
            try
            {
                MailMessage oMensaje = new MailMessage();
                MailAddress EmailFrom = new MailAddress("soportetecnicobibliotecaccnn@gmail.com", "Soporte Tecnico Biblioteca CCNN");
                MailAddress EmailTo = new MailAddress(Correo);

                SmtpClient smpt = new SmtpClient();
                smpt.Port = 587;
                smpt.EnableSsl = true;
                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smpt.UseDefaultCredentials = false;
                smpt.Credentials = new NetworkCredential(EmailFrom.Address, "biblioteca");
                smpt.Host = "smtp.gmail.com";
                oMensaje.Subject = Subject;
                oMensaje.From = EmailFrom;
                oMensaje.To.Add(EmailTo);
                oMensaje.Body = BodyMsg;
                smpt.Send(oMensaje);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        public static int VerificarCedulaEmpleado(int idEmpleado, string cedula)
        {
            string Sp = "Sp_VerificarCedulaEmpleado";
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();
            int Cantidad = 0;

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sqlcmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
                sqlcmd.Parameters.AddWithValue("Cedula", cedula);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Cantidad = dt.Rows.Count;
                
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

        //public static int DeleteEmAfterCedulaMistake(int idEmpleado)
        //{
        //    string Sp = "Sp_DeleteEmpleadoByErrorInsert";
        //    SqlConnection cn = new SqlConnection();
        //    cn = GetConnection();
        //    SqlCommand sqlcmd = new SqlCommand(Sp, cn);
        //    try
        //    {
        //        if (idEmpleado != 0)
        //        {
        //            cn.Open();
        //            sqlcmd.CommandType = CommandType.StoredProcedure;
        //            sqlcmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
        //            sqlcmd.ExecuteNonQuery();
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }

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

        //public static bool DeleteEmpleado(int idEmpleado)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    string Sp = "Sp_DeleteEmpleadoByErrorTablaEmpleado";

        //    try
        //    {
        //        cn = oFn.GetConnection();
        //        SqlCommand sqlcmd = new SqlCommand(Sp, cn);
        //        sqlcmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        sqlcmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
        //        sqlcmd.ExecuteNonQuery();
        //        return true;

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
