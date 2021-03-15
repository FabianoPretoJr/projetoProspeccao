EXEC CadastroCliente 
	'Fabiano Preto', 
	'44315144673', --cpf
	'633299126', 
	'12/09/2001', 
	'fabiano@email.com', 
	'985592015', 
	'25946135', 
	'Rua Jácare', 
	'2351', 
	NULL, 
	'Flórida', 
	1,
	2;

EXEC AtualizarCliente
	1,
	'Paulo II',
	'12345678912', --cpf
	'12345678',
	'01/03/2011',
	'paulo2@email.com';

EXEC CadastroCliente --INTERNACIONAL
	'Matheus', 
	'415434768134', --cpf
	'633154126', 
	'01/11/1999', 
	'matheus@email.com', 
	'985596548', 
	NULL, 
	'Street Green', 
	'15', 
	NULL, 
	'Carolina', 
	20,
	2;

EXEC AtualizarTelefone 1, '996685684', 1;

EXEC AtualizarEndereco 1, '12345678', 'Rua Vinte', '254', NULL, 'Paraiso', 1, 1;

SELECT * FROM Cliente;
SELECT * FROM Telefone;
SELECT * FROM Endereco;
SELECT * FROM PaisEstadoCidade;