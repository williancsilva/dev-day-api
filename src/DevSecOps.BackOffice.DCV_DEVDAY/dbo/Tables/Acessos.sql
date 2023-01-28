CREATE TABLE [dbo].[Acessos] (
    [id]         INT      IDENTITY (1, 1) NOT NULL,
    [id_usuario] INT      NOT NULL,
    [data_hora]  DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuarios] ([id])
);

