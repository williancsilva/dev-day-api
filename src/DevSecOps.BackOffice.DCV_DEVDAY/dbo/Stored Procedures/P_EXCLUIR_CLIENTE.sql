﻿CREATE PROCEDURE P_EXCLUIR_CLIENTE @documento VARCHAR(255)
AS
BEGIN
UPDATE CLIENTES SET EXCLUIDO = 1 WHERE documento = @documento 
END