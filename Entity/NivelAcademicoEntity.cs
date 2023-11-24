using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NivelAcademicoEntity
    {
        private int _idNivelAca;

        public int IdNivelAca
        {
            get { return _idNivelAca; }
            set { _idNivelAca = value; }
        }
        private string _NivelAca;

        public string NivelAca
        {
            get { return _NivelAca; }
            set { _NivelAca = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
