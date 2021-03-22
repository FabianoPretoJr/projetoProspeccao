CREATE PROCEDURE DeletarPais
	@IdPais		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(NOT EXISTS(SELECT * FROM Pais WHERE id_pais = @IdPais AND ativo = 0))
				THROW 50000, 'País não encontrado na base de dados', 1;

			UPDATE Pais
				SET ativo = 1
				WHERE id_pais = @IdPais;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END