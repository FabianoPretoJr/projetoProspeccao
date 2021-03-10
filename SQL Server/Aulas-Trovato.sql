USE SQL_DB_1;

CREATE TABLE Situacao(
	id_situacao		INT PRIMARY KEY	NOT NULL,
	situacao		VARCHAR(25)		NOT NULL,
	data_cadastro	DATETIME,
	login_cadastro	VARCHAR(15)
);

CREATE TABLE Cursos(
	id_curso		INT PRIMARY KEY	NOT NULL,
	nome_curso		VARCHAR(200)	NOT NULL,
	data_cadastro	DATETIME		NOT NULL,
	login_cadastro	VARCHAR(15)		NOT NULL
);

CREATE TABLE Turmas(
	id_turma		INT PRIMARY KEY	NOT NULL,
	--id_aluno		INT				NOT NULL,
	id_curso		INT				NOT NULL,
	--valor_turma   NUMERIC(15,2)	NOT NULL,
	--desconto		NUMERIC(3,2)	NOT NULL,
	data_inicio		DATE			NOT NULL,
	data_termino	DATE,
	data_cadastro	DATETIME		NOT NULL,
	login_cadastro	VARCHAR(15)
);

 /*
ALTER TABLE Turmas
		ADD CONSTRAINT fk_Alunos FOREIGN KEY (id_aluno) REFERENCES Alunos (id_aluno);

ALTER TABLE Turmas
		ADD CONSTRAINT fk_Curso FOREIGN KEY (id_curso) REFERENCES Cursos (id_curso);
*/

/*
ALTER TABLE Turmas
		DROP CONSTRAINT fk_alunos;

ALTER TABLE Turmas
		DROP COLUMN id_aluno;

ALTER TABLE Turmas
		DROP COLUMN valor_turma;

ALTER TABLE Turmas
		DROP COLUMN desconto;
*/

CREATE TABLE Alunos(
	id_aluno		INT PRIMARY KEY NOT NULL,
	nome			VARCHAR(200)	NOT NULL,
	data_nascimento	DATE			NOT NULL,
	sexo			VARCHAR(1)		NOT NULL, --M para MASCULINO ou F para FEMININO
	data_cadastro	DATETIME		NOT NULL,
	login_cadastro	VARCHAR(15)		NOT NULL
);

/*
ALTER TABLE Alunos
		ADD CONSTRAINT fk_Turmas FOREIGN KEY (id_aluno) REFERENCES Turmas (id_turma);

ALTER TABLE Alunos
		DROP CONSTRAINT fk_Turmas;
*/

CREATE TABLE AlunosxTurmas(
	id_turma		INT				NOT NULL,
	id_aluno		INT				NOT NULL,
	valor			NUMERIC(13,2)	NOT NULL,
	valor_desconto	NUMERIC(3,2)	NOT NULL,
	data_cadastro	DATETIME		NOT NULL,
	login_cadastro	VARCHAR(15)		NOT NULL
);

/*
ALTER TABLE AlunosxTurmas
		ADD CONSTRAINT fk_turma FOREIGN KEY (id_turma) REFERENCES Turmas(id_turma);

ALTER TABLE AlunosxTurmas
		ADD CONSTRAINT fk_aluno FOREIGN KEY (id_aluno) REFERENCES Alunos(id_aluno);
*/
		
CREATE TABLE Registro_Presenca(
	id_turma		INT				NOT NULL,
	id_aluno		INT				NOT NULL,
	id_situacao		INT				NOT NULL,
	data_presenca	DATE			NOT NULL,
	data_cadastro	DATE			NOT NULL,
	login_cadastro	VARCHAR(15)		NOT NULL
);

/*
ALTER TABLE Registro_Presenca
		ADD CONSTRAINT fk_TurmasRP FOREIGN KEY (id_turma) REFERENCES Turmas (id_turma);

ALTER TABLE Registro_Presenca
		ADD CONSTRAINT fk_AlunoRP FOREIGN KEY (id_aluno) REFERENCES Alunos (id_aluno);

ALTER TABLE Registro_Presenca
		ADD CONSTRAINT fk_SituacaoRP FOREIGN KEY (id_situacao) REFERENCES Situacao (id_situacao);
*/

