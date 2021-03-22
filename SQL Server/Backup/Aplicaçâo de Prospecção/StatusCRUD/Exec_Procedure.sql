EXEC InserirStatusAnalise 'Cadastrato';
EXEC InserirStatusAnalise 'Aguardando análise da gerência';
EXEC InserirStatusAnalise 'Aprovado pela gerência';
EXEC InserirStatusAnalise 'Aguardando análise do controle de risco';
EXEC InserirStatusAnalise 'Aprovado pelo controle de risco';
EXEC InserirStatusAnalise 'Reprovado';
EXEC InserirStatusAnalise 'Correção de cadastro';

EXEC AtualizarStatusAnalise 1, 'Teste';

EXEC DeletarStatusAnalise 1;

SELECT * FROM StatusAnalise;