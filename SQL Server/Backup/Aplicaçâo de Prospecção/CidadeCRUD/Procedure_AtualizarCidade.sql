CREATE PROCEDURE AtualizarCidade
	@IdCidade	INT,
	@NomeCidade VARCHAR(25),
	@IdEstado	INT
AS
BEGIN
	DECLARE @ExisteCidade	INT,
			@ExisteEstado	INT;
	
	BEGIN TRY
		BEGIN TRAN
			SELECT @ExisteCidade = id_cidade FROM Cidade WHERE id_cidade = @IdCidade AND id_estado = @IdEstado;
			SELECT @ExisteEstado = id_estado FROM Estado WHERE id_estado = @IdEstado;

			IF(@ExisteEstado > 0)
				BEGIN
					IF(@ExisteCidade > 0)
						BEGIN
							IF(dbo.ISEMPTY(@NomeCidade) = 0)
								THROW 50000, 'Campo nome cidade está vazio', 1;

							UPDATE Cidade
								SET nome_cidade = @NomeCidade
								WHERE id_cidade = @IdCidade;

							SELECT 'Cidade atualizada com sucesso!' AS Retorno;
						END
					ELSE
						THROW 50000, 'Cidade não encontrada na base de dados! Impossível atualizar dados', 1;
				END
			ELSE
				THROW 50000, 'Estado não encontrado na base de dados, impossível inserir nova Cidade', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;