/*
DROP TABLE Alunos;
DROP TABLE Situacao;
DROP TABLE Registro_Presenca;
DROP TABLE Cursos;
DROP TABLE Turmas;
*/

/*
INSERT INTO Alunos (id_aluno, nome, data_nascimento, sexo, data_cadastro, login_cadastro) 
	VALUES (7, 'Gustavo', '15/09/2001', 'M', '23/02/2021 12:00:00', 'FABIANO');

INSERT INTO Cursos (id_curso, nome_curso, data_cadastro, login_cadastro)
	VALUES (2, 'React', '23/02/2021 12:00:00', 'FABIANO');

INSERT INTO Situacao (id_situacao, situacao, data_cadastro, login_cadastro)
	VALUES (3, 'Infermo', '23/02/2021 12:00:00', 'FABIANO');

INSERT INTO Turmas (id_turma, id_curso, data_inicio, data_termino, data_cadastro, login_cadastro)
	VALUES (2, 2, '24/02/2021', '20/03/2021', GETDATE(), 'FABIANO'); --Função GETDATE() pega o horário da máquina

INSERT INTO AlunosxTurmas (id_turma, id_aluno, valor, valor_desconto, data_cadastro, login_cadastro)
	VALUES (1, 3, 3000, 0.2, GETDATE(), 'FABIANO');
*/

--Consulta básica

SELECT * FROM Alunos;
SELECT * FROM Cursos;
SELECT * FROM Situacao;
SELECT * FROM Turmas;
SELECT * FROM Registro_Presenca;
SELECT * FROM AlunosxTurmas;

--Utilizar Alias (APELIDO) para nome de tabela

SELECT * FROM dbo.Turmas T;

SELECT T.* FROM dbo.Turmas T;

SELECT T.id_turma, T.id_curso, T.data_inicio FROM dbo.Turmas T;

--Utilizar nomes personalizados para nossos campos

SELECT T.id_curso AS IDC, T.id_turma AS IDT, T.data_inicio AS "DATA COMEÇO" FROM dbo.Turmas T;

--Segunda forma (sem o AS)

SELECT T.id_curso IDC, T.id_turma IDT, T.data_inicio "DATA COMEÇO" FROM dbo.Turmas T;

--SELETC com WHERE

SELECT A.* FROM Alunos A WHERE A.nome = 'Karine'; --IGUAL (=)

SELECT A.* FROM Alunos A WHERE A.nome <> 'Karine'; --DIFERENTE (<>)

SELECT A.* FROM Alunos A WHERE A.data_nascimento >= '13/09/2001'; --MAIOR ou IGUAL (>)

SELECT A.* FROM Alunos A WHERE A.data_nascimento <= '13/09/2001'; --MENOR ou IGUAL (<)

SELECT A.* FROM Alunos A WHERE A.sexo = 'F';

SELECT A.* FROM Alunos A WHERE A.sexo = 'M' and A.data_nascimento >= '13/09/2001'; --and (&&)

SELECT A.* FROM Alunos A WHERE A.sexo = 'F' or A.data_nascimento >= '13/09/2001'; --or (||)

SELECT A.nome, A.sexo, year(A.data_nascimento) FROM Alunos A WHERE A.data_nascimento >= '13/09/2001'; --Função YEAR() pega apenas o ano

--Operações no SELECT

SELECT * FROM AlunosxTurmas;

SELECT * FROM AlunosxTurmas WHERE valor > 500;

SELECT valor * valor_desconto AS DESCONTO FROM AlunosxTurmas; --Faz multiplicação entre valor e desconto, e  já trás o valor de desconto oferecido

SELECT id_aluno, valor * valor_desconto AS DESCONTO FROM AlunosxTurmas WHERE valor > 500; --Com filtro de valor > 500

SELECT FLOOR(valor * valor_desconto) AS DESCONTO FROM AlunosxTurmas WHERE valor_desconto > 0 and valor > 500; --Arredor para baixo, sumir com as casas decimais

--JOINS

