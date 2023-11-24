using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;
using System.Data.SqlClient;


namespace BLL
{
    public class AudiobookBLL
    {
        public static DataTable ShowAudiobook()
        {
            return AudioBookDAL.ShowAudiobook();
        }

        public static bool InsertAudioBook(AudioBookEntity oAB)
        {
            return AudioBookDAL.InsertAudioBook(oAB);
        }

        public static AudioBookEntity GetAllDataAudioBook(int idAudioBook)
        {
            return AudioBookDAL.GetAllDataAudioBook(idAudioBook);
        }

        public static bool UpdateAudioBook(AudioBookEntity oAB)
        {
            return AudioBookDAL.UpdateAudioBook(oAB);
        }

        public static bool DeleteAudioBook(AudioBookEntity oAB)
        {
            return AudioBookDAL.DeleteAudioBook(oAB);
        }

        public static DataTable ShowMaterialAudiobook()
        {
            return AudioBookDAL.ShowMaterialAudiobook();
        }

        public static AudioBookEntity GetCantidadAudiobook(int idMaterial)
        {
            return AudioBookDAL.GetCantidadAudioBook(idMaterial);
        }

        public static bool AsiganarCantidadPrestadaAudiobook(AudioBookEntity oAB)
        {
            return AudioBookDAL.AsignarCantidadPrestadaAudioBooks(oAB);
        }
        public static DataTable RptABByClas_Autor(int idAutor, int idClasificacion)
        {
            return AudioBookDAL.RptABByClasificacion_Autor(idAutor, idClasificacion);
        }
    }
}
