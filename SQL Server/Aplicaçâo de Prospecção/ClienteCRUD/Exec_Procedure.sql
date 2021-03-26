EXEC CadastroCliente 
	'Anerinda', 
	'41635141543', --cpf
	'633299126', 
	'12/09/2001', 
	'anerinda@email.com', 
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
	'Claudio', 
	'165414761734', --cpf
	'633154126', 
	'01/11/1999', 
	'claudio@email.com', 
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

EXEC ExcluirCliente 33, 2;

SELECT * FROM Cliente;
SELECT * FROM Telefone;
SELECT * FROM Endereco;
SELECT * FROM Analise;
SELECT * FROM PaisEstadoCidade;