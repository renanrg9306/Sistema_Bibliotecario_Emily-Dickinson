using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AnioEntity
    {
        private int _idAnio;

        public int IdAnio
        {
            get { return _idAnio; }
            set { _idAnio = value; }
        }
        private int _Anio;

        public int Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}
