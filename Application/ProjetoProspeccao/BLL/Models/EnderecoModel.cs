namespace BLL.Models
{
    public class EnderecoModel
    {
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

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            private set { _cep = value; }
        }

        private string _rua;
        public string Rua
        {
            get { return _rua; }
            private set { _rua = value; }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            private set { _numero = value; }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            private set { _complemento = value; }
        }

        private string _bairro;
        public string Bairro
        {
            get { return _bairro; }
            private set { _bairro = value; }
        }

        private int _idCidade;
        public int IdCidade
        {
            get { return _idCidade; }
            private set { _idCidade = value; }
        }

        private CidadeModel _cidade;
        public CidadeModel Cidade
        {
            get { return _cidade; }
            private set { _cidade = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            private set { _idCliente = value; }
        }

        private ClienteModel _cliente;
        public ClienteModel Cliente
        {
            get { return _cliente; }
            private set { _cliente = value; }
        }
    }
}
