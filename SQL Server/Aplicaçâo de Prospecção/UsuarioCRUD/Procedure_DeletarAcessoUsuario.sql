CREATE PROCEDURE DeletarAcessoUsuario
	@IdUsuario		INT,
	@IdPerfil		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Acesso WHERE id_usuario = @IdUsuario AND id_perfil = @IdPerfil))
				THROW 50000, 'Acesso não encontrado na base de dados', 1;

			DELETE Acesso
				WHERE id_usuario = @IdUsuario AND id_perfil = @IdPerfil;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;