CREATE PROCEDURE InserirTelefone
	@NumeroTelefone	VARCHAR(9),
	@IdCliente		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;

			IF(dbo.ISEMPTY(@NumeroTelefone) = 0)
				THROW 50000, 'Campo número telefone está vazio', 1;

			INSERT INTO Telefone (numero_telefone, id_cliente)
				VALUES (@NumeroTelefone, @IdCliente);
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;