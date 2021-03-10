EXEC InserirNovoEstado 'Queensland', 6;

EXEC AtualizarEstado 15, 'Queensland II', 6;

EXEC DeletarEstado 15;

SELECT * FROM Estado;

/*
INSERT INTO Estado (nome_estado, id_pais, ativo)
	VALUES ('São Paulo', 1, 0),
		   ('Rio de Janeiro', 1, 0),
		   ('Minas Gerais', 1, 0),
		   ('Bahia', 1, 0),
		   ('Acre', 1, 0),
		   ('Chubut', 2, 0),
		   ('Rio Negro', 2, 0),
		   ('Córdoba', 2, 0),
		   ('Saxônia', 3, 0),
		   ('Sarre', 3, 0),
		   ('Baviera', 3, 0),
		   ('Texas', 4, 0),
		   ('Califórnia', 4, 0),
		   ('Kansas', 4, 0);
*/