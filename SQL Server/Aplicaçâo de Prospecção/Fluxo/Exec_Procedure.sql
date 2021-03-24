SELECT * FROM Cliente;
SELECT * FROM Analise;
SELECT * FROM Usuario;
SELECT * FROM Acesso;
SELECT * FROM Perfil;
SELECT * FROM StatusAnalise;
SELECT * FROM Endereco;
select * from Analise;

EXEC EnviarAnaliseGerencia @IdCliente = 22, @IdUsuario = 2;

EXEC EnviarAnaliseControleDeRisco @IdCliente = 22, @IdUsuario = 1;

EXEC AprovarFluxo @IdCliente = 22, @IdUsuario = 3;

EXEC ReprovarFluxo @IdCliente = 15, @IdUsuario = 4;

EXEC CorrecaoDeCadastro @IdCliente = 16, @IdUsuario = 1;

EXEC DevolverCadastro @IdCliente = 12, @IdUsuario = 2;

/*
1 - gerência
2 - operação
3 - controle de risco

N = 15
I = 16

1 - Cadastrato
2 - Aguradando análise da gerência
3 - Aprovado pela gerência
4 - Aguardando análise do controle de risco
5 - Aprovado pelo controle de risco
6 - Reprovado
7 - Correção de cadastro
*/