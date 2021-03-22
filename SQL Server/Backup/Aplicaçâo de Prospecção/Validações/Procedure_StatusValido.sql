CREATE PROCEDURE StatusValido
	@IdStatus	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM StatusAnalise WHERE id_status = @IdStatus))
				THROW 50000, 'Status não encontrado na base de dados', 1;

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;