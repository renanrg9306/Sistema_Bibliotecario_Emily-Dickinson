using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class AutenticacionEntity
    {
        private int _idUsuario;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        private string _CodUsuario;

        public string CodUsuario
        {
            get { return _CodUsuario; }
            set { _CodUsuario = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

       
       
    }
}
