CREATE PROCEDURE P_VERIFICAR_USUARIO_CLIENTE (@documento VARCHAR(11), @DayId INT, @result BIT OUTPUT)
AS
BEGIN
    DECLARE @codUsuario INT
	DECLARE @codCliente INT

    SELECT @codUsuario = u.Id FROM Sessao s 
	INNER JOIN Usuarios u on s.Login = u.email
	WHERE s.Id = @DayId
    
   
   select @codCliente = id from Clientes where documento = @documento
   
   
   SELECT @result = CASE WHEN EXISTS (SELECT * FROM UsuariosClientes WHERE id_usuario = @codUsuario AND id_cliente = @codCliente) THEN 1 ELSE 0 END

    RETURN @result
END