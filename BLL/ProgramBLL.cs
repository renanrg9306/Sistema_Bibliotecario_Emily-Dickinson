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
    public class ProgramBLL
    {
        public static bool InsertProgram(ProgramEntity oProgram)
        {
            return ProgramDAL.InsertProgram(oProgram);
        }

        public static DataTable ShowProgram()
        {
            return ProgramDAL.ShowProgram();
        }
    }
}
