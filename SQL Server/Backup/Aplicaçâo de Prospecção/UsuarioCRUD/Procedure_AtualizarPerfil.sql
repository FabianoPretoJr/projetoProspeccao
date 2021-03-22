CREATE PROCEDURE AtualizarPerfil
	@IdPerfil		INT,
	@NomeNovoPerfil	VARCHAR(25)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(dbo.ISEMPTY(@NomeNovoPerfil) = 0)
					THROW 50000, 'Campo nome perfil está vazio', 1;

			IF(NOT EXISTS(SELECT * FROM Perfil WHERE id_perfil = @IdPerfil AND ativo = 0))
				THROW 50000, 'Perfil não encontrado na base de dados', 1;

			UPDATE Perfil
				SET nome_perfil = @NomeNovoPerfil
				WHERE id_perfil = @IdPerfil
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;