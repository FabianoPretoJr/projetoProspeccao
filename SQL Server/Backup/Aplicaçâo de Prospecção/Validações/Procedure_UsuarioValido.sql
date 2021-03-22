CREATE PROCEDURE UsuarioValido
	@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS (SELECT * FROM Usuario WHERE id_usuario = @IdUsuario))
				THROW 50000, 'Usuário não encontrado na base de dados', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;