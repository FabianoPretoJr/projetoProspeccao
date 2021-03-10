CREATE PROCEDURE CadastroUsuario
	@LoginUsuario	VARCHAR(45),
	@Senha			VARCHAR(15)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN --CRIPT PARA SENHA
			IF(dbo.ISEMPTY(@LoginUsuario) = 0)
				THROW 50000, 'Campo login está vazio', 1;
			IF(dbo.ISEMPTY(@Senha) = 0)
				THROW 50000, 'Campo senha está vazio', 1;

			INSERT INTO Usuario (login_usuario, senha, ativo)
				VALUES (@LoginUsuario, @Senha, 0);

				SELECT 'Usuário gravado com sucesso!' AS Retorno;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;