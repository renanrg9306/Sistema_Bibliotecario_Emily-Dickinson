using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace BLL
{
    public class ClasificacionBLL
    {
        public static DataTable GetClasificacion(int idClasificacion)
        {
            return ClasificacionDAL.GetClasificacion(idClasificacion);
        }

        public static DataTable SearchClasificacion(string Clasificacion)
        {
            return ClasificacionDAL.SearchClasificacion(Clasificacion);
        }

        public static int InsertClasificacion(ClasificacionEntity oCla)
        {
            return ClasificacionDAL.InsertClasificacion(oCla);
        }

        public static ClasificacionEntity GetClasificacioById(int idClasificacion)
        {
            return ClasificacionDAL.GetClasificacionById(idClasificacion);
        }
        public static bool UpdateClasificacion(ClasificacionEntity oCla)
        {
            return ClasificacionDAL.UpdateClasificacion(oCla);
        }
        public static bool DeleteClasificacion(ClasificacionEntity oCla)
        {
            return ClasificacionDAL.DeleteClasificacion(oCla);
        }
        public static DataTable ShowClasificacion()
        {
            return ClasificacionDAL.ShowClasificacion();
        }
    }
}
