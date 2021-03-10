CREATE PROCEDURE DeletarEstado
	@IdEstado		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Estado WHERE id_estado = @IdEstado  AND ativo = 0))
				THROW 50000, 'Estado não encontrado na base de dados', 1;

			UPDATE Estado
				SET ativo = 1
				WHERE id_estado = @IdEstado;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END