SELECT c.nome_curso, t.data_inicio, t.data_termino, 
	FLOOR(axt.valor) as valor_bruto, FLOOR((axt.valor * axt.valor_desconto)) as desconto,
	FLOOR(axt.valor - (axt.valor * axt.valor_desconto)) as valor_liquido
FROM AlunosxTurmas axt, Turmas t, Cursos c
WHERE axt.id_turma = t.id_turma and t.id_curso = c.id_curso;

--ESTRUTURA INNER JOIN
/*
SELECT *
FROM TableA a
INNER JOIN TableB b
	ON a.KEY = b.KEY
*/

SELECT C.id_curso, C.nome_curso, COUNT(T.id_turma) AS Total_Turmas
FROM Turmas t
INNER JOIN Cursos C 
	ON C.id_curso = T.id_curso
GROUP BY C.id_curso, C.nome_curso;

--Todos os cursos, independente se há ou não turmas
--PADRÃO ANSI
SELECT c.nome_curso, COUNT(t.id_turma) AS Total_Turmas
FROM Turmas t
RIGHT JOIN Cursos c
	ON c.id_curso = t.id_curso
GROUP BY c.nome_curso;

SELECT c.* FROM Turmas t, Cursos c;

SELECT c.nome_curso, COUNT(t.id_turma) AS Total_Turmas
FROM Turmas t, Cursos c
WHERE c.id_curso = t.id_curso
GROUP BY c.nome_curso;

--Lista completa de alunos

SELECT c.nome_curso, axt.valor, axt.valor_desconto, t.data_inicio, t.data_termino, a.nome, a.sexo
FROM AlunosxTurmas axt
INNER JOIN Turmas t
	ON t.id_turma = axt.id_turma
INNER JOIN Cursos c
	ON c.id_curso = t.id_curso
INNER JOIN Alunos a
	ON a.id_aluno = axt.id_aluno;

--Quantidade de turmas com alunos

SELECT c.nome_curso, t.id_turma, COUNT(1) AS Total
FROM Turmas t
INNER JOIN AlunosxTurmas atx
	ON atx.id_turma = t.id_turma
INNER JOIN Cursos c
	ON c.id_curso = t.id_curso
GROUP BY c.nome_curso, t.id_turma

--Operações matemáticas

--SOMA

SELECT 1 + 2 AS Resultado;

SELECT 458.99 + 899 + 7.77 AS Resultado;

--SUBTRAÇÃO

SELECT 233 - (78.99 + 333) AS Resultado;

--DIVISÃO

SELECT 50 / 2 AS Resultado;

SELECT 49 / 2 AS Resultado;

SELECT 49.0 / 2 AS Resultado;

SELECT 49.99 / 2 AS Resultado;

--MULTIPLICAÇÃO

SELECT 50 * 2 AS Resultado;

SELECT 50.88 * 3 AS Resultado;

--POTENCIAÇÃO (= 2 AO QUADRADO)

SELECT SQUARE(7) AS Resultado;

SELECT POWER(3, 3) AS Resultado; --Para demais elevaçôes, no caso de 3

SELECT POWER(2, 8) AS Resultado;

--PORCENTAGEM

SELECT 100 * 1.1 AS Resultado;

SELECT 100 + (100 * 0.1) AS Resultado;

SELECT 100 * 0.9 AS Resultado;

SELECT 100 * 0.1 AS Resultado;

--ABS

SELECT ABS(100-999) AS Resultado;

SELECT ABS(-100) AS Resultado;

--RAIS QUADRADA

SELECT SQRT(49) AS Resultado;

SELECT SQRT(7) AS Resultado;

--PI

SELECT PI() AS Resultado;

--DATA ATUAL

SELECT GETDATE() AS Resultado;

--SIGNAL

SELECT SIGN(-10) AS Resultado;

SELECT SIGN(10) AS Resultado;

SELECT SIGN(NULL) AS Resultado;

SELECT SIGN(0) AS Resultado;

--SOMA

SELECT SUM(1500 + 5000) AS Resultado; --Funçâo de agregação

--IF...ELSE...

IF 10 > 20
	SELECT '10 é maior que 20';
ELSE
	SELECT '10 é menor que 20';

---------------------------------------------------------

