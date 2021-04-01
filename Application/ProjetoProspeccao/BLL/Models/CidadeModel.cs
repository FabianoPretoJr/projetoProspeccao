using System.Collections.Generic;

namespace BLL.Models
{
    public class CidadeModel
    {
        public CidadeModel(string nome_Cidade, int id_Estado)
        {
            this.Nome_Cidade = nome_Cidade;
            this.Id_Estado = id_Estado;
        }

        public CidadeModel(int id_Cidade, string nome_Cidade, int id_Estado)
        {
            this.Id_Cidade = id_Cidade;
            this.Nome_Cidade = nome_Cidade;
            this.Id_Estado = id_Estado;
        }

        private int _id_Cidade;
        public int Id_Cidade
        {
            get { return _id_Cidade; }
            private set { _id_Cidade = value; }
        }


        private string _nome_Cidade;
        public string Nome_Cidade
        {
            get { return _nome_Cidade; }
            private set { _nome_Cidade = value; }
        }

        private int _id_Estado;
        public int Id_Estado
        {
            get { return _id_Estado; }
            private set { _id_Estado = value; }
        }

        private EstadoModel _estado;
        public virtual EstadoModel Estado
        {
            get { return _estado; }
            private set { _estado = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }

        private ICollection<EnderecoModel> _enderecos;
        public virtual ICollection<EnderecoModel> Enderecos
        {
            get { return _enderecos; }
            private set { _enderecos = value; }
        }
    }
}
