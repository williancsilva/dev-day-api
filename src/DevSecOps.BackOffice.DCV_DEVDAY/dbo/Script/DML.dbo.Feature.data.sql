USE [DCV_DEVDAY] 
GO 

SET IDENTITY_INSERT [dbo].[Features] ON
INSERT INTO [dbo].[Features] ([id], [nome], [descricao]) VALUES (4, N'Bloquear', N'Permite que o usuário inativar clientes')
SET IDENTITY_INSERT [dbo].[Features] OFF