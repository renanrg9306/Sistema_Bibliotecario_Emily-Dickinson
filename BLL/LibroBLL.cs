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
    public class LibroBLL
    {
        public static DataTable ShowLibros()
        {
            return LibroDAL.ShowAudiobook();
        }

        public static LibroEntity GetAllDataLibro(int idLibro)
        {
            return LibroDAL.GetLibro(idLibro);
        }

        public static bool InsertLibro(LibroEntity oLibro)
        {
            return LibroDAL.InsertLibro(oLibro);
        }

        public static bool UpdateLibro(LibroEntity oLibro)
        {
            return LibroDAL.UpdateLibro(oLibro);
        }

        public static bool DeleteLibro(LibroEntity oLibro)
        {
            return LibroDAL.DeleteLibro(oLibro);
        }

        public static DataTable ShowMateriaLibro()
        {
            return LibroDAL.ShowMaterialLibro();
        }
        public static LibroEntity GetCantidadLibro(int idMaterial)
        {
            return LibroDAL.GetCantidadLibro(idMaterial);
        }

        public static bool AsiganarCantidadPrestadaLibro(LibroEntity oLibro)
        {
            return LibroDAL.AsignarCantidadPrestadaLibro(oLibro);
        }

        public static bool VerificarISBNLibro(int idLibro ,string ISBN)
        {
            return LibroDAL.VerificarMatrialISBN(idLibro,ISBN);
        }

        public static DataTable ReporteLibroxAutor(int pidAutor)
        {
            return LibroDAL.ReporteLibroxAutor(pidAutor);
        }

        public static DataTable ReporteLibroxClasificacion(int idClasificacion)
        {
            return LibroDAL.ReporteLibroxClasificacion(idClasificacion);
        }
        public static DataTable ReporteLibroxClayAu(int idClasificacion, int idAutor)
        {
            return LibroDAL.ReporteLibroxClayAutor(idClasificacion, idAutor);
        }
    }
}
