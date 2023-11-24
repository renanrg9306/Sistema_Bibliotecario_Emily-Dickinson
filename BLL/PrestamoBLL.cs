using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;

namespace BLL
{
    public class PrestamoBLL
    {
        public static int InsertEntregaPrestamo(EntregaPrestamoEntity oPrestamo)
        {
            return PrestamoDAL.EntregaPrestamo(oPrestamo);
        
        }
        public static DataTable ShowPrestamos()
        {
            return PrestamoDAL.ShowPrestamos();
        }

        public static EntregaPrestamoEntity GetCantidadPrestamo(int idEntrega_Prestamo)
        {
            return EntregaPrestamoDAL.GetCantidadPrestamo(idEntrega_Prestamo);
        
        }

        public static bool UMaterialRecepcionado(EntregaPrestamoEntity oEP)
        {
            return EntregaPrestamoDAL.UMaterialRecepcionado(oEP);
        }

        public static DataTable MaterialRecepcionado()
        {
            return PrestamoDAL.MaterialRecepcionado();
        }
     
        public static DataTable ShowPrestamosPendientes(int idVisitante)
        {
            return PrestamoDAL.ShowPrestamosPrendientes(idVisitante);
        }

        public static DataTable ShowPrestamosEntregados(int idVisitante)
        {
            return PrestamoDAL.ShowPrestamosEntregados(idVisitante);
        }

        public static DataTable RptPrestamosRealizados(DateTime Fecha1, DateTime Fecha2, int idEmpleado)
        {
            return PrestamoDAL.RptPrestamosRealizados(Fecha1, Fecha2, idEmpleado);
        }

        public static DataTable RptPrestamosRecepcionados(DateTime Fecha1, DateTime Fecha2, string NombreEmpleado)
        {
            return PrestamoDAL.RptPrestamosRecepcionados(Fecha1, Fecha2, NombreEmpleado);
        }

        public static DataTable RptHistorialMa(DateTime Fecha1, DateTime Fecha2, int idMaterial)
        {
            return PrestamoDAL.RptHistorialMa(Fecha1, Fecha2, idMaterial);
        }

        public static DataTable RptHistorialVisitante(DateTime Fecha1, DateTime Fecha2, int idVisitante)
        {
            return PrestamoDAL.RptHistorialVisitante(Fecha1, Fecha2, idVisitante);     
        }

        public static DataTable RptPrePro(DateTime Fecha1, DateTime Fecha2)
        {
            return PrestamoDAL.RptPrePro(Fecha1, Fecha2);
        }

    }
}
