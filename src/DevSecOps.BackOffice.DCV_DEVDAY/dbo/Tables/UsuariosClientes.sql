CREATE TABLE [dbo].[UsuariosClientes] (
    [id_usuario] INT NOT NULL,
    [id_cliente] INT NOT NULL,
    FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[Clientes] ([id]),
    FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios] ([id])
);

