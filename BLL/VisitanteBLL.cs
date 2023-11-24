using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entity;

namespace BLL
{
    public class VisitanteBLL
    {
        public static DataTable SesionVisitante(string pCodUsuario, string pPass)
        {
            return VisitanteDAL.GetUserVisitante(pCodUsuario, pPass);
        }

        public static string GetDatoUserByCodUsuario(string pCodUsuario)
        {
            return VisitanteDAL.GetDatoUserByCodUsuario(pCodUsuario);
        }

        public static DataTable ShowVisitante()
        {
            return VisitanteDAL.ShowVisitante();
        }

        public static string GenerarCarnetVisitante(DateTime pAnio, int pCantidad, char pGenero)
        {
            return VisitanteDAL.GenerarCarnetVisitante(pAnio, pCantidad, pGenero);
        }

        public static string CreatePassowrd(string Telefono)
        {
            return VisitanteDAL.CreatePassword(Telefono);
        }

        public static bool InsertAutenticacionVisitante(VisitanteEntity oVisitante)
        {
            return VisitanteDAL.AutenticacionVisitante(oVisitante);
        
        }

        public static int InsertVisitante(VisitanteEntity oVisitante)
        {
            return VisitanteDAL.InsertVisitante(oVisitante);
        }

        public static VisitanteEntity GetVisitante(int idVisitante)
        {
            return VisitanteDAL.GetVisitante(idVisitante);
        }

        public static bool UpdateVisitante(VisitanteEntity oVisitante)
        {
            return VisitanteDAL.UdpateVisitante(oVisitante);
        }

        public static bool UpdatePassowrd(VisitanteEntity oVisitante)
        {
            return VisitanteDAL.UpdatePassword(oVisitante);
        }

        public static bool DeleteVisitante(VisitanteEntity oVisitante)
        {
            return VisitanteDAL.DeleteVisitante(oVisitante);
        }

        public static int GetIdVisitante(string pCodUsuario)
        {
            return VisitanteDAL.GetIdVisitante(pCodUsuario);
        }

        public static string RecoverPasswordVisitante(string CodUsuario, string Correo)
        {
            return VisitanteDAL.RecoverPasswordVisitante(CodUsuario, Correo);
        }

        public static int VerificarPrestamosVisitante(int idVisitante)
        {
            return VisitanteDAL.VerificarPrestamosVisitante(idVisitante);
        }

        public static bool AsignarCantidadPrestamosVisitante(VisitanteEntity oVisitante)
        {
            return VisitanteDAL.AsignarCantidadPrestamosRealizados(oVisitante);
        }
    }
}
