using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace BLL
{
    public class NivelAcademicoBLL
    {
        public static DataTable ShowNivelAcademico()
        {
            return NivelAcademicoDAL.ShowNivelAcad();
        }

        public static bool InsertNivelAca(NivelAcademicoEntity oNivelAca)
        {
            return NivelAcademicoDAL.InsertNivelAca(oNivelAca);
        }

        public static DataTable GetNivelAca(int idNivelAca)
        {
            return NivelAcademicoDAL.GetNivelAca(idNivelAca);
        }

        public static NivelAcademicoEntity GetNivelAcaById(int pidNivelAca)
        {
            return NivelAcademicoDAL.GetNivelAcaById(pidNivelAca);
        }

        public static bool ActualizarNivelAca(NivelAcademicoEntity oNivelAca)
        {
            return NivelAcademicoDAL.ActualizarNivelAca(oNivelAca);
        }

        public static bool DeleteNivelAca(NivelAcademicoEntity oNivelAca)
        {
            return NivelAcademicoDAL.DeleteNivelAca(oNivelAca);
        }
    }
}
