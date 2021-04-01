namespace BLL.Models
{
    public class AcessoModel
    {
        private int _id_Perfil;
        public int Id_Perfil
        {
            get { return _id_Perfil; }
            private set { _id_Perfil = value; }
        }

        private PerfilModel _perfil;
        public virtual PerfilModel Perfil
        {
            get { return _perfil; }
            private set { _perfil = value; }
        }

        private int _id_Usuario;
        public int Id_Usuario
        {
            get { return _id_Usuario; }
            private set { _id_Usuario = value; }
        }

        private UsuarioModel _usuario;
        public virtual UsuarioModel Usuario
        {
            get { return _usuario; }
            private set { _usuario = value; }
        }
    }
}
