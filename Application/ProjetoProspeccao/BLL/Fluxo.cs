namespace BLL
{
    public class Fluxo
    {
        public Fluxo(int idCliente, int idUsuario)
        {
            this.IdCliente = idCliente;
            this.IdUsuario = idUsuario;
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            private set { _idCliente = value; }
        }

        private int _idUsuario;
        public int IdUsuario
        {
            get { return _idUsuario; }
            private set { _idUsuario = value; }
        }
    }
}
