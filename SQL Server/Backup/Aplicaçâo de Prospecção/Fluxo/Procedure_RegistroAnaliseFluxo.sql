CREATE PROCEDURE RegistroAnaliseFluxo
	@IdCliente	INT,
	@IdStatus	INT,
	@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			EXEC ClienteValido @IdCliente;
			EXEC UsuarioValido @IdUsuario;
			EXEC StatusValido @IdStatus;

			INSERT INTO Analise (id_status, id_cliente, id_usuario, data_hora)
				VALUES (@IdStatus, @IdCliente, @IdUsuario, GETDATE());
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END;