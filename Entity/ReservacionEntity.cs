using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ReservacionEntity
    {
        public ReservacionEntity()
        {
            MaterialEntity = new MaterialEntity();
            VisitanteEntity = new VisitanteEntity();

        
        }

        private int _idResercacion;

        public int IdResercacion
        {
            get { return _idResercacion; }
            set { _idResercacion = value; }
        }
        private MaterialEntity _MaterialEntity;

        public MaterialEntity MaterialEntity
        {
            get { return _MaterialEntity; }
            set { _MaterialEntity = value; }
        }
        private VisitanteEntity _VisitanteEntity;

        public VisitanteEntity VisitanteEntity
        {
            get { return _VisitanteEntity; }
            set { _VisitanteEntity = value; }
        }
        private DateTime _FechaReservacionDia;

        public DateTime FechaReservacionDia
        {
            get { return _FechaReservacionDia; }
            set { _FechaReservacionDia = value; }
        }
        private DateTime _FechaReservacionEntrega;

        public DateTime FechaReservacionEntrega
        {
            get { return _FechaReservacionEntrega; }
            set { _FechaReservacionEntrega = value; }
        }
        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private bool _EstadoEliminado;

        public bool EstadoEliminado
        {
            get { return _EstadoEliminado; }
            set { _EstadoEliminado = value; }
        }
    }
}
