using System;

namespace BLL.Models
{
    class AnaliseModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
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

        private int _idUsuario;
        public int IdUsuario
        {
            get { return _idUsuario; }
            private set { _idUsuario = value; }
        }

        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            private set { _usuario = value; }
        }

        private DateTime _dataHora;
        public DateTime DataHora
        {
            get { return _dataHora; }
            private set { _dataHora = value; }
        }
    }
}
