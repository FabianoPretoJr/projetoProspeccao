using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class ClienteModel
    {
        public ClienteModel(string nome, string cpf, string rg, DateTime data_Nascimento, string email)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Data_Nascimento = data_Nascimento;
            this.Email = email;
        }

        public ClienteModel(
            int id_Cliente, 
            string nome, 
            string cpf, 
            string rg, 
            DateTime data_Nascimento, 
            string email, 
            int id_Status,
            TelefoneModel telefone,
            EnderecoModel endereco)
        {
            this.Id_Cliente = id_Cliente;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Data_Nascimento = data_Nascimento;
            this.Email = email;
            this.Id_Status = id_Status;
            this.Telefones = new List<TelefoneModel>();
            this.Telefones.Add(telefone);
            this.Enderecos = new List<EnderecoModel>();
            this.Enderecos.Add(endereco);
        }

        public ClienteModel(
            string nome, 
            string cpf, 
            string rg, 
            DateTime data_Nascimento, 
            string email,
            int id_Status,
            TelefoneModel telefone,
            EnderecoModel endereco,
            AnaliseModel analise)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Data_Nascimento = data_Nascimento;
            this.Email = email;
            this.Id_Status = id_Status;
            this.Telefones = new List<TelefoneModel>();
            this.Telefones.Add(telefone);
            this.Enderecos = new List<EnderecoModel>();
            this.Enderecos.Add(endereco);
            this.Analises = new List<AnaliseModel>();
            this.Analises.Add(analise);
        }

        private int _id_Cliente;
        public int Id_Cliente
        {
            get { return _id_Cliente; }
            private set { _id_Cliente = value; }
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

        private DateTime _data_Nascimento;
        public DateTime Data_Nascimento
        {
            get { return _data_Nascimento; }
            private set { _data_Nascimento = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        private int _id_Status;
        public int Id_Status
        {
            get { return _id_Status; }
            set { _id_Status = value; }
        }

        private StatusAnaliseModel _statusAnalise;
        public virtual StatusAnaliseModel StatusAnalise
        {
            get { return _statusAnalise; }
            private set { _statusAnalise = value; }
        }

        private ICollection<EnderecoModel> _enderecos;
        public virtual ICollection<EnderecoModel> Enderecos
        {
            get { return _enderecos; }
            private set { _enderecos = value; }
        }

        private ICollection<TelefoneModel> _telefones;
        public virtual ICollection<TelefoneModel> Telefones
        {
            get { return _telefones; }
            private set { _telefones = value; }
        }

        private ICollection<AnaliseModel> _analises;
        public virtual ICollection<AnaliseModel> Analises
        {
            get { return _analises; }
            private set { _analises = value; }
        }
    }
}
