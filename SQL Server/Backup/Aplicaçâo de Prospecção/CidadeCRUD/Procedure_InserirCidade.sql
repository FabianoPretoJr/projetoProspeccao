CREATE PROCEDURE InserirNovaCidade
	@NomeCidade		VARCHAR(25),
	@IdEstado		INT
AS
BEGIN
	DECLARE @ExisteCidade	INT,
			@ExisteEstado	INT,
			@EstadoIgual	INT;

	BEGIN TRY
		BEGIN TRAN
			SELECT @ExisteCidade = id_cidade, @EstadoIgual = id_estado FROM Cidade WHERE nome_cidade = @NomeCidade;
			SELECT @ExisteEstado = id_estado FROM Estado WHERE id_estado = @IdEstado;

			IF(@ExisteEstado > 0)
				BEGIN
					IF(@ExisteCidade > 0 AND @EstadoIgual = @ExisteEstado)
							THROW 50000, 'Cidade já existe neste estado! Gravação não realizada', 1;
					ELSE
						BEGIN
							IF(dbo.ISEMPTY(@NomeCidade) = 0)
								THROW 50000, 'Campo nome cidade está vazio', 1;

							INSERT INTO Cidade(nome_cidade, id_estado, ativo) 
								VALUES (@NomeCidade, @IdEstado, 0);

							SELECT 'Cidade inserida com sucesso!' AS Retorno;
						END
				END
			ELSE
				THROW 50000, 'Estado não encontrado na base de dados, impossível inserir nova cidade', 1;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;