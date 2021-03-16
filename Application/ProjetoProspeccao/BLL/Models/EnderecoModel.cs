using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EnderecoModel : BaseModel
    {
        public EnderecoModel(
        string cep,
        string rua,
        string numero,
        string complemento,
        string bairro,
        int idCidade)
        {
            this.Cep = cep;
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.IdCidade = idCidade;
        }

        public EnderecoModel(
            string cep, 
            string rua, 
            string numero, 
            string complemento, 
            string bairro, 
            int idCidade, 
            int idCliente)
        {
            this.Cep = cep;
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.IdCidade = idCidade;
            this.IdCliente = idCliente;
        }

        public EnderecoModel(
            int id, 
            string cep, 
            string rua, 
            string numero, 
            string complemento, 
            string bairro, 
            int idCidade, 
            int idCliente) : base(id)
        {
            this.Cep = cep;
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.IdCidade = idCidade;
            this.IdCliente = idCliente;
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _rua;
        public string Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private string _bairro;
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        private int _idCidade;
        public int IdCidade
        {
            get { return _idCidade; }
            set { _idCidade = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
    }
}
