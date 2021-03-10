CREATE PROCEDURE AtualizarPais
	@IdPais			INT,
	@NovoNomePais	VARCHAR(25)
AS
BEGIN
	DECLARE @ExistePais	 INT;

	BEGIN TRY
		BEGIN TRAN
			SELECT @ExistePais = id_pais FROM Pais WHERE id_pais = @IdPais;

			IF(@ExistePais > 0)
				BEGIN
					IF(dbo.ISEMPTY(@NovoNomePais) = 0)
						THROW 50000, 'Campo nome pa�s est� vazio', 1;

					UPDATE Pais 
						SET nome_pais = @NovoNomePais 
						WHERE id_pais = @IdPais;

					SELECT 'Pa�s atualizado com sucesso!' AS Retorno;
				END
			ELSE
				THROW 50000, 'Pa�s n�o encontrado na base de dados! Imposs�vel atualizar dados', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH;
END;