using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entity;

namespace BLL
{
    public class BibliotecarioBLL
    {

        public static DataTable SesionBibliotecario(string pCodUsario, string pContra)
        {
            return BibliotecarioDAL.SesionBibliotecario(pCodUsario, pContra);
        }

        public static string GetDatosBibliotByCodUsuario(string pCodUsuario)
        {
            return BibliotecarioDAL.GetDatosBibliotByCodUsuario(pCodUsuario);

        }
        public static DataTable ShowBibliotecarios()
        {
            return BibliotecarioDAL.ShowBibliotecarios();
        }


        public static int InsertBibliotecario(BibliotecarioEntity poBibliotecario)
        {
            return BibliotecarioDAL.InsertEmpleadoBiblitecario(poBibliotecario);
        }

        public static bool AutenticacionBibliotecario(BibliotecarioEntity poBibliotecario)
        {
            return BibliotecarioDAL.AutenticacionBibliotecario(poBibliotecario);
        }
        public static string CreateCodUsuarioBibliotecario(DateTime pAnio, int pCantidad, char pGenero)
        {
            return BibliotecarioDAL.CreateCodUsuarioBibliotecario(pAnio, pCantidad, pGenero);
        }

        public static string CreatePassword(string pTelefono)
        {
            return BibliotecarioDAL.CreatePassword(pTelefono);
        }

        public static BibliotecarioEntity GetAllDataBibliotecario(int idBibliotecario)
        {
            return BibliotecarioDAL.GetAllDataBibliotecario(idBibliotecario);
        }

        public static bool UpdateEmpleadoBibliotecario(BibliotecarioEntity oBiblio)
        {
            return BibliotecarioDAL.UpdateEmpleadoBibliotecario(oBiblio);
        }

        public static bool UpdatePasswordBibliotecario(BibliotecarioEntity oBiblio)
        {
            return BibliotecarioDAL.UpdatePassword(oBiblio);
        }
        public static DataTable SearchBibliotecarioByName(string Name)
        {
            return BibliotecarioDAL.SearchBibliotecarioByName(Name);
        }
        public static bool DeleteBibliotecario(BibliotecarioEntity oBiblio)
        {
            return BibliotecarioDAL.DeleteBibliotecario(oBiblio);
        }

        public static string RecoverAcountBibliotecario(string CodUsuario, string Correo)
        {
            return BibliotecarioDAL.RecoverPasswordBibliotecario(CodUsuario,Correo);
        }

        public static int VerificarPrestamoEmpleado(int idEmpleado)
        {
            return BibliotecarioDAL.VerificarPrestamosEmpleado(idEmpleado);
        }

        public static bool AsignarCantidadPrestamosRealizados(BibliotecarioEntity oBiblio)
        {
            return BibliotecarioDAL.AsignarCantidadPrestamosRealizados(oBiblio);
        }

        public static int GetIdBibliotecario(string pCodUsuario)
        {
            return BibliotecarioDAL.GetIdBibliotecarioByCodUsuario(pCodUsuario);
        }

        public static DataTable ShowEmpleados()
        {
            return BibliotecarioDAL.ShowEmpleado();
        }

        public static int VerificarCedulaBibliotecario(int idEmpleado, string Cedula)
        {
             return BibliotecarioDAL.VerificarCedulaBibliotecario(idEmpleado, Cedula);
        }
    }
}
