using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TipoPrestamoEntity
    {
        private int _idTipoPrestamo;

        public int IdTipoPrestamo
        {
            get { return _idTipoPrestamo; }
            set { _idTipoPrestamo = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
