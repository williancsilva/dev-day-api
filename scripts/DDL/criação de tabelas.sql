
USE DCV_DevDay;
GO

-- Criação da tabela Usuários
CREATE TABLE Usuarios (
    id INT PRIMARY KEY IDENTITY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    tipo VARCHAR(255) NOT NULL
);
GO

-- Criação da tabela Clientes
CREATE TABLE Clientes (
    id INT PRIMARY KEY IDENTITY,
	documento VARCHAR(255) NOT NULL,
    nome VARCHAR(255) NOT NULL,
    endereco VARCHAR(255) NOT NULL,
    telefone VARCHAR(255) NOT NULL,
    ativo BIT NOT NULL,
    excluido BIT NOT NULL
);
GO

-- Criação da tabela de associação de usuários-clientes
CREATE TABLE UsuariosClientes (
    id_usuario INT NOT NULL,
    id_cliente INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id)
);
GO

-- Criação da tabela Features
CREATE TABLE Features (
    id INT PRIMARY KEY IDENTITY,
    nome VARCHAR(255) NOT NULL,
    descricao VARCHAR(255) NOT NULL
);
GO

-- Criação da tabela Roles
CREATE TABLE Roles (
    id INT PRIMARY KEY IDENTITY,
    nome VARCHAR(255) NOT NULL,
    descricao VARCHAR(255) NOT NULL
);
GO

-- Criação da tabela de associação de roles-features
CREATE TABLE RolesFeatures (
    id_role INT NOT NULL,
    id_feature INT NOT NULL,
    FOREIGN KEY (id_role) REFERENCES Roles(id),
    FOREIGN KEY (id_feature) REFERENCES Features(id)
);
GO

-- Criação da tabela de associação de usuários-roles
CREATE TABLE UsuariosRoles (
    id_usuario INT NOT NULL,
    id_role INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id),
    FOREIGN KEY (id_role) REFERENCES Roles(id)
);
GO

-- Criação da tabela Acessos
CREATE TABLE Acessos (
    id INT PRIMARY KEY IDENTITY,
    id_usuario INT NOT NULL,
    data_hora DATETIME NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id)
);
GO

CREATE TABLE Sessao (
    Id INT PRIMARY KEY IDENTITY,
    IsAuthenticated BIT NOT NULL,
    Login VARCHAR(255) NOT NULL,
	Expiracao DATETIME NOT NULL
);

CREATE TABLE Permissoes (
    SessaoId INT,
    Features VARCHAR(255),
    Roles VARCHAR(255),
    FOREIGN KEY (SessaoId) REFERENCES Sessao(Id)
);