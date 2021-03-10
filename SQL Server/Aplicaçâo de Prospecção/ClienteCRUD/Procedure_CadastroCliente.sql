CREATE PROCEDURE CadastroCliente
	@Nome			VARCHAR(45),
	@CPF			CHAR(11),
	@RG				CHAR(8),
	@DataNascimento	DATE,
	@Email			VARCHAR(30),
	@NumeroTelefone	VARCHAR(9),
	@CEP			CHAR(8),
	@Rua			VARCHAR(20),
	@Numero			VARCHAR(6),
	@Complemento	VARCHAR(15),
	@Bairro			VARCHAR(20),
	@IdCidade		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			DECLARE @IdStatus		INT,
					@IdUsuario		INT;

			SELECT @IdStatus = id_status FROM StatusAnalise WHERE nome_status = 'Cadastrato';
			SET @IdUsuario = 2;

			IF(dbo.ISEMPTY(@Nome) = 0)
					THROW 50000, 'Campo nome está vazio', 1;
			IF(dbo.ISEMPTY(@CPF) = 0)
					THROW 50000, 'Campo CPF está vazio', 1;
			IF(dbo.ISEMPTY(@RG) = 0)
				THROW 50000, 'Campo RG está vazio', 1;
			IF(dbo.ISEMPTY(@Email) = 0)
					THROW 50000, 'Campo e-mail está vazio', 1;

			INSERT INTO Cliente (nome, cpf, rg, data_nascimento, email, id_status)
				VALUES (@Nome, @CPF, @RG, @DataNascimento, @Email, @IdStatus);

			DECLARE @IdCliente	INT;
			SELECT @IdCliente = SCOPE_IDENTITY();

			EXEC InserirTelefone @NumeroTelefone, @IdCliente;

			EXEC InserirEndereco @CEP, @Rua, @Numero, @Complemento, @Bairro, @IdCliente, @IdCidade;

			EXEC RegistroAnaliseFluxo @IdCliente, @IdStatus, @IdUsuario;

			SELECT 'Cliente cadastrado!' AS Retorno;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;