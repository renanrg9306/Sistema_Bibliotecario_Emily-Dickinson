using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entity;

namespace BLL
{
    public class AnioBLL
    {
        public static DataTable GetAnio()
        {
            return AnioDAL.ShowAnio();
        }
    }
}
