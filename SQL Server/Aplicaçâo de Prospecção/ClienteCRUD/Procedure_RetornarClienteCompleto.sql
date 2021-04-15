CREATE PROCEDURE RetornarClienteCompleto
	@IdCliente INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;

			SELECT * FROM Cliente cli
				INNER JOIN Endereco e ON (e.id_cliente = cli.id_cliente)
				INNER JOIN Cidade	c ON (c.id_cidade = e.id_cidade)
				INNER JOIN Estado   es ON (es.id_estado = c.id_estado)
				INNER JOIN Pais		p ON (p.id_pais = es.id_pais)
			WHERE cli.id_cliente = @IdCliente;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END