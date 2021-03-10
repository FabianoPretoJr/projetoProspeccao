EXEC InserirNovaCidade 'Nambour', 15;

EXEC AtualizarCidade 21, 'Nambour II', 15;

EXEC DeletarCidade 21;

SELECT * FROM Cidade;

/*
INSERT INTO Cidade (nome_cidade, id_estado, ativo)
	VALUES ('Franco da Rocha', 1, 0),
		   ('Jundiaí', 1, 0),
		   ('Barueri', 1, 0),
		   ('São Gonçalo', 2, 0),
		   ('Petrópolis', 2, 0),
		   ('Belo Horizonte', 3, 0),
		   ('Juiz de Fora', 3, 0),
		   ('Salvador', 4, 0),
		   ('Juazeiro', 4, 0),
		   ('Rio Branco', 5, 0),
		   ('Jordão', 5, 0),
		   ('Gaiman', 6, 0),
		   ('Viedma', 7, 0),
		   ('Arias', 8, 0),
		   ('Borna', 9, 0),
		   ('Lebach', 10, 0),
		   ('Munique', 11, 0),
		   ('Dallas', 12, 0),
		   ('Los Angeles', 13, 0),
		   ('Topeka', 14, 0);
*/