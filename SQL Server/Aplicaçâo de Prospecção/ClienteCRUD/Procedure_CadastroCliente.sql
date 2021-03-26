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
	@IdCidade		INT,
	@IdUsuario		INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			DECLARE @IdStatus		INT;

			EXEC UsuarioValido @IdUsuario;

			IF(NOT EXISTS(SELECT * FROM Acesso a
							INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
							INNER JOIN Perfil  p ON (p.id_perfil = a.id_perfil)
						  WHERE a.id_usuario = @IdUsuario AND p.nome_perfil = 'OPERA��O')
			)
				THROW 50000, 'Usu�rio n�o possui permiss�o para cadastrar cliente', 1;

			SELECT @IdStatus = 1;

			IF(dbo.ISEMPTY(@Nome) = 0)
					THROW 50000, 'Campo nome est� vazio', 1;
			IF(dbo.ISEMPTY(@CPF) = 0)
					THROW 50000, 'Campo CPF est� vazio', 1;
			IF(dbo.ISEMPTY(@RG) = 0)
				THROW 50000, 'Campo RG est� vazio', 1;
			IF(dbo.ISEMPTY(@Email) = 0)
					THROW 50000, 'Campo e-mail est� vazio', 1;

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