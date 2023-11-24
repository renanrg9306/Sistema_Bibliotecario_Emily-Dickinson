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
    public class PeliculaBLL
    {
        public static bool InsertPelicula(PeliculaEntity oPelicula)
        {
            return PeliculaDAL.InsertPelicula(oPelicula);
        }

        public static DataTable ShowPelicula()
        {
            return PeliculaDAL.ShowPelicula();
        }

        public static PeliculaEntity GetPelicula(int idPelicula)
        {
            return PeliculaDAL.GetPelicula(idPelicula);
        }

        public static bool UpdatePelicula(PeliculaEntity oPel)
        {
            return PeliculaDAL.UpdatePelicula(oPel);
        }

        public static bool DeletePelicula(PeliculaEntity oPel)
        {
            return PeliculaDAL.DeletePelicula(oPel);
        }

        public static DataTable ShowMaterialPelicula()
        {
            return PeliculaDAL.ShowMaterialPelicula();
        }
        public static PeliculaEntity GetCantidadPelicula(int idMaterial)
        {
            return PeliculaDAL.GetCantidadPelicula(idMaterial);
        }

        public static bool AsignarCantidadPrestaPelicula(PeliculaEntity oPelicula)
        {
            return PeliculaDAL.AsignarCantidadPrestadaPelicula(oPelicula);
        }

        public static DataTable ReportePeliculaxProtagonista(int idProtagonista)
        {
            return PeliculaDAL.ReportePeliculaxProtagonista(idProtagonista);
        }

        public static DataTable ReportePeliculaxClasificacion(int idProtagonista)
        {
            return PeliculaDAL.ReportePeliculaxClasificacion(idProtagonista);
        }

        public static DataTable ReportePexClayPro(int idClasificacion, int idProtagonista)
        {
            return PeliculaDAL.ReportePexClayPro(idClasificacion, idProtagonista);
        }
    }
}
