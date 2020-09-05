/*
PROCEDURES DAS CRUDs
*/
/***************** TABLE MARCA**************/
/* CREATE */
CREATE PROC INCLUIR_MARCA 
		@NOME VARCHAR(150),
		@DESCRICAO VARCHAR(250)

AS 
INSERT INTO MARCA (NOME, DESCRICAO) VALUES (@NOME, @DESCRICAO);

GO
/* UPDATE */ 
CREATE PROC ALTERAR_MARCA 
			@ID INT,
			@NOME VARCHAR(150),
			@DESCRICAO VARCHAR(250)
AS 
UPDATE MARCA SET NOME = @NOME, DESCRICAO = @DESCRICAO WHERE ID = @ID;
GO
/*DELETE*/
CREATE PROC EXCLUIR_MARCA
		@ID INT
AS
DELETE FROM MARCA WHERE ID = @ID;
GO
/*READ*/
CREATE PROC LEITURA_MARCA
	@ID INT
AS
SELECT * FROM MARCA WHERE ID = @ID
GO
  
/*CONSULTAS */
SELECT * FROM MARCA
SELECT * FROM MODELO
 
/* TESTE PROC MARCA */
EXEC INCLUIR_MARCA 'HONDA', NULL;

EXEC INCLUIR_MARCA 'HONDA1', 'TESTE DESCRIPTION COM UNIQUE';

EXEC ALTERAR_MARCA 1,'HONDA' , 'INCLUS�O DE DESCRICAO'; 

EXEC EXCLUIR_MARCA 'HONDA1'

EXEC LEITURA_MARCA 'A'

 

 