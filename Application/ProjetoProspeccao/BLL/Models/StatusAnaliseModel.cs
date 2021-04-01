using System.Collections.Generic;

namespace BLL.Models
{
    public class StatusAnaliseModel
    {
        public StatusAnaliseModel(string nome_Status)
        {
            this.Nome_Status = nome_Status;
        }

        public StatusAnaliseModel(int id_Status, string nome_Status)
        {
            this.Id_Status = id_Status;
            this.Nome_Status = nome_Status;
        }

        private int _id_Status;
        public int Id_Status
        {
            get { return _id_Status; }
            private set { _id_Status = value; }
        }

        private string _nome_Status;
        public string Nome_Status
        {
            get { return _nome_Status; }
            private set { _nome_Status = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }

        private ICollection<ClienteModel> _clientes;
        public virtual ICollection<ClienteModel> Clientes
        {
            get { return _clientes; }
            private set { _clientes = value; }
        }

        private ICollection<AnaliseModel> _analises;
        public virtual ICollection<AnaliseModel> Analises
        {
            get { return _analises; }
            private set { _analises = value; }
        }
    }
}
