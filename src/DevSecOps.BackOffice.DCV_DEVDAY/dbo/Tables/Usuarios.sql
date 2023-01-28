CREATE TABLE [dbo].[Usuarios] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [nome]  VARCHAR (255) NOT NULL,
    [email] VARCHAR (255) NOT NULL,
    [senha] VARCHAR (255) NOT NULL,
    [tipo]  VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

