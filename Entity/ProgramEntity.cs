using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProgramEntity
    {
        private int _idProgram;

        public int IdProgram
        {
            get { return _idProgram; }
            set { _idProgram = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

    }
}
