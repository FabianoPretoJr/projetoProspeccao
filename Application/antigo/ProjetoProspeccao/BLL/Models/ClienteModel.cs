using System;

namespace BLL.Models
{
    public class ClienteModel : BaseModel
    {
        public ClienteModel(string nome, string cpf, string rg, DateTime dataNascimento, string email)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }

        public ClienteModel(int id, string nome, string cpf, string rg, DateTime dataNascimento, string email) : base(id)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        private string _rg;
        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _idStatus;
        private int IdStatus
        {
            get { return _idStatus; }
            set { _idStatus = value; }
        }
    }
}
