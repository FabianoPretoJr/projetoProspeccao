CREATE PROCEDURE CriarAcessoUsuario
	@IdUsuario	INT,
	@IdPerfil	INT
AS
BEGIN
	DECLARE @ExisteUsuario	INT,
			@ExistePerfil	INT,
			@ExisteAcesso	INT;

	BEGIN TRY
		BEGIN TRAN
			SELECT @ExisteUsuario = id_usuario FROM Usuario WHERE id_usuario = @IdUsuario;
			SELECT @ExistePerfil = id_perfil FROM Perfil WHERE id_perfil = @IdPerfil;
			SELECT @ExisteAcesso = id_usuario FROM Acesso WHERE id_usuario = @IdUsuario AND id_perfil = @IdPerfil;

			IF(@ExisteUsuario > 0 AND @ExistePerfil > 0)
				BEGIN
					IF(@ExisteAcesso > 0)
						THROW 50000, 'Relacionamento já criado', 1;
					ELSE
						BEGIN
							INSERT INTO Acesso (id_usuario, id_perfil)
								VALUES (@IdUsuario, @IdPerfil);

							SELECT 'Dados gravados com sucesso' AS Retorno;
						END
				END
			ELSE
				THROW 50000, 'Erro, não é possível realizar o relacionamento devido ID inválido', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH
END;