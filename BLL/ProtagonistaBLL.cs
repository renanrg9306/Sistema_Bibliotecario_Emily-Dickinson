using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using DAL;

namespace BLL
{
    public class ProtagonistaBLL
    {
        public static DataTable ShowProtagonista()
        {
            return ProtagonistaDAL.ShowProtagonista();
        }

        public static bool InsertProtagonista(ProtagonistaEntity oProt)
        {
            return ProtagonistaDAL.InsertProtagonista(oProt);
        }
    }
}
