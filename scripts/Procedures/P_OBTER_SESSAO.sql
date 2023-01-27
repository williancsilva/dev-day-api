ALTER PROCEDURE P_OBTER_SESSAO @DayId VARCHAR(255)
AS
BEGIN
SELECT 
	S.id
	,isAuthenticated
	,Login
	,Expiracao
	,STRING_AGG(Features, ',') Features
	,Roles
	,Senha
FROM Sessao S
JOIN Permissoes P ON P.SessaoId = S.Id
JOIN Usuarios U ON U.email = s.login
WHERE S.ID = @DayId
GROUP BY 
	 s.id
	,isAuthenticated
	,Login
	,Expiracao
	,Roles
	,Senha

END
GO



