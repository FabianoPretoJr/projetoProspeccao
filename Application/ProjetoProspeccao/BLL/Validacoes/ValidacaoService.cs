using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Validacoes
{
    public static class ValidacaoService
    {
        public static IEnumerable<ValidationResult> ValidarErros(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }
    }
}
