namespace BLL.Models
{
    public class TelefoneModel
    {
        public TelefoneModel(string numero_Telefone, int id_Cliente)
        {
            this.Numero_Telefone = numero_Telefone;
            this.Id_Cliente = id_Cliente;
        }

        public TelefoneModel(int id_Telefone, string numero_Telefone, int id_Cliente)
        {
            this.Id_Telefone = id_Cliente;
            this.Numero_Telefone = numero_Telefone;
            this.Id_Cliente = id_Cliente;
        }

        private int _id_Telefone;
        public int Id_Telefone
        {
            get { return _id_Telefone; }
            private set { _id_Telefone = value; }
        }

        private string _numero_Telefone;
        public string Numero_Telefone
        {
            get { return _numero_Telefone; }
            private set { _numero_Telefone = value; }
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
