namespace BLL.Models
{
    public class UsuarioModel : BaseModel
    {
        public UsuarioModel(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public UsuarioModel(int id, string login, string senha) : base(id)
        {
            this.Login = login;
            this.Senha = senha;
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            private set { _login = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            private set { _senha = value; }
        }
    }
}
