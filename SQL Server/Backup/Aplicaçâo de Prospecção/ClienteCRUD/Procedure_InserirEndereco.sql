CREATE PROCEDURE InserirEndereco
	@CEP			CHAR(8),
	@Rua			VARCHAR(20),
	@Numero			VARCHAR(6),
	@Complemento	VARCHAR(15),
	@Bairro			VARCHAR(20),
	@IdCliente		INT,
	@IdCidade		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;

			DECLARE @ExisteCidade INT;
			SELECT @ExisteCidade = id_cidade FROM Cidade WHERE id_cidade = @IdCidade;
			IF(@ExisteCidade <= 0)
				THROW 50000, 'Cidade não encontrada na base de dados', 1;

			/*IF(dbo.ISEMPTY(@CEP) = 0)
				THROW 50000, 'Campo CEP está vazio', 1;*/
			IF(dbo.ISEMPTY(@Rua) = 0)
				THROW 50000, 'Campo rua está vazio', 1;
			IF(dbo.ISEMPTY(@Numero) = 0)
				THROW 50000, 'Campo número está vazio', 1;
			/*IF(dbo.ISEMPTY(@Complemento) = 0)
				THROW 50000, 'Campo complemento está vazio', 1;*/
			IF(dbo.ISEMPTY(@Bairro) = 0)
				THROW 50000, 'Campo bairro está vazio', 1;

			INSERT INTO Endereco(cep, rua, numero, complemento, bairro, id_cliente, id_cidade)
				VALUES (@CEP, @Rua, @Numero, @Complemento, @Bairro, @IdCliente, @IdCidade);
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;