CREATE TABLE [dbo].[RolesFeatures] (
    [id_role]    INT NOT NULL,
    [id_feature] INT NOT NULL,
    FOREIGN KEY ([id_feature]) REFERENCES [dbo].[Features] ([id]),
    FOREIGN KEY ([id_role]) REFERENCES [dbo].[Roles] ([id])
);

