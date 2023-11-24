using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EntregaPrestamoEntity:PrestamoEntity
    {
        public EntregaPrestamoEntity()
        {
            ProrrogaEntity = new ProrrogaPrestamoEntity();
        }
        private int _idEntregaP;

        public int IdEntregaP
        {
            get { return _idEntregaP; }
            set { _idEntregaP = value; }
        }
        private DateTime _FechaDevolucion;

        public DateTime FechaDevolucion
        {
            get { return _FechaDevolucion; }
            set { _FechaDevolucion = value; }
        }

       
        private bool _POR;

        public bool POR
        {
            get { return _POR; }
            set { _POR = value; }
        }

        private DateTime _Fecha_Recepcion;

        public DateTime Fecha_Recepcion
        {
            get { return _Fecha_Recepcion; }
            set { _Fecha_Recepcion = value; }
        }

        private string _Recepcionado_Por;

        public string Recepcionado_Por
        {
            get { return _Recepcionado_Por; }
            set { _Recepcionado_Por = value; }
        }

        private ProrrogaPrestamoEntity _ProrrogaEntity;

        public ProrrogaPrestamoEntity ProrrogaEntity
        {
            get { return _ProrrogaEntity; }
            set { _ProrrogaEntity = value; }
        }
    }
}
