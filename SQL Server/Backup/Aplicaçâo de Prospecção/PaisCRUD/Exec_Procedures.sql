EXEC InserirNovoPais 'Austrália';

EXEC AtualizarPais 5, 'Austrália II';

EXEC DeletarPais 5;

SELECT * FROM Pais;

/*
INSERT INTO Pais (nome_pais, ativo) 
	VALUES ('Brasil', 0),
		   ('Argentina', 0),
		   ('Alemanha', 0),
		   ('Estados Unidos', 0);
*/