using System.Collections.Generic;

namespace BLL.Models
{
    public class PerfilModel
    {
        public PerfilModel(string nome_Perfil)
        {
            this.Nome_Perfil = nome_Perfil;
        }

        public PerfilModel(int id_Perfil, string nome_Perfil)
        {
            this.Id_Perfil = id_Perfil;
            this.Nome_Perfil = nome_Perfil;
        }

        private int _id_Perfil;
        public int Id_Perfil
        {
            get { return _id_Perfil; }
            private set { _id_Perfil = value; }
        }

        private string _nome_Perfil;
        public string Nome_Perfil
        {
            get { return _nome_Perfil; }
            private set { _nome_Perfil = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }

        private IEnumerable<AcessoModel> _acesso;
        public IEnumerable<AcessoModel> Acesso
        {
            get { return _acesso; }
            private set { _acesso = value; }
        }
    }
}
