CREATE PROCEDURE InserirNovoPerfil
	@NomePerfil VARCHAR(25)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(dbo.ISEMPTY(@NomePerfil) = 0)
					THROW 50000, 'Campo nome perfil está vazio', 1;

			INSERT INTO Perfil (nome_perfil, ativo)
				VALUES (@NomePerfil, 0);

			SELECT 'Perfil gravado com sucesso!' AS Retorno;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;