CREATE VIEW PaisEstadoCidade
AS
SELECT p.nome_pais AS Pais, e.nome_estado AS Estado, c.nome_cidade AS Cidade, c.id_cidade AS IdCidade
	FROM Estado e
		INNER JOIN Pais p ON (p.id_pais = e.id_pais)
		INNER JOIN Cidade c ON (c.id_estado = e.id_estado);