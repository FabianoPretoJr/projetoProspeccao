CREATE PROCEDURE ValidaOperacao
	@IdCliente	INT,
	@IdStatus	INT,
	@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			DECLARE @PaisCliente	VARCHAR(25),
					@PerfilUsuario	VARCHAR(25),
					@Status			VARCHAR(25);


			SELECT @Status = nome_status FROM StatusAnalise WHERE id_status = @IdStatus;


			IF(@Status = 'Aprovado')
				BEGIN
					SELECT 'Este cliente já está aprovado' AS Retorno;
				END
			ELSE IF(@Status = 'Reprovado')
				BEGIN
					SELECT 'Este cliente foi reprovado' AS Retorno;
				END
			ELSE IF(@Status = 'Análise')
				BEGIN
					
				END
			ELSE IF(@Status = 'Correção de cadastro')
				BEGIN
					PRINT 'Em produçâo!!!';
				END






			SELECT @PaisCliente = p.nome_pais 
			FROM Endereco e
				INNER JOIN Cidade c	 ON (c.id_cidade = e.id_cidade)
				INNER JOIN Estado es ON (es.id_estado = c.id_estado)
				INNER JOIN Pais   p  ON (p.id_pais = es.id_pais)
			WHERE e.id_cliente = @IdCliente;

			SELECT @PerfilUsuario = p.nome_perfil
			FROM Acesso a
				INNER JOIN Usuario u ON (u.id_usuario = a.id_usuario)
				INNER JOIN Perfil  p ON (p.id_perfil = a.id_perfil)
			WHERE a.id_usuario = 1; --@IdUsuario;

			SELECT @PerfilUsuario;

			IF(UPPER(@PaisCliente) = 'BRASIL')
				BEGIN
					IF(UPPER(@PerfilUsuario) = 'GERÊNCIA')
						BEGIN

						END
				END
			ELSE
				BEGIN
					PRINT 'Em produçâo!!!';
				END

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		THROW;
	END CATCH
END