using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;

namespace BLL
{
    public class EdicionBLL
    {
        public static DataTable ShowEdicion()
        {
            return EdicionDAL.ShowEdicion();
        }

        public static bool InsertEdicion(EdicionEntity oEdicion)
        {
            return EdicionDAL.InsertEdicion(oEdicion);
        }
    }
}
