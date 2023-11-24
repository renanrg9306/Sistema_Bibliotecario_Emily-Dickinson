using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PrestamoEntity
    {
        public PrestamoEntity()
        {
            MaterialEntity = new MaterialEntity();
            EmpleadoEntity = new EmpleadoEntity();
            VisitanteEntity = new VisitanteEntity();
            TipoPrestamo = new TipoPrestamoEntity();
        
        }
        private int _idPrestamo;

        public int IdPrestamo
        {
            get { return _idPrestamo; }
            set { _idPrestamo = value; }
        }
        private DateTime _FechaPrestamo;

        public DateTime FechaPrestamo
        {
            get { return _FechaPrestamo; }
            set { _FechaPrestamo = value; }
        }
        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

  
        private EmpleadoEntity _EmpleadoEntity;

        public EmpleadoEntity EmpleadoEntity
        {
            get { return _EmpleadoEntity; }
            set { _EmpleadoEntity = value; }
        }
       
        private MaterialEntity _MaterialEntity;

        public MaterialEntity MaterialEntity
        {
            get { return _MaterialEntity; }
            set { _MaterialEntity = value; }
        }
        private TipoPrestamoEntity _TipoPrestamo;

        public TipoPrestamoEntity TipoPrestamo
        {
            get { return _TipoPrestamo; }
            set { _TipoPrestamo = value; }
        }
        private VisitanteEntity _VisitanteEntity;

        public VisitanteEntity VisitanteEntity
        {
            get { return _VisitanteEntity; }
            set { _VisitanteEntity = value; }
        }

    }
}
