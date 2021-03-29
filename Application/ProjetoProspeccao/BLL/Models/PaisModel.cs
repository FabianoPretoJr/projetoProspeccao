using System.Collections.Generic;

namespace BLL.Models
{
    public class PaisModel
    {
        public PaisModel(string nome_Pais)
        {
            this.Nome_Pais = nome_Pais;
        }

        public PaisModel(int id_Pais, string nome_Pais)
        {
            this.Id_Pais = id_Pais;
            this.Nome_Pais = nome_Pais;
        }

        private int _id_Pais;
        public int Id_Pais
        {
            get { return _id_Pais; }
            private set { _id_Pais = value; }
        }

        private string _nome_Pais;
        public string Nome_Pais
        {
            get { return _nome_Pais; }
            private set { _nome_Pais = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }

        private IEnumerable<EstadoModel> _estados;
        public IEnumerable<EstadoModel> Estados
        {
            get { return _estados; }
            private set { _estados = value; }
        }
    }
}
