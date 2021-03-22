using System;

namespace BLL.Models
{
    public class ClienteModel
    {
        public ClienteModel(string nome, string cpf, string rg, DateTime dataNascimento, string email)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }

        public ClienteModel(int id, string nome, string cpf, string rg, DateTime dataNascimento, string email)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            private set { _nome = value; }
        }

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            private set { _cpf = value; }
        }

        private string _rg;
        public string Rg
        {
            get { return _rg; }
            private set { _rg = value; }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            private set { _dataNascimento = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        private int _idStatus;
        public int IdStatus
        {
            get { return _idStatus; }
            private set { _idStatus = value; }
        }

        private StatusAnaliseModel _statusAnalise;
        public StatusAnaliseModel StatusAnalise
        {
            get { return _statusAnalise; }
            private set { _statusAnalise = value; }
        }
    }
}
