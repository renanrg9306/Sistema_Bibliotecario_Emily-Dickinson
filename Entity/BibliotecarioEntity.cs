using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BibliotecarioEntity:EmpleadoEntity
    {
        public BibliotecarioEntity()
        {
            AutenticacionEntity = new AutenticacionEntity();
        }

        private int _idBibliotecario;

        public int IdBibliotecario
        {
            get { return _idBibliotecario; }
            set { _idBibliotecario = value; }
        }
        AutenticacionEntity _AutenticacionEntity;

        public AutenticacionEntity AutenticacionEntity
        {
            get { return _AutenticacionEntity; }
            set { _AutenticacionEntity = value; }
        }
        private string _CodUsuario;

        public string CodUsuario
        {
            get { return _CodUsuario; }
            set { _CodUsuario = value; }
        }

    }
}
