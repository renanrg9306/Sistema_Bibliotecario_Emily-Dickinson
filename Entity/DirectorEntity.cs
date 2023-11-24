using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DirectorEntity
    {
        private int _idDirector;

        public int IdDirector
        {
            get { return _idDirector; }
            set { _idDirector = value; }
        }
        private string _NombreDirector;

        public string NombreDirector
        {
            get { return _NombreDirector; }
            set { _NombreDirector = value; }
        }
        private string _ApellidosDirector;

        public string ApellidosDirector
        {
            get { return _ApellidosDirector; }
            set { _ApellidosDirector = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
