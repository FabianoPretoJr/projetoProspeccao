using System;

namespace BLL.Models
{
    public class AnaliseModel
    {
        public AnaliseModel(int id_Status, int id_Cliente, int id_Usuario)
        {
            this.Id_Status = id_Status;
            this.Id_Cliente = id_Cliente;
            this.Id_Usuario = id_Usuario;
            this.Data_Hora = DateTime.UtcNow;
        }

        public AnaliseModel(int id_Status, int id_Usuario)
        {
            this.Id_Status = id_Status;
            this.Id_Usuario = id_Usuario;
            this.Data_Hora = DateTime.UtcNow;
        }

        public AnaliseModel(int id_Analise, ClienteModel cliente, UsuarioModel usuario, StatusAnaliseModel statusAnalise, DateTime data_Hora)
        {
            this.Id_Analise = id_Analise;
            this.Cliente = cliente;
            this.Usuario = usuario;
            this.StatusAnalise = statusAnalise;
            this.Data_Hora = data_Hora;
        }

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
        public virtual StatusAnaliseModel StatusAnalise
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
        public virtual ClienteModel Cliente
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
        public virtual UsuarioModel Usuario
        {
            get { return _usuario; }
            private set { _usuario = value; }
        }

        private DateTime _data_Hora;
        public DateTime Data_Hora
        {
            get { return _data_Hora; }
            private set { _data_Hora = value; }
        }
    }
}
