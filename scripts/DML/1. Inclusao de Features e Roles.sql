USE DCV_DEVDAY

INSERT INTO ROLES VALUES ('Administrador', 'Perfil de acesso administrador')
INSERT INTO ROLES VALUES ('Operador', 'Perfil de acesso operador')

INSERT INTO FEATURES VALUES ('Consulta', 'Permite que o usu�rio fa�a consulta de clientes')
INSERT INTO FEATURES VALUES ('Excluir', 'Permite que o usu�rio exclua clientes')
INSERT INTO FEATURES VALUES ('Ativar', 'Permite que o usu�rio ative clientes')

INSERT INTO ROLESFEATURES VALUES (1, 1)
INSERT INTO ROLESFEATURES VALUES (1, 2)
INSERT INTO ROLESFEATURES VALUES (1, 3)

INSERT INTO ROLESFEATURES VALUES (2, 1)

INSERT INTO USUARIOS VALUES ('Jo�o da Silva', 'joao.silva@banco.com.br', 'teste123@', 'Gerente')
INSERT INTO USUARIOS VALUES ('Maria Alice', 'maria.alice@banco.com.br', 'teste123@', 'Gerente')
INSERT INTO USUARIOS VALUES ('Roberto Alberto', 'roberto.alberto@banco.com.br', 'teste123@', 'Operador')

INSERT INTO USUARIOSROLES VALUES (1, 1)
INSERT INTO USUARIOSROLES VALUES (3, 1)
INSERT INTO USUARIOSROLES VALUES (4, 2)
