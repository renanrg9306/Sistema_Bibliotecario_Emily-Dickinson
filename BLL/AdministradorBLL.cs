using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class AdministradorBLL
    {
       
        public static DataTable ShowAdmins(string pCodUsuario)
        {
          
                return AdministradoDAL.FnShowAdmin(pCodUsuario);
        }


        public static DataTable SesionAdmin(string pUser, string pContra)
        {
            return AdministradoDAL.FnGetAdmin(pUser, pContra);
        
        }

       
        public static string GetDatosAdminByCodUsuario(string pCodUsuario)
        {
            return AdministradoDAL.GetDatosAdminByCodUsuario(pCodUsuario);

        }

        public static int GetIdAdmin(string pCodUsuario)
        {
            return AdministradoDAL.GetIdAdmi(pCodUsuario);
        }

        public static int InsertAdmin(AdministradorEntity oAdmin)
        {
            try
            {
                return AdministradoDAL.InsertAdmin(oAdmin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AutenticacionAdministrador(AdministradorEntity poAdmin)
        {
            return AdministradoDAL.AutenticacionAdministrador(poAdmin);
        }

        public static int InsertAutenticacion(AdministradorEntity oAdmin)
        {
            return AdministradoDAL.InsertAutenticacion(oAdmin);
        }

        public static int NumberofAdmin(int pid, DateTime pAnio)
        {
            return AdministradoDAL.GetNumberofAdmin(pid, pAnio);
        }
        public static string CreateCodUsuarioAdmin(DateTime pAnio, int pCantidad, char pGenero)
        {
            return AdministradoDAL.CreateCodUsuarioAdmin(pAnio, pCantidad, pGenero);
        }

        public static string CreatePassword(string Telefono)
        {
            return AdministradoDAL.GenerandoClave(Telefono);
        }

        public static DataTable SearchAdminByName(string NombreCompleto)
        {
            return AdministradoDAL.SearchAdminByName(NombreCompleto);
        }

        public static AdministradorEntity GetAllDataAdmin(int idAdministrador)
        {
            return AdministradoDAL.GetAllDataAdmin(idAdministrador);
        }

        public static bool UpdateEmpleadoAdmin(AdministradorEntity oAdmin)
        {
            return AdministradoDAL.UpdateEmpleadoAdmin(oAdmin);
        }

        public static bool UpdatePassowordAdmin(AdministradorEntity oAdmin)
        {
            return AdministradoDAL.UpdatePassword(oAdmin);
        }

        public static bool DeleteAdmin(AdministradorEntity oAdmin)
        {
            return AdministradoDAL.DeleteAdmin(oAdmin);
        }

        public static string RecoverPasswordAdmin(string CodUsuario,string Correo)
        {
            return AdministradoDAL.RecoverPasswordAdmin(CodUsuario,Correo);
        }

        public static int VerificarPrestamosEmpleados(int idEmpleado)
        {
            return AdministradoDAL.VerificarPrestamosEmpleado(idEmpleado);
        }

        public static bool AsignarCantidadPrestamos(AdministradorEntity oAdmin)
        {
            return AdministradoDAL.AsignarCantidadPrestamosRealizados(oAdmin);
        }
        public static int GetIdAminByCodUsuario(string pCodUsuario)
        {
            return AdministradoDAL.GetIdAminByCodUsuario(pCodUsuario);
        }
        public static int VerificarCedulaAdmin(int idEmpleado, string Cedula)
        {
            return AdministradoDAL.VerificarCedulaAdmin(idEmpleado, Cedula);
        }

        //public static int EliminarAdministradorErrorCedula(int idEmpleado)
        //{
        //    return AdministradoDAL.EiliminarEmpleadoErrorCedula(idEmpleado);
        //}

        //public static bool DeleteEmpleadoAdmin(int idEmpleado)
        //{
        //    return AdministradoDAL.EliminarEmpleadoTableEmpleado(idEmpleado);
        //}
    }
}
