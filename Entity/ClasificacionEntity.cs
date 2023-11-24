using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ClasificacionEntity
    {
        private int _idClasificacion;

        public int IdClasificacion
        {
            get { return _idClasificacion; }
            set { _idClasificacion = value; }
        }

        private string _Clasificacion;

        public string Clasificacion
        {
            get { return _Clasificacion; }
            set { _Clasificacion = value; }
        }

        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
