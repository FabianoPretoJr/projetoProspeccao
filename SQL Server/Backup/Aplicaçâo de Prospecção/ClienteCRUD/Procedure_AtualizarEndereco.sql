CREATE PROCEDURE AtualizarEndereco
	@IdEndereco		INT,
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

			IF(NOT EXISTS(SELECT * FROM Endereco WHERE id_endereco = @IdEndereco AND id_cliente = @IdCliente))
				THROW 50000, 'Endereço não encontrado na base de dados', 1;

			IF(NOT EXISTS(SELECT * FROM Cidade WHERE id_cidade = @IdCidade))
				THROW 50000, 'Cidade não encontrada na base de dados', 1;

			IF(dbo.ISEMPTY(@CEP) = 0)
				THROW 50000, 'Campo CEP está vazio', 1;
			IF(dbo.ISEMPTY(@Rua) = 0)
				THROW 50000, 'Campo rua está vazio', 1;
			IF(dbo.ISEMPTY(@Numero) = 0)
				THROW 50000, 'Campo número está vazio', 1;
			IF(dbo.ISEMPTY(@Complemento) = 0)
				THROW 50000, 'Campo complemento está vazio', 1;
			IF(dbo.ISEMPTY(@Bairro) = 0)
				THROW 50000, 'Campo bairro está vazio', 1;

			UPDATE Endereco
				SET cep = @CEP,
					rua = @Rua,
					numero = @Numero,
					complemento = @Complemento,
					bairro = @Bairro,
					id_cliente = @IdCliente,
					id_cidade = @IdCidade
				WHERE id_endereco = @IdEndereco;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;