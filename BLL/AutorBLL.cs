using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entity;

namespace BLL
{
    public class AutorBLL
    {
        public static DataTable GetAutor(int idAutor)
        {
            return AutorDAL.GetAutor(idAutor); 
        }

        public static DataTable ShowAutor()
        {
            return AutorDAL.ShowAutor();
        }

        public static bool InsertAutor(AutorEntity oAutor)
        {
            return AutorDAL.InsertAutor(oAutor);
        }

        public static AutorEntity GetAutorById(int idAutor)
        {
            return AutorDAL.GetAutorById(idAutor);
        }

        public static bool UpdateAutor(AutorEntity oAutor)
        {
            return AutorDAL.UpdateAutor(oAutor);        
        }

        public static bool DeleteAutor(AutorEntity oAutor)
        {
            return AutorDAL.DeleteAutor(oAutor);
        }
    }
}
