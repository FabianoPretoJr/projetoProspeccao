CREATE PROCEDURE DeletarUsuario
	@IdUsuario		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Usuario WHERE id_usuario = @IdUsuario AND ativo = 0))
				THROW 50000, 'Usu�rio n�o encontrado na base de dados', 1;

			UPDATE Usuario
				SET ativo = 1
				WHERE id_usuario = @IdUsuario
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;