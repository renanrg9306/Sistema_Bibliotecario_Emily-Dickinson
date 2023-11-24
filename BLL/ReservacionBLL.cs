using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;

namespace BLL
{
    public class ReservacionBLL
    {
        public static bool InsertResevacion(ReservacionEntity oReservacion)
        {
            return ReservacionDAL.InsertReservacion(oReservacion);
        }

        public static DataTable ShowAllReservaciones()
        {
            return ReservacionDAL.ShowAllReservaciones();
        }

        public static ReservacionEntity ReservacionAPrestamo(int idReservacion)
        {
            return ReservacionDAL.ReservacionAPrestamo(idReservacion);
        }

        public static bool EstadoEntregadoReservacion(ReservacionEntity oReservacion)
        {
            return ReservacionDAL.EstadoEntregadoReservacion(oReservacion);
        }

        public static DataTable ShowReservacionesSinEntegarByVisitante(int idVisitante)
        {
            return ReservacionDAL.ShowReservacionSinEntregarByVisitante(idVisitante);
        }

        public static bool DeleteReservacion(ReservacionEntity oReservacion)
        {
            return ReservacionDAL.DeleteReservacion(oReservacion);
        }

    }
}
