using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;
using OtherFunction;

namespace DAL
{
    public class OcupacionDAL
    {
        public static bool InsertOcupacion(OcupacionEntity oOcupacion)
        {
            SqlConnection cn = new SqlConnection();
            string Sp = "Sp_InsertOcupacion";

            try
            {
                cn = oFn.GetConnection();
                SqlCommand sqlcmd = new SqlCommand(Sp, cn);
                cn.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("Ocupacion", oOcupacion.Ocupacion);
                sqlcmd.Parameters.AddWithValue("Estado", oOcupacion.Estado);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public static DataTable ShowOcupacion()
        {
            try
            {
                string Sp = "Sp_ShowOcupacion";
                return oFn.Leer(Sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
