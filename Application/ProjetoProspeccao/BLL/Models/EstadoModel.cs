using System.Collections.Generic;

namespace BLL.Models
{
    public class EstadoModel
    {
        public EstadoModel(string nome_Estado, int id_Pais)
        {
            this.Nome_Estado = nome_Estado;
            this.Id_Pais = id_Pais;
        }

        public EstadoModel(int id_Estado, string nome_Estado, int id_Pais)
        {
            this.Id_Estado = id_Estado;
            this.Nome_Estado = nome_Estado;
            this.Id_Pais = id_Pais;
        }

        private int _id_Estado;
        public int Id_Estado
        {
            get { return _id_Estado; }
            private set { _id_Estado = value; }
        }


        private string _nome_Estado;
        public string Nome_Estado
        {
            get { return _nome_Estado; }
            private set { _nome_Estado = value; }
        }

        private int _id_Pais;
        public int Id_Pais
        {
            get { return _id_Pais; }
            private set { _id_Pais = value; }
        }

        private PaisModel _pais;
        public PaisModel Pais
        {
            get { return _pais; }
            private set { _pais = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }

        private IEnumerable<CidadeModel> _cidades;
        public IEnumerable<CidadeModel> Cidades
        {
            get { return _cidades; }
            private set { _cidades = value; }
        }

    }
}