IF DATENAME(WEEKDAY, GETDATE()) IN ('SÁBADO', 'DOMINGO')
	SELECT 'Não estamos em um dia de semana. Hoje é ' + DATENAME(WEEKDAY, GETDATE());
ELSE
	SELECT 'Estamos em um dia de semana. Hoje é ' + DATENAME(WEEKDAY, GETDATE());

--VARIÁVEIS GLOBAIS DO SQL

SELECT @@SERVERNAME;

SELECT @@LANGUAGE;

SELECT @@LANGID;

SELECT @@TRANCOUNT;

---------------------------------------------------------

IF @@LANGUAGE <> 'Português (Brasil)'
	SELECT 'Today is ' + DATENAME(WEEKDAY, GETDATE());
ELSE
	SELECT 'Hoje é ' + DATENAME(WEEKDAY, GETDATE());

---------------------------------------------------------

IF OBJECT_ID('dbo.Alunos', 'U') IS NULL
	SELECT 'Esta tabela não existe!';
ELSE
	EXEC SP_COLUMNS Alunos;

---------------------------------------------------------

DECLARE @vIdadeMax INT;
DECLARE @vParam	   INT;

SET @vIdadeMax = 17;
SET @vParam = 25;

IF @vIdadeMax >= @vParam
	SELECT nome, data_nascimento, DATEDIFF(YEAR, data_nascimento, GETDATE()) AS Idade FROM Alunos
		WHERE DATEDIFF(YEAR, data_nascimento, GETDATE()) >= @vIdadeMax
		ORDER BY 3 ASC;
ELSE
	SELECT nome, data_nascimento, DATEDIFF(YEAR, data_nascimento, GETDATE()) AS Idade FROM Alunos
		WHERE DATEDIFF(YEAR, data_nascimento, GETDATE()) < @vIdadeMax
		ORDER BY 3 ASC;

--WHILE

SELECT * INTO tTEMP FROM Alunos; --Criar tabela temporaria
SELECT * FROM tTEMP;

--SUBSTITUIÇÃO DE VALORES COM O WHILE

DECLARE @vSTRING VARCHAR(100);
SET @vSTRING = 'SQL         SERVER         |';

WHILE CHARINDEX('  ', @vSTRING) > 0
BEGIN
	SET @vSTRING = REPLACE(@vSTRING, '  ', ' ')
END

SELECT @vSTRING;

---------------------------------------------------------

DECLARE @vCONT INT;
SET @vCONT = 1;

WHILE (@vCONT <= 10)
BEGIN
	PRINT 'O contador está em: ' + CONVERT(VARCHAR, @vCONT)
		SET @vCONT = @vCONT + 1;
END

---------------------------------------------------------

DECLARE @vCONT1 INT;
SET @vCONT1 = 1;

WHILE(@vCONT1 <= 10)
BEGIN
	PRINT 'O contador está em: ' + CONVERT(VARCHAR, @vCONT1)
	IF @vCONT1 = 7
		BREAK --CONTINUE
	SET @vCONT1 = @vCONT1 + 1;
END

--Números impares e pares

DECLARE @vCONT2 INT;
SET @vCONT2 = 1;

WHILE(@vCONT2 <= 17)
BEGIN
	IF @vCONT2 % 2 = 1
	BEGIN
		SET @vCONT2 = @vCONT2 + 1
		CONTINUE
	END
	PRINT 'O valor é: ' + CONVERT(VARCHAR, @vCONT2);

	SET @vCONT2 = @vCONT2 + 1;
END

DROP TABLE tTEMP;

--LER REGISTROS EM UMA TABELA

SELECT x.*
INTO tTEMP
FROM (
	SELECT ROW_NUMBER() OVER(ORDER BY id_aluno) AS linha,
		y.id_aluno, y.nome, y.nome_curso, y.data_inicio, y.data_termino
	FROM(
		SELECT a.id_aluno, a.nome, c.nome_curso, t.data_inicio, t.data_termino
		FROM AlunosxTurmas axt
			INNER JOIN Turmas t ON (t.id_turma = axt.id_turma)
			INNER JOIN Cursos c ON (c.id_curso = t.id_curso)
			INNER JOIN Alunos a ON (a.id_aluno = axt.id_aluno)
	) y
) x

