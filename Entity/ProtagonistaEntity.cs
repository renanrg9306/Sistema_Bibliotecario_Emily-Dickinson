using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProtagonistaEntity
    {
        private int _idProtagonistra;

        public int IdProtagonistra
        {
            get { return _idProtagonistra; }
            set { _idProtagonistra = value; }
        }
        private string _NombreProtagonista;

        public string NombreProtagonista
        {
            get { return _NombreProtagonista; }
            set { _NombreProtagonista = value; }
        }
        private string _ApellidoProtagonista;

        public string ApellidoProtagonista
        {
            get { return _ApellidoProtagonista; }
            set { _ApellidoProtagonista = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}
