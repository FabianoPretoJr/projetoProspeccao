using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Utils
{
    public static class Erros
    {
        public static List<string> ListarErros(List<ValidationResult> erros)
        {
            List<string> listaErros = new List<string>();
            foreach (var erro in erros)
            {
                listaErros.Add(erro.ErrorMessage);
            }

            return listaErros;
        }
    }
}
