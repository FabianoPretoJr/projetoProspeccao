CREATE PROCEDURE ReprovarFluxo
	@IdCliente	INT,
	@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;
			EXEC UsuarioValido @IdUsuario;

			DECLARE	@IdStatusAtual		INT,
					@IdPerfilUsuario	INT,
					@PaisCliente		VARCHAR(25);

			IF(NOT EXISTS(SELECT * FROM Cliente WHERE id_cliente = @IdCliente AND (id_status = 2 OR id_status = 4)))
				THROW 50000, 'Este cliente não está em fase de análise', 1;

			SELECT @PaisCliente = p.nome_pais
				FROM Endereco e
					INNER JOIN Cidade c	 ON (c.id_cidade = e.id_cidade)
					INNER JOIN Estado es ON (es.id_estado = c.id_estado)
					INNER JOIN Pais   p  ON (p.id_pais = es.id_pais)
				WHERE e.id_cliente = @IdCliente;

			SELECT @IdStatusAtual = id_status FROM Cliente WHERE id_cliente = @IdCliente;

			IF(NOT EXISTS(SELECT * FROM Acesso a
							INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
							INNER JOIN Perfil  p ON (p.id_perfil = a.id_perfil)
						  WHERE a.id_usuario = @IdUsuario AND 
						  ((p.nome_perfil = 'GERÊNCIA' AND @IdStatusAtual = 2) OR
						  (p.nome_perfil = 'CONTROLE DE RISCO' AND @PaisCliente <> 'Brasil' AND @IdStatusAtual = 4) OR
						  (p.nome_perfil = 'ADMINISTRAÇÃO')))
			)                                  
				THROW 50000, 'Usuário não possui permissão para essa modificação', 1;

			IF(EXISTS(SELECT * FROM Analise WHERE id_cliente = @IdCliente AND id_usuario = @IdUsuario))
				THROW 50000, 'Usuário não pode interagir de novo com o fluxo desde cliente', 1;

			INSERT INTO Analise (id_status, id_cliente, id_usuario, data_hora)
						VALUES (6, @IdCliente, @IdUsuario, GETDATE());

			UPDATE Cliente
				SET id_status = 6
				WHERE @IdCliente = id_cliente;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;