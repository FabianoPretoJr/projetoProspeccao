CREATE PROCEDURE InserirNovoEstado
	@NomeEstado		VARCHAR(25),
	@IdPais			INT
AS
BEGIN
	DECLARE @ExistePais		INT;

	BEGIN TRY
		BEGIN TRAN
			SELECT @ExistePais = id_pais FROM Pais WHERE id_pais = @IdPais;

			IF(@ExistePais > 0)
				BEGIN
					IF(dbo.ISEMPTY(@NomeEstado) = 0)
						THROW 50000, 'Campo nome estado est� vazio', 1;

					INSERT INTO Estado (nome_estado, ativo, id_pais) 
						VALUES (@NomeEstado, 0, @IdPais);

					SELECT 'Estado inserido com sucesso!' AS Retorno;
				END
			ELSE
				THROW 50000, 'Pa�s n�o encontrado na base de dados, imposs�vel inserir novo Estado', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;