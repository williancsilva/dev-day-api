CREATE TABLE [dbo].[Permissoes] (
    [SessaoId] INT           NULL,
    [Features] VARCHAR (255) NULL,
    [Roles]    VARCHAR (255) NULL,
    FOREIGN KEY ([SessaoId]) REFERENCES [dbo].[Sessao] ([Id])
);

