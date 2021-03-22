CREATE PROCEDURE EnviarAnaliseGerencia
	@IdCliente	INT,
	@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;
			EXEC UsuarioValido @IdUsuario;

			DECLARE	@IdStatusAtual		INT;

			SELECT @IdStatusAtual = id_status FROM Cliente WHERE id_cliente = @IdCliente;

			IF(@IdStatusAtual = 6)
				THROW 50000, 'Este cliente foi reprovado', 1;

			IF(@IdStatusAtual <> 1)
				THROW 50000, 'Este cliente não está em fase de cadastro', 1;

			IF(NOT EXISTS(SELECT * FROM Acesso a
							INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
							INNER JOIN Perfil  p ON (p.id_perfil = a.id_perfil)
						  WHERE a.id_usuario = @IdUsuario AND p.nome_perfil = 'OPERAÇÃO') 
			)
				THROW 50000, 'Usuário não possui permissão para essa modificação', 1;

			INSERT INTO Analise (id_status, id_cliente, id_usuario, data_hora)
				VALUES (2, @IdCliente, @IdUsuario, GETDATE());

			UPDATE Cliente
				SET id_status = 2
				WHERE id_cliente = @IdCliente;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;