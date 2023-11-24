using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RevistaEntity:MaterialEntity
    {
        public RevistaEntity()
        {
            AutorEntity = new AutorEntity();
            EditorialEntity = new EditorialEntity();
            EdicionEntity = new EdicionEntity();
        }

        private int _idRevista;

        public int IdRevista
        {
            get { return _idRevista; }
            set { _idRevista = value; }
        }
        private AutorEntity _AutorEntity;

        public AutorEntity AutorEntity
        {
            get { return _AutorEntity; }
            set { _AutorEntity = value; }
        }

        private EditorialEntity _EditorialEntity;

        public EditorialEntity EditorialEntity
        {
            get { return _EditorialEntity; }
            set { _EditorialEntity = value; }
        }
        private EdicionEntity _EdicionEntity;

        public EdicionEntity EdicionEntity
        {
            get { return _EdicionEntity; }
            set { _EdicionEntity = value; }
        }

        private string _Volumen;

        public string Volumen
        {
            get { return _Volumen; }
            set { _Volumen = value; }
        }


    }
}
