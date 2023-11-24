using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;
namespace BLL
{
    public class RevistaBLL
    {
        public static bool InsertRevista(RevistaEntity oRevista)
        {
           return RevistaDAL.InsertRevista(oRevista);
        }

        public static DataTable ShowRevista()
        {
            return RevistaDAL.ShowRevista();
        }

        public static RevistaEntity GetRevista(int idRevista)
        {
            return RevistaDAL.GetRevista(idRevista);
        }

        public static bool UpdateRevista(RevistaEntity oRevista)
        {
            return RevistaDAL.UpdateRevista(oRevista);
        }

        public static bool DeleteRevista(RevistaEntity oRevista)
        {
            return RevistaDAL.DeleteRevista(oRevista);
        }
        public static DataTable ShowMaterialRevista()
        {
            return RevistaDAL.ShowMaterialRevista();
        }

        public static RevistaEntity GetCantidadRevista(int idMaterial)
        {
            return RevistaDAL.GetCantidadRevista(idMaterial);
        }

        public static bool AsignarCantidadPrestadaRevista(RevistaEntity oRevista)
        {
            return RevistaDAL.AsignarCantidadPrestadaRevista(oRevista);
        }

        public static DataTable RptRevistaxAutor(int idAutor)
        {
            return RevistaDAL.ReporteRevistaxAu(idAutor);
        }

        public static DataTable RptRevistaxCla(int idClasificacion)
        {
            return RevistaDAL.ReporteRevistaxCla(idClasificacion);
        }

        public static DataTable RptRevistaxAuyCla(int idAutor, int idClasificacion)
        {
            return RevistaDAL.ReporteRevistaxAuyCla(idAutor, idClasificacion);
        }
    }
}
