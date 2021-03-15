using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Perfil : BaseClass
    {
        public Perfil(string nomePerfil)
        {
            this.NomePerfil = nomePerfil;
        }

        public Perfil(int id, string nomePerfil) : base(id)
        {
            this.NomePerfil = nomePerfil;
        }

        private string _nomePerfil;
        public string NomePerfil
        {
            get { return _nomePerfil; }
            set { _nomePerfil = value; }
        }
    }
}
