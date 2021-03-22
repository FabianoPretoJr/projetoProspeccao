namespace BLL.Models
{
    public class PerfilModel : BaseModel
    {
        public PerfilModel(string nomePerfil)
        {
            this.NomePerfil = nomePerfil;
        }

        public PerfilModel(int id, string nomePerfil) : base(id)
        {
            this.NomePerfil = nomePerfil;
        }

        private string _nomePerfil;
        public string NomePerfil
        {
            get { return _nomePerfil; }
            private set { _nomePerfil = value; }
        }
    }
}
