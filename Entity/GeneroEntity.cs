using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GeneroEntity
    {
        private int _idGenero;

        public int IdGenero
        {
            get { return _idGenero; }
            set { _idGenero = value; }
        }
        private string _Genero;

        public string Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}
