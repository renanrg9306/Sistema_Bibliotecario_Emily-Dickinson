using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProrrogaPrestamoEntity
    {
        public ProrrogaPrestamoEntity()
        {
            PrestamoEntity = new PrestamoEntity();
        }
        private int _idProrroga;

        public int IdProrroga
        {
            get { return _idProrroga; }
            set { _idProrroga = value; }
        }
        private DateTime _Prorroga1;

        public DateTime Prorroga1
        {
            get { return _Prorroga1; }
            set { _Prorroga1 = value; }
        }
        private DateTime _Prorroga2;

        public DateTime Prorroga2
        {
            get { return _Prorroga2; }
            set { _Prorroga2 = value; }
        }

        private int _CantidadProrroga;

        public int CantidadProrroga
        {
            get { return _CantidadProrroga; }
            set { _CantidadProrroga = value; }
        }

        private PrestamoEntity _PrestamoEntity;

        public PrestamoEntity PrestamoEntity
        {
            get { return _PrestamoEntity; }
            set { _PrestamoEntity = value; }
        }
    }
}
