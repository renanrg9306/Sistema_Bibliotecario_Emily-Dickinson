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
    public class DirectorBLL
    {
        public static DataTable ShowDirector()
        {
            return DirectorDAL.ShowDirector();
        }

        public static bool InsertDirector(DirectorEntity oDirec)
        {
            return DirectorDAL.InsertDirector(oDirec);
        }
    }
}
