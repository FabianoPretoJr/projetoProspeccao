namespace BLL.Models
{
    public class CidadeModel : BaseModel
    {
        public CidadeModel(string nomeCidade, int idEstado)
        {
            this.NomeCidade = nomeCidade;
            this.IdEstado = idEstado;
        }

        public CidadeModel(int id, string nomeCidade, int idEstado) : base(id)
        {
            this.NomeCidade = nomeCidade;
            this.IdEstado = idEstado;
        }

        private string _nomeCidade;
        public string NomeCidade
        {
            get { return _nomeCidade; }
            private set { _nomeCidade = value; }
        }

        private int _idEstado;
        public int IdEstado
        {
            get { return _idEstado; }
            private set { _idEstado = value; }
        }

        private EstadoModel _estado;
        public EstadoModel Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
