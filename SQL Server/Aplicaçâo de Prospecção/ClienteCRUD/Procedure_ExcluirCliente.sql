CREATE PROCEDURE ExcluirCliente
	@IdCliente INT,
	@IdUsuario INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;

			IF(NOT EXISTS(SELECT * FROM Cliente WHERE id_cliente = @IdCliente AND id_status = 1))
				THROW 50000, 'Este cliente n�o est� em fase de cadastro', 1;

			IF(NOT EXISTS(SELECT * FROM Acesso a
							INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
							INNER JOIN Perfil  p ON (p.id_perfil = a.id_perfil)
						  WHERE a.id_usuario = @IdUsuario AND 
						  p.nome_perfil = 'OPERA��O')
			)                                  
				THROW 50000, 'Usu�rio n�o possui permiss�o para essa modifica��o', 1;

			DELETE FROM Analise WHere id_cliente = @IdCliente;
			DELETE FROM Telefone WHere id_cliente = @IdCliente;
			DELETE FROM Endereco WHere id_cliente = @IdCliente;
			DELETE FROM Cliente WHere id_cliente = @IdCliente;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END