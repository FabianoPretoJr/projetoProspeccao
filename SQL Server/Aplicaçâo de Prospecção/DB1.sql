CREATE DATABASE DBProspeccao;

GO

USE DBProspeccao;

CREATE TABLE StatusAnalise(
	id_status		INT	PRIMARY KEY IDENTITY	NOT NULL,
	nome_status		VARCHAR(40) UNIQUE			NOT NULL,
	ativo			BIT							NOT NULL
);

CREATE TABLE Usuario(
	id_usuario		INT	PRIMARY KEY IDENTITY	NOT NULL,
	login_usuario	VARCHAR(45)	UNIQUE			NOT NULL,
	senha			VARCHAR(15)					NOT NULL,
	ativo			BIT							NOT NULL
);

CREATE TABLE Perfil(
	id_perfil		INT PRIMARY KEY	IDENTITY	NOT NULL,
	nome_perfil		VARCHAR(25)	UNIQUE			NOT NULL,
	ativo			BIT							NOT NULL
);

CREATE TABLE Acesso(
	id_usuario		INT							NOT NULL,
	id_perfil		INT							NOT NULL,
	CONSTRAINT fk_Usuario_Acesso FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario),
	CONSTRAINT fk_Perfil_Acesso  FOREIGN KEY (id_perfil)  REFERENCES Perfil  (id_perfil)
);

CREATE TABLE Cliente(
	id_cliente		INT PRIMARY KEY	IDENTITY	NOT NULL,
	nome			VARCHAR(45)					NOT NULL,
	cpf				CHAR(11)	UNIQUE			NOT NULL,
	rg				CHAR(9)						NOT NULL,
	data_nascimento	DATE						NOT NULL,
	email			VARCHAR(30)	UNIQUE			NOT NULL,
	id_status		INT							NOT NULL
	CONSTRAINT fk_StatusAnalise_Cliente	FOREIGN KEY (id_status) REFERENCES StatusAnalise (id_status)
);

CREATE TABLE Pais(
	id_pais			INT PRIMARY KEY	IDENTITY	NOT NULL,
	nome_pais		VARCHAR(25)	UNIQUE			NOT NULL,
	ativo			BIT							NOT NULL
);

CREATE TABLE Estado(
	id_estado		INT PRIMARY KEY	IDENTITY	NOT NULL,
	nome_estado		VARCHAR(25)	UNIQUE			NOT NULL,
	id_pais			INT							NOT NULL,
	ativo			BIT							NOT NULL,
	CONSTRAINT fk_Pais_Estado FOREIGN KEY (id_pais) REFERENCES Pais (id_pais)
);

CREATE TABLE Cidade(
	id_cidade		INT PRIMARY KEY	IDENTITY	NOT NULL,
	nome_cidade		VARCHAR(25)					NOT NULL,
	id_estado		INT							NOT NULL,
	ativo			BIT							NOT NULL,
	CONSTRAINT fk_Estado_Cidade FOREIGN KEY (id_estado) REFERENCES Estado (id_estado)
);

CREATE TABLE Endereco(
	id_endereco		INT PRIMARY	KEY	IDENTITY	NOT NULL,
	cep				CHAR(8),
	rua				VARCHAR(20)					NOT NULL,
	numero			VARCHAR(6)					NOT NULL,
	complemento		VARCHAR(15),
	bairro			VARCHAR(20)					NOT NULL,
	id_cliente		INT							NOT NULL,
	id_cidade		INT							NOT NULL,
	CONSTRAINT fk_Cliente_Endereco FOREIGN KEY (id_cliente) REFERENCES Cliente (id_cliente),
	CONSTRAINT fk_Cidade_Endereco FOREIGN KEY (id_cidade) REFERENCES Cidade (id_cidade)
);

CREATE TABLE Telefone(
	id_telefone		INT	PRIMARY KEY	IDENTITY	NOT NULL,
	numero_telefone	VARCHAR(9)					NOT NULL,
	id_cliente		INT							NOT NULL,
	CONSTRAINT fk_Cliente_Telefone FOREIGN KEY (id_cliente) REFERENCES Cliente (id_cliente)
);

CREATE TABLE Analise(
	id_analise		INT PRIMARY KEY	IDENTITY	NOT NULL,
	id_status		INT							NOT NULL,
	id_cliente		INT							NOT NULL,
	id_usuario		INT							NOT NULL,
	data_hora		DATETIME					NOT NULL
	CONSTRAINT fk_StatusAnalise_Analise FOREIGN KEY (id_status) REFERENCES StatusAnalise (id_status),
	CONSTRAINT fk_Cliente_Analise FOREIGN KEY (id_cliente) REFERENCES Cliente (id_cliente),
	CONSTRAINT fk_Usuario_Analise FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario)
);

SELECT * FROM Usuario;
SELECT * FROM Acesso;
SELECT * FROM Perfil;
SELECT * FROM Cliente;
SELECT * FROM Endereco;
SELECT * FROM Telefone;
SELECT * FROM StatusAnalise;
SELECT * FROM Analise;
SELECT * FROM Pais;
SELECT * FROM Estado;
SELECT * FROM Cidade;

SELECT * FROM PaisEstadoCidade;

/*
DROP TABLE Acesso;
DROP TABLE Perfil;
DROP TABLE Endereco;
DROP TABLE Telefone;
DROP TABLE Analise;
DROP TABLE Usuario;
DROP TABLE Cliente;
DROP TABLE Cidade;
DROP TABLE Estado;
DROP TABLE Pais;
DROP TABLE StatusAnalise;
*/