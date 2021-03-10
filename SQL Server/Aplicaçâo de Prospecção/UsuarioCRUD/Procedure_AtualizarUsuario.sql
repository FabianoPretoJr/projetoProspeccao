CREATE PROCEDURE AtualizarUsuario
	@IdUsuario		INT,
	@LoginUsuario	VARCHAR(45),
	@Senha			VARCHAR(15)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF(dbo.ISEMPTY(@LoginUsuario) = 0)
				THROW 50000, 'Campo login está vazio', 1;
			IF(dbo.ISEMPTY(@Senha) = 0)
				THROW 50000, 'Campo senha está vazio', 1;

			IF(NOT EXISTS(SELECT * FROM Usuario WHERE id_usuario = @IdUsuario))
				THROW 50000, 'Usuário não encontrado na base de dados', 1;

			/*
			Quando trabalhamos com o front, ele envia os dados antigos, 
			ai sobre escreve, senão faz um if pra vericar cada campo 
			e fazer um update individual
			*/
			UPDATE	Usuario
				SET login_usuario = @LoginUsuario,
					senha = @Senha
				WHERE id_usuario = @IdUsuario;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;