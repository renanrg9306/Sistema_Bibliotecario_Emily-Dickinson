using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using OtherFunction;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TipoPrestamoDAL
    {
        public static DataTable ShowTipoPrestamo()
        {
            return oFn.Leer("Sp_ShowTipoPrestamo");
        }
    }
}
