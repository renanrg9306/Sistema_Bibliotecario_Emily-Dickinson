using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OcupacionEntity
    {
        private int _idOcupacion;

        public int IdOcupacion
        {
            get { return _idOcupacion; }
            set { _idOcupacion = value; }
        }
        private string _Ocupacion;

        public string Ocupacion
        {
            get { return _Ocupacion; }
            set { _Ocupacion = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
