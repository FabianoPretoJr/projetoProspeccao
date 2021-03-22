namespace BLL.Models
{
    public class AcessoModel
    {
        private int _idPerfil;
        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }

        private PerfilModel _perfil;
        public PerfilModel Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

        private int _idUsuario;
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}
