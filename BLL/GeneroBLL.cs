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
    public class GeneroBLL
    {
        public static DataTable ShowGenero()
        {
            return GeneroDAL.ShowGenero();
        }

        public static bool InsertGenero(GeneroEntity oGenero)
        {
            return GeneroDAL.InsertGenero(oGenero);
        }
    }
}
