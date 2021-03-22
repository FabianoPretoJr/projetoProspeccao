CREATE PROCEDURE DeletarPerfil
	@IdPerfil		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Perfil WHERE id_perfil = @IdPerfil AND ativo = 0))
				THROW 50000, 'Perfil não encontrado na base de dados', 1;

			UPDATE Perfil
				SET ativo = 1
				WHERE id_perfil = @IdPerfil
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;