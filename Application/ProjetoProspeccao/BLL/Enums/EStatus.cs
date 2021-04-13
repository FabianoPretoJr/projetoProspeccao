using System.ComponentModel.DataAnnotations;

namespace BLL.Enums
{
    public enum EStatus
    {
        [Display(Name = "Cadastrado")]
        Cadastrado = 1,
        [Display(Name = "Aguardando análise da gerência")]
        analise_gerencia = 2,
        [Display(Name = "Aprovado pela gerência")]
        aprovado_gerencia = 3,
        [Display(Name = "Aguardando análise do controle de risco")]
        analise_controle_risco = 4,
        [Display(Name = "Aprovado pelo controle de risco")]
        aprovado_controle_risco = 5,
        [Display(Name = "Reprovado")]
        reprovado = 6,
        [Display(Name = "Correção de cadastro")]
        correcao_cadastro = 7
    }
}
