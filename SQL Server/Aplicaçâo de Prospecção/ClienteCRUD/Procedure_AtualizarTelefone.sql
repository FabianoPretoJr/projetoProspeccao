CREATE PROCEDURE AtualizarTelefone
	@IdTelefone		INT,
	@NumeroTelefone	VARCHAR(9),
	@IdCliente		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;

			IF(dbo.ISEMPTY(@NumeroTelefone) = 0)
				THROW 50000, 'Campo número telefone está vazio', 1;

			IF(NOT EXISTS(SELECT * FROM Telefone WHERE id_telefone = @IdTelefone AND id_cliente = @IdCliente))
				BEGIN
					EXEC InserirTelefone @NumeroTelefone, @IdCliente;
				END

			UPDATE Telefone
				SET numero_telefone = @NumeroTelefone
				WHERE id_telefone = @IdTelefone;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;