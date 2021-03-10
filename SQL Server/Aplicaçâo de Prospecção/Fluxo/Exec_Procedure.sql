SELECT * FROM Cliente;
SELECT * FROM Analise;
SELECT * FROM Usuario;
SELECT * FROM Acesso;
SELECT * FROM Perfil;
SELECT * FROM StatusAnalise;
SELECT * FROM Endereco;

EXEC EnviarAnaliseGerencia @IdCliente = 16, @IdUsuario = 2;

EXEC EnviarAnaliseControleDeRisco @IdCliente = 16, @IdUsuario = 2;

EXEC AprovarFluxo @IdCliente = 16, @IdUsuario = 1;

EXEC ReprovarFluxo @IdCliente = 17, @IdUsuario = 3;

EXEC CorrecaoDeCadastro @IdCliente = 17, @IdUsuario = 1;

EXEC DevolverCadastro @IdCliente = 17, @IdUsuario = 2;

/*
1 - gerência
2 - operação
3 - controle de risco

I = 16
N = 17

1 - Cadastrato
2 - Aguradando análise da gerência
3 - Aprovado pela gerência
4 - Aguardando análise do controle de risco
5 - Aprovado pelo controle de risco
6 - Reprovado
7 - Correção de cadastro
*/