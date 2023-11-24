using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EdicionEntity
    {

        public EdicionEntity()
        {
            AnioEntity = new AnioEntity();
        }

        private int _idEdicion;

        public int IdEdicion
        {
            get { return _idEdicion; }
            set { _idEdicion = value; }
        }
        private string _Edicion;

        public string Edicion
        {
            get { return _Edicion; }
            set { _Edicion = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private AnioEntity _AnioEntity;

        public AnioEntity AnioEntity
        {
            get { return _AnioEntity; }
            set { _AnioEntity = value; }
        }

    }
}
