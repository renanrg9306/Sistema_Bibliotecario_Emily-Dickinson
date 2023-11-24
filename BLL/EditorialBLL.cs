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
    public class EditorialBLL
    {
        public static DataTable GetEditorial(int idEditorial)
        {
            return EditorialDAL.GetEditorial(idEditorial);
        }

        public static bool InsertEditorial(EditorialEntity oEditorial)
        {
            return EditorialDAL.InsertEditorial(oEditorial);
        }

        public static DataTable ShowEditorial()
        {
            return EditorialDAL.ShowEditorial();
        }

    }
}
