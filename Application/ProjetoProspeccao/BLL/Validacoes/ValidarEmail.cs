using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validacoes
{
    public class ValidarEmail
    {
        public void validar(string email)
        {
            if (email.Contains("@"))
                throw new Exception("Formato inválido de email");
            if(email.Contains(".com"))
                throw new Exception("Formato inválido de email");
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Formato inválido de email");
        }
    }
}