---------------------------------------------------------

DECLARE @Contador     INT,
		@MaxLinha     INT,
		@CursoProcura NVARCHAR(100),
		@CursoNome	  NVARCHAR(100),
		@NomeAluno	  NVARCHAR(100);

SET @CursoProcura = 'React';

SELECT @Contador = MIN(linha), @MaxLinha = MAX(linha) FROM tTEMP;

WHILE(@Contador IS NOT NULL AND @Contador <= @MaxLinha)
BEGIN
	SELECT @CursoNome = nome_curso, @NomeAluno = nome
	FROM tTEMP
	WHERE linha = @Contador;

	IF CHARINDEX(@CursoProcura, @CursoNome) > 0
		PRINT CONVERT(VARCHAR, @Contador) + '> Curso: ' + @CursoNome + ' Aluno: ' + @NomeAluno;

	SET @Contador = @Contador + 1;
END

--CASE...ELSE...END

DROP TABLE tTEMP;

SELECT x.* 
INTO tTemp
FROM(
	SELECT ROW_NUMBER() OVER(ORDER BY id_aluno) AS Linha,
		   y.id_aluno, y.nome, y.sexo, y.nome_curso, y.data_inicio, y.data_termino, y.valor
	FROM(
		SELECT a.id_aluno, a.nome, a.sexo,
			   c.nome_curso,
			   t.data_inicio, t.data_termino,
			   axt.valor
		FROM AlunosxTurmas axt
			INNER JOIN Turmas t ON (t.id_turma = axt.id_turma)
			INNER JOIN Cursos c ON (c.id_curso = t.id_curso)
			RIGHT JOIN Alunos a ON (a.id_aluno = axt.id_aluno) --TROCANDO INNER POR RIGHT, TRÁS OS ALUNOS SEM CURSO TBM
	) y
) x;

SELECT * FROM tTemp;

---------------------------------------------------------

SELECT id_aluno, nome, 
	CASE sexo 
		WHEN 'M' THEN 'Masculino'
		WHEN 'F' THEN 'Feminino'
	ELSE 
		'Verifique' 
	END AS Sexo,
	nome_curso
FROM tTEMP;

--CHECAGEM DE SEXO

SELECT x.* FROM(
	SELECT id_aluno, nome, 
		CASE sexo 
			WHEN 'M' THEN 'Masculino'
			WHEN 'F' THEN 'Feminino'
		ELSE 
			'Verifique' 
		END AS Sexo,
		nome_curso
	FROM tTEMP
) x
WHERE sexo = 'Verifique';

---------------------------------------------------------

SELECT nome, nome_curso, valor, CONVERT(DATE, data_inicio) dt_inicio,
	CASE YEAR(data_inicio)
		WHEN 2020 THEN 'Ano Anteior'
		WHEN 2021 THEN 'Ano Atual'
		WHEN 2022 THEN 'Próximo Ano'
	ELSE
		'Ano Inválido'
	END analise_ano
FROM tTEMP;

---------------------------------------------------------

SELECT nome, data_nascimento, DATEDIFF(YEAR, data_nascimento, GETDATE()) AS Idade,
	CASE
		WHEN DATEDIFF(YEAR, data_nascimento, GETDATE()) < 18 THEN 'Menor de Idade'
		WHEN DATEDIFF(YEAR, data_nascimento, GETDATE()) >= 18 THEN 'Maior de Idade'
	END Status_idade
FROM Alunos;

---------------------------------------------------------

SELECT nome, nome_curso, sexo
FROM tTEMP
ORDER BY
	CASE sexo 
		WHEN 'F' THEN 'Feminino'
		WHEN 'M' THEN 'Masculino'
	ELSE
		'sexo' 
	END ASC;

DROP TABLE tTEMP;

---------------------------------------------------------

DECLARE @vCONTADOR1 INT = 1;

WHILE (@vCONTADOR1 < 10)
BEGIN
	PRINT 'Contador: ' + CONVERT(VARCHAR, @vCONTADOR1);
	SET @vCONTADOR1 += 1;
