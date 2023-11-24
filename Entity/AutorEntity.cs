using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AutorEntity
    {
        private int _idAutor;

        public int IdAutor
        {
            get { return _idAutor; }
            set { _idAutor = value; }
        }
        private string _NombreAutor;

        public string NombreAutor
        {
            get { return _NombreAutor; }
            set { _NombreAutor = value; }
        }
        private string _ApellidoAutor;

        public string ApellidoAutor
        {
            get { return _ApellidoAutor; }
            set { _ApellidoAutor = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}
