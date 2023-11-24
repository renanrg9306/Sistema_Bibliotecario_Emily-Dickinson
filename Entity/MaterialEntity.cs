using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MaterialEntity
    {

        public MaterialEntity()//METODO CONSTRUCTOR
        {
            RegEntradaEntity = new RegEntradaEntity();
            ClasificacionEntity = new ClasificacionEntity();
        
        }
        private RegEntradaEntity _RegEntradaEntity;

        public RegEntradaEntity RegEntradaEntity
        {
            get { return _RegEntradaEntity; }
            set { _RegEntradaEntity = value; }
        }

        private ClasificacionEntity _ClasificacionEntity;

        public ClasificacionEntity ClasificacionEntity
        {
            get { return _ClasificacionEntity; }
            set { _ClasificacionEntity = value; }
        }
        
        private int _idMaterial;

        public int IdMaterial
        {
            get { return _idMaterial; }
            set { _idMaterial = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private string _Condicion;

        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private DateTime _Fecha_Recep;

        public DateTime Fecha_Recep
        {
            get { return _Fecha_Recep; }
            set { _Fecha_Recep = value; }
        }

        private string _Desripcion;

        public string Desripcion
        {
            get { return _Desripcion; }
            set { _Desripcion = value; }
        }

        private int _Prestado;

        public int Prestado
        {
            get { return _Prestado; }
            set { _Prestado = value; }
        }

        private int _Reservado;

        public int Reservado
        {
            get { return _Reservado; }
            set { _Reservado = value; }
        }


        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private byte[] _ImgMaterial;

        public byte[] ImgMaterial
        {
            get { return _ImgMaterial; }
            set { _ImgMaterial = value; }
        }
    }
}
