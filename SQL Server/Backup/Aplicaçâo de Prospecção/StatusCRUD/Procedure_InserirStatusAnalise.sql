CREATE PROCEDURE InserirStatusAnalise
	@NomeStatus		VARCHAR(40)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(dbo.ISEMPTY(@NomeStatus) = 0)
					THROW 50000, 'Campo nome status está vazio', 1;

			INSERT INTO StatusAnalise(nome_status, ativo)
				VALUES (@NomeStatus, 0);

			SELECT 'Status gravado com sucesso!' AS Retorno;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END