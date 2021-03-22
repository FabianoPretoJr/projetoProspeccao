namespace BLL.Models
{
    public class PaisModel : BaseModel
    {
        public PaisModel(string nomePais)
        {
            this.NomePais = nomePais;
        }

        public PaisModel(int id, string nomePais) : base(id)
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
