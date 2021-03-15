namespace BLL
{
    public class Pais : BaseClass
    {
        public Pais(string nomePais)
        {
            this.NomePais = nomePais;
        }

        public Pais(int id, string nomePais) : base(id)
        {
            this.NomePais = nomePais;
        }

        private string _nomePais;
        public string NomePais
        {
            get { return _nomePais; }
            private set { _nomePais = value; }
        }
    }
}
