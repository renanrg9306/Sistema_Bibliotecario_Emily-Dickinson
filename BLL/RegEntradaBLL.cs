using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
   public class RegEntradaBLL
    {
       public static DataTable GetRegEntrada(int idRegEntrada)
       {
           return RegistroEntradaDAL.GetRegEntrada(idRegEntrada);
       }
       public static DataTable ShowRegEntrada()
       {
           return RegistroEntradaDAL.ShowRegEntrada();
       }

       public static bool InsertRegEntrada(RegEntradaEntity oRegE)
       {
           return RegistroEntradaDAL.InsertRegEntrada(oRegE);
       }

       public static RegEntradaEntity GetById(int idRegE)
       {
           return RegistroEntradaDAL.GetRegEntradaById(idRegE);
       }
       public static bool UpdateRegEntrada(RegEntradaEntity oRegE)
       {
           return RegistroEntradaDAL.UpdateRegEntrada(oRegE);
       }

       public static bool DeleteRegEntrada(RegEntradaEntity oRegE)
       {
           return RegistroEntradaDAL.DeleteRegEntrada(oRegE);
       }
    }
}
