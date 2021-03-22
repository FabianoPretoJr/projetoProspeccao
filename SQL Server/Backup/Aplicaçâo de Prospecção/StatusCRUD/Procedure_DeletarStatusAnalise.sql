CREATE PROCEDURE DeletarStatusAnalise
	@IdStatus		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM StatusAnalise WHERE id_status = @IdStatus))
				THROW 50000, 'Status não encontrado na base de dados', 1;

			UPDATE StatusAnalise
				SET ativo = 1
				WHERE id_status = @IdStatus;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END