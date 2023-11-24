using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public  class EnvioCorreoBLL
    {
       public static bool EnviarCorreo(string Subject, string BodyMsg, string Correo)
       {
           return EnvioCorreoDAL.EnviarCorreo(Subject,BodyMsg,Correo);
       }
    }
}
