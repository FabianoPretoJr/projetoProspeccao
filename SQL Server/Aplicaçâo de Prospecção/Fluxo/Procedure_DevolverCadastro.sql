CREATE PROCEDURE DevolverCadastro
	@IdCliente	INT,
	@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;
			EXEC UsuarioValido @IdUsuario;

			DECLARE	@IdStatusAtual		INT,
					@PaisCliente		VARCHAR(25);

			SELECT @IdStatusAtual = id_status FROM Cliente WHERE id_cliente = @IdCliente;

			SELECT @PaisCliente = p.nome_pais
				FROM Endereco e
					INNER JOIN Cidade c	 ON (c.id_cidade = e.id_cidade)
					INNER JOIN Estado es ON (es.id_estado = c.id_estado)
					INNER JOIN Pais   p  ON (p.id_pais = es.id_pais)
				WHERE e.id_cliente = @IdCliente;

			IF(@IdStatusAtual = 6)
				THROW 50000, 'Este cliente foi reprovado', 1;

			IF(NOT EXISTS(SELECT * FROM Cliente WHERE id_cliente = @IdCliente AND id_status = 7))
				THROW 50000, 'Este cliente não está em correção de cadastro', 1;

			IF(NOT EXISTS(SELECT * FROM Acesso a
							INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
							INNER JOIN Perfil  p ON (p.id_perfil = a.id_perfil)
						  WHERE a.id_usuario = @IdUsuario AND (p.nome_perfil = 'OPERAÇÃO'))
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