END

--SEM BEGIN ANINHADO

BEGIN TRANSACTION;

IF @@TRANCOUNT = 0
	SELECT nome, nome_curso, sexo
	FROM tTEMP
	WHERE sexo = 'M';

ROLLBACK TRANSACTION;

PRINT 'Executar dois ROLLBACKS geraria um erro de execução do segundo';

ROLLBACK TRANSACTION;

PRINT 'Transação defeita';

--COM BEGIN ANINHADO

BEGIN TRANSACTION

IF (@@TRANCOUNT = 0)
BEGIN
	SELECT nome, nome_curso, sexo FROM tTEMP WHERE sexo = 'M';
	ROLLBACK TRANSACTION;
	PRINT 'Executar dois ROLLBACKS gera um erro no segundo';
END

ROLLBACK TRANSACTION;

PRINT 'Transação desfeita';

DROP TABLE tTEMP;

--TRY..CATCH

--TABELA NÃO EXISTE

BEGIN TRY
	SELECT * FROM tempTable;
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS Número_erro,
		   ERROR_MESSAGE() AS Mensagem_erro;
END CATCH

--UTILIZANDO EM UMA PROCEDURE

CREATE PROCEDURE prc_Exemplo
AS
	SELECT * FROM tempTable;
GO

BEGIN TRY
	EXEC prc_Exemplo;
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS Numero_erro,
		   ERROR_MESSAGE() AS Mensagem_erro;
END CATCH;

--TRATAMENTO DE ERRO

BEGIN
	BEGIN TRY
		SELECT 1 / 0;
	END TRY
	BEGIN CATCH
		PRINT 'Erro número: ' + CONVERT(VARCHAR, ERROR_NUMBER());
		PRINT 'Erro mensagem: ' + ERROR_MESSAGE();
		PRINT 'Erro severity: ' + CONVERT(VARCHAR, ERROR_SEVERITY());
		PRINT 'Erro state: ' + CONVERT(VARCHAR, ERROR_STATE());
		PRINT 'Erro line: ' + CONVERT(VARCHAR, ERROR_LINE());
		PRINT 'Erro proc: ' + ERROR_PROCEDURE();
		--throw;
	END CATCH;
END;

--CREATE INDEX (ÍNDICE) (NÍVEL DBA, CONSULTE ELE) (OTIMIZAÇÃO)

SELECT t.id_aluno, a.data_cadastro, SUM(ISNULL(t.valor, 0)) AS valor
FROM tTemp t
	INNER JOIN Alunos a ON (a.id_aluno = t.id_aluno)
GROUP BY t.id_aluno, a.data_cadastro
	HAVING SUM(ISNULL(t.valor, 0)) > 0;

CREATE INDEX idx_tTemp ON tTemp(id_aluno);
CREATE INDEX idx_Alunos ON Alunos(data_cadastro);

DROP INDEX tTemp.idx_tTemp;
DROP INDEX Alunos.idx_Alunos;
DROP TABLE tTemp;

--TRIGGER (GATILHOS)

CREATE TABLE tbSaldos (
	PRODUTO			VARCHAR(10),
	SALDO_INICIAL	NUMERIC(10),
	SALDO_FINAL		NUMERIC(10),
	DATA_ULT_MOV	DATETIME
);

GO

INSERT INTO tbSaldos (PRODUTO, SALDO_INICIAL, SALDO_FINAL, DATA_ULT_MOV)
	VALUES ('Produto A', 0, 100, GETDATE());

GO

CREATE TABLE  tbVendas(
	ID_VENDA		INT,
	PRODUTO			VARCHAR(10),
	QUANTIDADE		INT,
	DATA			DATETIME
);

GO

CREATE SEQUENCE seq_tbVendas
	AS NUMERIC
	START WITH 1
	INCREMENT BY 1;

CREATE TABLE tbHistoricoVendas(
	PRODUTO			VARCHAR(10),
	QUANTIDADE		INT,
	DATA_VENDA		DATETIME
);

GO

