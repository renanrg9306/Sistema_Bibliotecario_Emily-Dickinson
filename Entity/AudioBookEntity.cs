using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class AudioBookEntity:MaterialEntity
    {
       public AudioBookEntity()
       {
           AutorEntity = new AutorEntity();
       }

        private int _idAudiobook;

        public int IdAudiobook
        {
            get { return _idAudiobook; }
            set { _idAudiobook = value; }
        }
        private string _Componentes;

        public string Componentes
        {
            get { return _Componentes; }
            set { _Componentes = value; }
        }

        private AutorEntity _AutorEntity;

        public AutorEntity AutorEntity
        {
            get { return _AutorEntity; }
            set { _AutorEntity = value; }
        }
       
    }
}
