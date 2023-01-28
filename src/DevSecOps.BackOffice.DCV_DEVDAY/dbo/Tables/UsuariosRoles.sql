CREATE TABLE [dbo].[UsuariosRoles] (
    [id_usuario] INT NOT NULL,
    [id_role]    INT NOT NULL,
    FOREIGN KEY ([id_role]) REFERENCES [dbo].[Roles] ([id]),
    FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios] ([id])
);

