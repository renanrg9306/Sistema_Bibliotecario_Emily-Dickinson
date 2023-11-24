using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpleadoEntity
    {
        public EmpleadoEntity() 
        {
            NivelAcademicoEntity = new NivelAcademicoEntity();
        }

       
        private int _idEmpleado;

        public int IdEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; }
        }

        private NivelAcademicoEntity _NivelAcademicoEntity;

        public NivelAcademicoEntity NivelAcademicoEntity
        {
            get { return _NivelAcademicoEntity; }
            set { _NivelAcademicoEntity = value; }
        }

        private string _Nombres;

        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }
        private string _Apellidos;

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
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
        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private string _Correo;

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        private DateTime _FechaIngreso;

        public DateTime FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }

        private int _CantidadPrestamosRealizados;

        public int CantidadPrestamosRealizados
        {
            get { return _CantidadPrestamosRealizados; }
            set { _CantidadPrestamosRealizados = value; }
        }

        private bool _Estado;

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}
