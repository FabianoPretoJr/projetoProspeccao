EXEC InserirStatusAnalise 'Cadastrato';
EXEC InserirStatusAnalise 'Aguardando an�lise da ger�ncia';
EXEC InserirStatusAnalise 'Aprovado pela ger�ncia';
EXEC InserirStatusAnalise 'Aguardando an�lise do controle de risco';
EXEC InserirStatusAnalise 'Aprovado pelo controle de risco';
EXEC InserirStatusAnalise 'Reprovado';
EXEC InserirStatusAnalise 'Corre��o de cadastro';

EXEC AtualizarStatusAnalise 1, 'Teste';

EXEC DeletarStatusAnalise 1;

SELECT * FROM StatusAnalise;