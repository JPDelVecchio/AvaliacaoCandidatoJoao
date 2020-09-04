 
/***************** TABLE VEICULO**************/
/* CREATE */
CREATE PROC INCLUIR_VEICULO
		@PLACA VARCHAR(7),
		@MARCA INT,
		@MODELO INT,
		@ANOMODELO INT,
		@ANOFABRICACAO INT

AS 
INSERT INTO VEICULO (PLACA, ID_MARCA, ID_MODELO, ANOFABRICACAO, ANOMODELO) VALUES (@PLACA, @MARCA, @MODELO, @ANOMODELO, @ANOFABRICACAO);

GO

/* UPDATE */ 
/* REALIZAR TRATAMENTOS DE ALTERA��ES DE PLACA COM OLD E NEW COM AS FUN��ES DO T-SQL*/
CREATE PROC ALTERAR_VEICULO 
		@PLACA_OLD VARCHAR(7),
		@PLACA_NEW VARCHAR(7),
		@MARCA INT,
		@MODELO INT,
		@ANOMODELO INT,
		@ANOFABRICACAO INT
AS 
UPDATE VEICULO SET PLACA = @PLACA_NEW, ID_MARCA = @MARCA, ID_MODELO = @MODELO, ANOFABRICACAO = @ANOFABRICACAO,
		 ANOMODELO = @ANOMODELO WHERE PLACA = @PLACA_OLD;
GO
/*DELETE*/
CREATE PROC EXCLUIR_VEICULO
		@PLACA VARCHAR(7)
AS
DELETE FROM VEICULO WHERE PLACA = @PLACA;
GO
/*READ*/
CREATE PROC LEITURA_VEICULO_PLACA
	@PLACA VARCHAR(7) 
AS
SELECT * FROM VEICULO WHERE PLACA LIKE '%' + @PLACA + '%'
GO 

/*CONSULTAS */
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
 
/* TESTE PROC VEICULO */ 
EXEC INCLUIR_VEICULO 'GTI-4721', 1,7, 2019, 2020 

EXEC ALTERAR_VEICULO 'GTI-4721', 'GTI-4721', 1, 7, 2020, 2020

EXEC LEITURA_VEICULO_PLACA ''
EXEC LEITURA_VEICULO_PLACA 'I'

EXEC EXCLUIR_VEICULO 'GTI-4721'
