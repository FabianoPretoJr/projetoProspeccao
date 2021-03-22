CREATE PROCEDURE InserirNovoPais
	@NomePais	VARCHAR(25)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(dbo.ISEMPTY(@NomePais) = 0)
					THROW 50000, 'Campo nome pa�s est� vazio', 1;

			INSERT INTO Pais (nome_pais, ativo)
				VALUES (@NomePais, 0);

			SELECT 'Pa�s inserido com sucesso!' AS Retorno;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH;
END;