CREATE PROCEDURE ClienteValido
	@IdCliente	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Cliente WHERE id_cliente = @IdCliente))
				THROW 50000, 'Cliente não encontrado na base de dados', 1;

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;