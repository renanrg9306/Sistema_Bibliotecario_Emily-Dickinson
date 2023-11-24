using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EditorialEntity
    {
        private int _idEditorial;

        public int IdEditorial
        {
            get { return _idEditorial; }
            set { _idEditorial = value; }
        }
        private string _Editorial;

        public string Editorial
        {
            get { return _Editorial; }
            set { _Editorial = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
