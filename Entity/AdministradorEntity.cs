using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AdministradorEntity:EmpleadoEntity //Hereda de la clase empleado todo sus atributos
    {
        public AdministradorEntity()
        {
            AutenticacionEntity = new AutenticacionEntity();
        }

        private int _idAdministador;

        public int IdAdministador
        {
            get { return _idAdministador; }
            set { _idAdministador = value; }
        }
        private AutenticacionEntity _AutenticacionEntity;

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
