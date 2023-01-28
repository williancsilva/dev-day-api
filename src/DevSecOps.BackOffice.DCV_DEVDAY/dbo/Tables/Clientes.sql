CREATE TABLE [dbo].[Clientes] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [documento] VARCHAR (255) NOT NULL,
    [nome]      VARCHAR (255) NOT NULL,
    [endereco]  VARCHAR (255) NOT NULL,
    [telefone]  VARCHAR (255) NOT NULL,
    [ativo]     BIT           NOT NULL,
    [excluido]  BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

