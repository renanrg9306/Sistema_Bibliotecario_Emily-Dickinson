using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PeliculaEntity:MaterialEntity
    {
        public PeliculaEntity()
        {
            GeneroEntity = new GeneroEntity();
            Protagonista = new ProtagonistaEntity();
            DirectorEntity = new DirectorEntity();
        }

        private GeneroEntity _GeneroEntity;

        public GeneroEntity GeneroEntity
        {
            get { return _GeneroEntity; }
            set { _GeneroEntity = value; }
        }
        private DirectorEntity _DirectorEntity;

        public DirectorEntity DirectorEntity
        {
            get { return _DirectorEntity; }
            set { _DirectorEntity = value; }
        }
        private ProtagonistaEntity _Protagonista;

        public ProtagonistaEntity Protagonista
        {
            get { return _Protagonista; }
            set { _Protagonista = value; }
        }
        private int _idPelicula;

        public int IdPelicula
        {
            get { return _idPelicula; }
            set { _idPelicula = value; }
        }
        private string Duracion;

        public string Duracion1
        {
            get { return Duracion; }
            set { Duracion = value; }
        }
        private string _Sinopsis;

        public string Sinopsis
        {
            get { return _Sinopsis; }
            set { _Sinopsis = value; }
        }
        private bool _Subtitulo;

        public bool Subtitulo
        {
            get { return _Subtitulo; }
            set { _Subtitulo = value; }
        }
        private int _Anio;

        public int Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }


    }
}
