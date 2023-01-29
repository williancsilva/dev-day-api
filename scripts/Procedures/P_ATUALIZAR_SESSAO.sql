ALTER PROCEDURE P_ATUALIZAR_SESSAO @DayId INT, @isAuthenticated BIT
AS
BEGIN
UPDATE SESSAO SET isAuthenticated = @isAuthenticated WHERE id = @DayId
END