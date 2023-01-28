CREATE TABLE [dbo].[Sessao] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [IsAuthenticated] BIT           NOT NULL,
    [Login]           VARCHAR (255) NOT NULL,
    [Expiracao]       DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

