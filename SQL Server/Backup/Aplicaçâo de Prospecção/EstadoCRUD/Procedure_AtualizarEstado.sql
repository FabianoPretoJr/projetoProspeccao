CREATE PROCEDURE AtualizarEstado
	@IdEstado	INT,
	@NomeEstado	VARCHAR(25),
	@IdPais		INT
AS
BEGIN
	DECLARE @ExisteEstado	INT,
			@ExistePais		INT;

	BEGIN TRY
		BEGIN TRAN
			SELECT @ExisteEstado = id_estado FROM Estado WHERE id_estado = @IdEstado AND id_pais = @IdPais;
			SELECT @ExistePais = id_pais FROM Pais WHERE id_pais = @IdPais;

			IF(@ExistePais > 0)
				BEGIN
					IF(@ExisteEstado > 0)
						BEGIN
							IF(dbo.ISEMPTY(@NomeEstado) = 0)
								THROW 50000, 'Campo nome estado está vazio', 1;

							UPDATE Estado
								SET nome_estado = @NomeEstado
								WHERE id_estado = @IdEstado;

							SELECT 'Estado atualizado com sucesso!' AS Retorno;
						END
					ELSE
						THROW 50000, 'Estado não encontrado na base de dados! Impossível atualizar dados', 1;
				END
			ELSE
				THROW 50000, 'País não encontrado na base de dados, impossível inserir novo Estado', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;