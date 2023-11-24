using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using OtherFunction;

namespace DAL
{
    public class EnvioCorreoDAL
    {
        public static bool EnviarCorreo(string Subject, string BodyMsg, string Correo)
        {
            return oFn.EnviarCorreo(Subject, BodyMsg, Correo);
        }
    }
}
