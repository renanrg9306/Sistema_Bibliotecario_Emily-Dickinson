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
    public class MaterialBLL
    {
        public static bool ActualizarExistenciaMaterialPrestado(MaterialEntity oMaterial)
        {
            return MaterialDAL.ActualizarExistenciaMaterial(oMaterial);
        }

        public static DataTable ShowMaterial()
        {
            return MaterialDAL.ShowMaterial();
        }

        public static MaterialEntity GetCantidadMaterial(int idMaterial)
        {
            return MaterialDAL.GetCantidaMaterial(idMaterial);
        }

        public static bool AsignarReservacion(MaterialEntity oMaterial)
        {
            return MaterialDAL.AsignarReservacion(oMaterial);
        
        }

        public static bool AsignarCantidadPrestada(MaterialEntity oMaterial)
        {
            return MaterialDAL.AsignarCantidadPrestadaMaterial(oMaterial);
        }

        public static bool EntregarReservacion(MaterialEntity oMaterial)
        {
            return MaterialDAL.EntregarReservacion(oMaterial);
        }
        public static byte[] MostrarImagenMaterial(int idMaterial)
        {
            return MaterialDAL.MostrarImagen(idMaterial);        
        }

        public static bool ActualizarImgMaterial(MaterialEntity oMaterial)
        {
            return MaterialDAL.ActualizarImgMaterial(oMaterial);
        }
    }
}
