namespace BLL.Models
{
    public class TelefoneModel
    {
        public TelefoneModel(string numeroTelefone, int idCliente)
        {
            this.NumeroTelefone = numeroTelefone;
            this.IdCliente = idCliente;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private string _numeroTelefone;
        public string NumeroTelefone
        {
            get { return _numeroTelefone; }
            private set { _numeroTelefone = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            private set { _idCliente = value; }
        }

        private ClienteModel _clienteModel;
        public ClienteModel ClienteModel
        {
            get { return _clienteModel; }
            set { _clienteModel = value; }
        }
    }
}
