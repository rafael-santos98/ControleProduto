-- ==========================================================================================
/*
	Sistema:  		Controle de Produtos
	Versão:			1.0
    Data:			29/08/2015
    Banco de Dados:	Produto
    Descrição:		Criação da base e tabelas do sistema.
*/
-- ==========================================================================================

DROP DATABASE IF EXISTS Produto;
CREATE DATABASE Produto;
USE Produto;

CREATE TABLE TBPRODUTO(
	NCDPRODUTO 	INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    CDSPRODUTO 	VARCHAR(100),
    NVLSALDO 	FLOAT,
    BIDATIVO 	BIT 
);

CREATE TABLE TBPRODUTOMOVIMENTO(
	NCDPRODUTOMOVIMENTO INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    NCDPRODUTO			INT NOT NULL,
    NVLQUANTIDADE		FLOAT,
	CDSOBSERVACAO		VARCHAR(300),
    CDSTIPOMOVIMENTO	CHAR(1),
    DTMOVIMENTO			DATETIME,
	FOREIGN KEY (NCDPRODUTO) REFERENCES TBPRODUTO (NCDPRODUTO)
);
