using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegEntradaEntity
    {
        private int _idRegEntrada;

        public int IdRegEntrada
        {
            get { return _idRegEntrada; }
            set { _idRegEntrada = value; }
        }

        private string _Origen;

        public string Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}
