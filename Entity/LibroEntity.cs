using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace Entity
{
    public class LibroEntity:MaterialEntity
    {
        public LibroEntity()
        {
            EdicionEntity = new EdicionEntity();
            EditorialEntity = new EditorialEntity();
            AnioEntity = new AnioEntity();
            AutorEntity = new AutorEntity();

            
        }   
        private int _idLibro;

        public int IdLibro
        {
            get { return _idLibro; }
            set { _idLibro = value; }
        }
        private string _ISBN;

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }
        private bool _CuentaConCD;

        public bool CuentaConCD
        {
            get { return _CuentaConCD; }
            set { _CuentaConCD = value; }
        }
        private EdicionEntity _EdicionEntity;

        public EdicionEntity EdicionEntity
        {
            get { return _EdicionEntity; }
            set { _EdicionEntity = value; }
        }
        private EditorialEntity _EditorialEntity;

        public EditorialEntity EditorialEntity
        {
            get { return _EditorialEntity; }
            set { _EditorialEntity = value; }
        }

        private AnioEntity _AnioEntity;

        public AnioEntity AnioEntity
        {
            get { return _AnioEntity; }
            set { _AnioEntity = value; }
        }

        private AutorEntity _AutorEntity;

        public AutorEntity AutorEntity
        {
            get { return _AutorEntity; }
            set { _AutorEntity = value; }
        }
        

    }
}
