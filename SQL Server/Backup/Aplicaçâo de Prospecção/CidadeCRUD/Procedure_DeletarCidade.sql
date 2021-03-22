CREATE PROCEDURE DeletarCidade
	@IdCidade	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Cidade WHERE id_cidade = @IdCidade  AND ativo = 0))
				THROW 50000, 'Cidade não encontrada na base de dados', 1;

			UPDATE Cidade
				SET ativo = 1
				WHERE id_cidade = @IdCidade;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END