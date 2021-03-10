namespace BLL
{
    public class Pais
    {
        private int _idPais;
        public int IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }

        private string _nomePais;
        public string NomePais
        {
            get { return _nomePais; }
            set { _nomePais = value; }
        }

        private bool _ativo;
        public bool  Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

    }
}
