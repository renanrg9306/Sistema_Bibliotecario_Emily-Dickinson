using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class ProrrogaBLL
    {
        public static bool PrimerProrroga(ProrrogaPrestamoEntity oProrroga)
        {
            return ProrrogaPrestamoDAL.PrimeraProrroga(oProrroga);
        }

        public static bool SegundaProrroga(ProrrogaPrestamoEntity oProrroga)
        {
            return ProrrogaPrestamoDAL.SegundaProrroga(oProrroga);
        }
        public static ProrrogaPrestamoEntity GetIdPrrogaC(int idEntregaPrestamo)
        {
            return ProrrogaPrestamoDAL.GetIdProrrogaC(idEntregaPrestamo);
        }
        public static ProrrogaPrestamoEntity GetPrimeraProrroga(int idProrroga)
        {
            return ProrrogaPrestamoDAL.GetPrimeraProrroga(idProrroga);
        }
        public static ProrrogaPrestamoEntity GetSegundaProrroga(int idProrroga)
        {
            return ProrrogaPrestamoDAL.GetSegundaProrroga(idProrroga);
        }
        public static string GetFechaDevolucion(int IdEntrega_Prestamo)
        {
            return EntregaPrestamoDAL.GetFechaDevolucion(IdEntrega_Prestamo);
        }
    }
}
