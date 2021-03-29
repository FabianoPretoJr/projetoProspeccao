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
            int id_Cidade, 
            int id_Cliente)
        {
            this.Cep = cep;
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Id_Cidade = id_Cidade;
            this.Id_Cliente = id_Cliente;
        }

        public EnderecoModel(
            int id_Endereco,
            string cep,
            string rua,
            string numero,
            string complemento,
            string bairro,
            int id_Cidade,
            int id_Cliente)
        {
            this.Id_Endereco = id_Endereco;
            this.Cep = cep;
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Id_Cidade = id_Cidade;
            this.Id_Cliente = id_Cliente;
        }

        private int _id_Endereco;
        public int Id_Endereco
        {
            get { return _id_Endereco; }
            private set { _id_Endereco = value; }
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

        private int _id_Cidade;
        public int Id_Cidade
        {
            get { return _id_Cidade; }
            private set { _id_Cidade = value; }
        }

        private CidadeModel _cidade;
        public CidadeModel Cidade
        {
            get { return _cidade; }
            private set { _cidade = value; }
        }

        private int _id_Cliente;
        public int Id_Cliente
        {
            get { return _id_Cliente; }
            private set { _id_Cliente = value; }
        }

        private ClienteModel _cliente;
        public ClienteModel Cliente
        {
            get { return _cliente; }
            private set { _cliente = value; }
        }
    }
}
