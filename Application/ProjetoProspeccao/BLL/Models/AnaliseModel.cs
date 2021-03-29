using System;

namespace BLL.Models
{
    public class AnaliseModel
    {
        private int _id_Analise;
        public int Id_Analise
        {
            get { return _id_Analise; }
            private set { _id_Analise = value; }
        }

        private int _id_Status;
        public int Id_Status
        {
            get { return _id_Status; }
            private set { _id_Status = value; }
        }

        private StatusAnaliseModel _statusAnalise;
        public StatusAnaliseModel StatusAnalise
        {
            get { return _statusAnalise; }
            private set { _statusAnalise = value; }
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

        private int _id_Usuario;
        public int Id_Usuario
        {
            get { return _id_Usuario; }
            private set { _id_Usuario = value; }
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
