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
   public class OcupacionBLL
    {
       public static bool InsertOcupacion(OcupacionEntity oOcupacion)
       {
           return OcupacionDAL.InsertOcupacion(oOcupacion);

       }

       public static DataTable ShowOcupacion()
       {
           return OcupacionDAL.ShowOcupacion();
       }
    }
}
