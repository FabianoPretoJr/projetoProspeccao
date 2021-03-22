SELECT * FROM Cliente;
SELECT * FROM Analise;
SELECT * FROM Usuario;
SELECT * FROM Acesso;
SELECT * FROM Perfil;
SELECT * FROM StatusAnalise;
SELECT * FROM Endereco;
select * from Analise;

EXEC EnviarAnaliseGerencia @IdCliente = 8, @IdUsuario = 4;

EXEC EnviarAnaliseControleDeRisco @IdCliente = 8, @IdUsuario = 2;

EXEC AprovarFluxo @IdCliente = 8, @IdUsuario = 4;

EXEC ReprovarFluxo @IdCliente = 17, @IdUsuario = 3;

EXEC CorrecaoDeCadastro @IdCliente = 17, @IdUsuario = 1;

EXEC DevolverCadastro @IdCliente = 17, @IdUsuario = 2;

/*
1 - ger�ncia
2 - opera��o
3 - controle de risco

I = 16
N = 17

1 - Cadastrato
2 - Aguradando an�lise da ger�ncia
3 - Aprovado pela ger�ncia
4 - Aguardando an�lise do controle de risco
5 - Aprovado pelo controle de risco
6 - Reprovado
7 - Corre��o de cadastro
*/