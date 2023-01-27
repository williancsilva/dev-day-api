ALTER PROCEDURE P_OBTER_CLIENTE @documento VARCHAR(255)
AS
BEGIN
SELECT id, documento, nome, endereco, telefone, ativo, excluido FROM Clientes WHERE documento = @documento AND EXCLUIDO = 0;
END
GO