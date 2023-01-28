CREATE TABLE [dbo].[Roles] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [nome]      VARCHAR (255) NOT NULL,
    [descricao] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

