CREATE PROCEDURE AtualizarStatusAnalise
	@IdStatus		INT,
	@NomeStatus		VARCHAR(40)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(dbo.ISEMPTY(@NomeStatus) = 0)
					THROW 50000, 'Campo nome status está vazio', 1;

			IF(NOT EXISTS(SELECT * FROM StatusAnalise WHERE id_status = @IdStatus))
				THROW 50000, 'Status não encontrado na base de dados', 1;

			UPDATE StatusAnalise
				SET nome_status = @NomeStatus
				WHERE id_status = @IdStatus;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END