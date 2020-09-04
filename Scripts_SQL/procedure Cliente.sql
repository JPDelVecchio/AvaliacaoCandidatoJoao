 
/***************** TABLE CLIENTE**************/
/* CREATE */
CREATE PROC INCLUIR_CLIENTE
		@NOME VARCHAR(240),
		@CPF VARCHAR(11),
		@TELEFONE VARCHAR(16),
		@ENDERECO VARCHAR(250)

AS 
INSERT INTO CLIENTE (NOME, CPF, TELEFONE, ENDERECO) VALUES (@NOME, @CPF, @TELEFONE, @ENDERECO);
GO

/* UPDATE */ 
/* REALIZAR TRATAMENTOS DE ALTERA��ES DE PLACA COM OLD E NEW COM AS FUN��ES DO T-SQL*/
CREATE PROC ALTERAR_CLIENTE 
		@CPF_OLD VARCHAR(11),
		@CPF_NEW VARCHAR(11),
		@NOME VARCHAR(240),
		@TELEFONE VARCHAR(16),
		@ENDERECO VARCHAR(250)
AS 
UPDATE CLIENTE SET NOME = @NOME, CPF = @CPF_NEW, TELEFONE = @TELEFONE, ENDERECO = @ENDERECO
	WHERE CPF = @CPF_OLD;
GO

/*DELETE*/
CREATE PROC EXCLUIR_CLIENTE
		@CPF VARCHAR(11)
AS
DELETE FROM CLIENTE WHERE CPF = @CPF;
GO

/*READ*/
CREATE PROC LEITURA_CLIENTE
	@CPF VARCHAR(11),
	@NOME VARCHAR(240) 
AS
SELECT * FROM CLIENTE WHERE (CPF LIKE @CPF + '%' OR NOME LIKE  '%' + @NOME + '%')
GO 

/*CONSULTAS */
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM CLIENTE
 
/* TESTE PROC VEICULO */ 
EXEC INCLUIR_CLIENTE 'JOAO LIMA', 'XXXXXXXXXXX', '(11) 9 5215-4162', 'BP'

EXEC ALTERAR_CLIENTE 'XXXXXXXXXXX', '2271XXXXXXX', 'JOAO PAULO DEL VECCHIO DE LIMA', '(11) - XXX', 'ATIBAIA'

EXEC LEITURA_CLIENTE '2271',NULL
EXEC LEITURA_CLIENTE NULL, 'JOAO'
EXEC LEITURA_CLIENTE 'XX',NULL
EXEC LEITURA_CLIENTE NULL,'LIMA'

EXEC EXCLUIR_CLIENTE '2271XXXXXXX'