using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class VisitanteEntity
    {

       public VisitanteEntity()
       {
           ProgramEntity = new ProgramEntity();
           AutenticacionEntity = new AutenticacionEntity();
           OcupacionEntity = new OcupacionEntity();

       }

        private ProgramEntity _ProgramEntity;

        public ProgramEntity ProgramEntity
        {
            get { return _ProgramEntity; }
            set { _ProgramEntity = value; }
        }
       
       private AutenticacionEntity _AutenticacionEntity;

        public AutenticacionEntity AutenticacionEntity
        {
            get { return _AutenticacionEntity; }
            set { _AutenticacionEntity = value; }
        }
       
       private int _idVisitante;

        public int IdVisitante
        {
            get { return _idVisitante; }
            set { _idVisitante = value; }
        }

        private string _CodUsuario;

        public string CodUsuario
        {
            get { return _CodUsuario; }
            set { _CodUsuario = value; }
        }


        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }
        private short _Edad;

        public short Edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }
        private char _Genero;

        public char Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }
        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private OcupacionEntity _OcupacionEntity;

        public OcupacionEntity OcupacionEntity
        {
            get { return _OcupacionEntity; }
            set { _OcupacionEntity = value; }
        }
      


        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private DateTime _FechaIngreso;

        public DateTime FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }
        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private int _Prestado;

        public int Prestado
        {
            get { return _Prestado; }
            set { _Prestado = value; }
        }
    }
}
