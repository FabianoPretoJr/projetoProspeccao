using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(string login_Usuario, string senha)
        {
            this.Login_Usuario = login_Usuario;
            this.Senha = senha;
        }

        public UsuarioModel(int id_Usuario, string login_Usuario, string senha)
        {
            this.Id_Usuario = id_Usuario;
            this.Login_Usuario = login_Usuario;
            this.Senha = senha;
            this.Ativo = true;
        }

        private int _id_Usuario;
        public int Id_Usuario
        {
            get { return _id_Usuario; }
            private set { _id_Usuario = value; }
        }

        private string _login_Usuario;
        public string Login_Usuario
        {
            get { return _login_Usuario; }
            private set { _login_Usuario = value; }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            private set { _senha = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }

        private ICollection<AcessoModel> _acesso;
        public virtual ICollection<AcessoModel> Acesso
        {
            get { return _acesso; }
            private set { _acesso = value; }
        }

        private ICollection<AnaliseModel> _analises;
        public virtual ICollection<AnaliseModel> Analises
        {
            get { return _analises; }
            private set { _analises = value; }
        }

        public void Desativar(UsuarioModel usuario)
        {
            usuario.Ativo = false;
        }
    }
}
