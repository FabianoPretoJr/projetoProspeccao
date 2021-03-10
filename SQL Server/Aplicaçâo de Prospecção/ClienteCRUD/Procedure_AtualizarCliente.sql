CREATE PROCEDURE AtualizarCliente
	@IdCliente		INT,
	@Nome			VARCHAR(45),
	@CPF			CHAR(11),
	@RG				CHAR(8),
	@DataNascimento	DATE,
	@Email			VARCHAR(30)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;

			IF(dbo.ISEMPTY(@Nome) = 0)
					THROW 50000, 'Campo nome est� vazio', 1;
			IF(dbo.ISEMPTY(@CPF) = 0)
					THROW 50000, 'Campo CPF est� vazio', 1;
			IF(dbo.ISEMPTY(@RG) = 0)
				THROW 50000, 'Campo RG est� vazio', 1;
			IF(dbo.ISEMPTY(@Email) = 0)
					THROW 50000, 'Campo e-mail est� vazio', 1;

			UPDATE Cliente
				SET nome = @Nome,
					cpf = @CPF,
					rg = @RG,
					data_nascimento = @DataNascimento,
					email = @Email
				WHERE id_cliente = @IdCliente;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;