﻿CREATE PROCEDURE P_ATIVAR_CLIENTE @documento VARCHAR(255)
AS
BEGIN
UPDATE CLIENTES SET ativo = 1, excluido = 0 WHERE documento = @documento 
END
