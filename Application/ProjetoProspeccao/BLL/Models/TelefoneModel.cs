using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TelefoneModel : BaseModel
    {
        public TelefoneModel(string numeroTelefone)
        {
            this.NumeroTelefone = numeroTelefone;
        }

        public TelefoneModel(string numeroTelefone, int idCliente)
        {
            this.NumeroTelefone = numeroTelefone;
            this.IdCliente = idCliente;
        }

        public TelefoneModel(int id, string numeroTelefone, int idCliente) : base(id)
        {
            this.NumeroTelefone = numeroTelefone;
            this.IdCliente = idCliente;
        }

        private string _numeroTelefone;
        public string NumeroTelefone
        {
            get { return _numeroTelefone; }
            set { _numeroTelefone = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
    }
}
