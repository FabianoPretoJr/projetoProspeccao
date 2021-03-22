namespace BLL.Models
{
    public class EstadoModel : BaseModel
    {
        public EstadoModel(string nomeEstado, int idPais)
        {
            this.NomeEstado = nomeEstado;
            this.IdPais = idPais;
        }

        public EstadoModel(int id, string nomeEstado, int idPais) : base(id)
        {
            this.NomeEstado = nomeEstado;
            this.IdPais = idPais;
        }

        private string _nomeEstado;
        public string NomeEstado
        {
            get { return _nomeEstado; }
            private set { _nomeEstado = value; }
        }

        private int _idPais;
        public int IdPais
        {
            get { return _idPais; }
            private set { _idPais = value; }
        }

        private PaisModel _pais;
        public PaisModel Pais
        {
            get { return _pais; }
            private set { _pais = value; }
        }

    }
}
