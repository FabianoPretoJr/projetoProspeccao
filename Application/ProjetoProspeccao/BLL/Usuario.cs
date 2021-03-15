namespace BLL
{
    public class Usuario : BaseClass
    {
        public Usuario(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public Usuario(int id, string login, string senha) : base(id)
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
