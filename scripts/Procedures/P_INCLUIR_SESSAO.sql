alter PROCEDURE P_INCLUIR_SESSAO @login VARCHAR(255)
AS
BEGIN
    DECLARE @SessionId INT;
    INSERT INTO Sessao (IsAuthenticated, Login, Expiracao) VALUES (0, @login, dateadd(minute, 30, getdate()))
    
	SET @SessionId = @@IDENTITY

	SELECT R.NOME Role, F.NOME Feature 
	INTO #FEATURES_ROLES
	FROM USUARIOS U
	JOIN USUARIOSROLES UR ON UR.ID_USUARIO = U.ID
	JOIN ROLES R ON R.ID = UR.ID_ROLE
	JOIN ROLESFEATURES RF ON RF.ID_ROLE = R.ID
	JOIN FEATURES F ON F.ID = ID_FEATURE
	WHERE email = @login

    INSERT INTO Permissoes (SessaoId, Features, Roles)
    SELECT @SessionId, Feature, Role FROM #FEATURES_ROLES RF

	SELECT @SessionId DayId
END
GO