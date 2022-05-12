use DCV_CONTROL
go


BEGIN TRAN

BEGIN TRY

	DECLARE @CodSistema INT = 353
	DECLARE @consultar INT
    DECLARE @bloquear  INT

	IF NOT EXISTS(SELECT 1 FROM Sistema WHERE CodSistema = @CodSistema)
	BEGIN 
		
		INSERT INTO dbo.Sistema(CodSistema, Nome, Descricao, SistemaHabilitado)
		VALUES
			(@CodSistema, 'Daycoval - BackOffice backoffice', 'Sistema de back office para backoffice atender como suporte dayconnect', 1)

		INSERT INTO dbo.HorarioSistema(CodSistema, HorarioAbertura, HorarioFechamento, CodDiaSemana, SistemaHabilitado)
		VALUES
			(353, '00:00:00.0000000', '00:00:00.0000000', 1, 1)
		,	(353, '00:00:00.0000000', '00:00:00.0000000', 2, 1)
		,	(353, '00:00:00.0000000', '00:00:00.0000000', 3, 1)
		,	(353, '00:00:00.0000000', '00:00:00.0000000', 4, 1)
		,	(353, '00:00:00.0000000', '00:00:00.0000000', 5, 1)
		,	(353, '00:00:00.0000000', '00:00:00.0000000', 6, 1)
		,	(353, '00:00:00.0000000', '00:00:00.0000000', 7, 1)

	END


    DECLARE @RoleOperadores  INT = (SELECT CodRole FROM Role WHERE Nome = 'Operadores' AND CodSistema= @CodSistema)

    IF @RoleOperadores IS NULL BEGIN
		INSERT INTO Role(CodSistema, Nome, Descricao, RoleHabilitada)
						VALUES	(@CodSistema,'Operadores', 'Role para operadores do backoffice backoffice', 1)
		SET @RoleOperadores = SCOPE_IDENTITY()
	END

    DELETE RoleFeature WHERE CodRole IN (SELECT CodRole FROM Role WHERE CodSistema = @CodSistema AND CodRole = @RoleOperadores)

    SET @consultar = (SELECT CodFeature FROM Feature WHERE Nome = 'consultar' AND CodSistema= @CodSistema)
    SET @bloquear = (SELECT CodFeature FROM Feature WHERE Nome = 'bloquear' AND CodSistema= @CodSistema) 
    
	IF @consultar IS NULL BEGIN
		INSERT INTO Feature (CodSistema,Nome,Descricao,FeatureHabilitada) VALUES
		(@CodSistema, 'consultar', 'Permissoes para consultar clientes', 1)
	END

	IF @bloquear IS NULL BEGIN
		INSERT INTO Feature (CodSistema,Nome,Descricao,FeatureHabilitada) VALUES
		(@CodSistema, 'bloquear', 'Permissoes para bloquear clientes', 1)
	END

    INSERT INTO RoleFeature(CodRole, CodFeature)
		VALUES	(@RoleOperadores, @consultar),
                (@RoleOperadores, @bloquear)

	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
    RAISERROR('ERRO AO EXECUTAR DML',16,1)
END CATCH