CREATE TRIGGER trg_AjustaSaldo
ON tbVendas
FOR INSERT
AS 
BEGIN
	DECLARE @Quantidade		INT,
			@Data			DATETIME,
			@Produto		VARCHAR(10);

	SELECT @Data = DATA, @Quantidade = QUANTIDADE, @Produto = PRODUTO FROM INSERTED

	UPDATE tbSaldos
		SET SALDO_FINAL = SALDO_FINAL - @Quantidade,
		    DATA_ULT_MOV = @DATA
		WHERE PRODUTO = @Produto;

	INSERT INTO tbHistoricoVendas (PRODUTO, QUANTIDADE, DATA_VENDA)
		VALUES (@Produto, @Quantidade, @Data);
END;

GO

INSERT INTO tbVendas (ID_VENDA, PRODUTO, QUANTIDADE, DATA)
	VALUES (NEXT VALUE FOR seq_tbVendas, 'Produto A', 11, GETDATE());

SELECT * FROM tbSaldos;
SELECT * FROM tbVendas;
SELECT * FROM tbHistoricoVendas;

DROP TABLE tbSaldos;
DROP TABLE tbVendas;
DROP TABLE tbHistoricoVendas;

DROP SEQUENCE seq_tbVendas;
DROP TRIGGER trg_AjustaSaldo; --COMO tbVendas JÁ FOI APAGADA, A TRIGGER FOI JUNTO

---------------------------------------------------------

--PROCEDURES
--SEM RETORNO

CREATE PROCEDURE BuscaCurso
	@NomeCurso	VARCHAR(20)
AS
SET @NomeCurso = '%' + @NomeCurso + '&';
SELECT c.id_curso, c.nome_curso, a.nome, ISNULL(a.sexo, 'NI') AS sexo
	FROM Cursos c
		INNER JOIN Turmas t ON (t.id_turma = C.id_curso)
		INNER JOIN AlunosxTurmas alt ON (alt.id_turma = t.id_curso)
		INNER JOIN Alunos a ON (a.id_aluno = alt.id_aluno)
   WHERE nome_curso like @NomeCurso;

EXEC BuscaCurso 'React';
EXEC BuscaCurso 'C#';
EXEC BuscaCurso '%';

--COM RETORNO

CREATE PROCEDURE IncluirNovoCurso
	@NomeCurso		VARCHAR(100),
	@LoginCadastro	VARCHAR(100)
AS
BEGIN
	DECLARE @vIdCurso INT;

	SELECT @vIdCurso = MAX(id_curso) + 1 FROM Cursos;

	INSERT INTO Cursos (id_curso, nome_curso, data_cadastro, login_cadastro)
		VALUES (@vIdCurso, @NomeCurso, GETDATE(), @LoginCadastro);

	SELECT @vIdCurso = id_curso FROM Cursos WHERE id_curso = @vIdCurso
	SELECT @vIdCurso AS retorno;
END;
GO

EXEC IncluirNovoCurso 'NodeJS', 'FABIANO1';

SELECT * FROM Cursos;

DELETE FROM Cursos WHERE id_curso IN(3, 4);

--COM VALIDAÇÃO

CREATE PROCEDURE IncluirNovoCursoComValidacao
	@NomeCurso		VARCHAR(100),
	@LoginCadastro	VARCHAR(100)
AS
BEGIN
	DECLARE @vIdCurso	  INT;
	DECLARE @vExisteCurso INT;

	SELECT @vExisteCurso = id_curso FROM Cursos WHERE nome_curso = @NomeCurso;

	IF (@vExisteCurso > 0)
		BEGIN
			SELECT 'O curso Já existe! Gravação não realizada' AS retorno
		END
	ELSE
		BEGIN
			SELECT @vIdCurso = MAX(id_curso) + 1 FROM Cursos;

			INSERT INTO Cursos (id_curso, nome_curso, data_cadastro, login_cadastro)
				VALUES (@vIdCurso, @NomeCurso, GETDATE(), @LoginCadastro);

			SELECT @vIdCurso = id_curso FROM Cursos WHERE id_curso = @vIdCurso;
			SELECT @vIdCurso AS retorno;
		END
END;

GO

EXEC IncluirNovoCursoComValidacao '.Net Core', 'FABIANO1';

SELECT * FROM Cursos;