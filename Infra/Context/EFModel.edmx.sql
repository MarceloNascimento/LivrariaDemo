
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/11/2018 01:11:08
-- Generated from EDMX file: C:\Users\marce\source\Workspaces\HoseMaquinas\Infra\Context\EFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HOSEMAQ];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Documento__tipoI__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documentos] DROP CONSTRAINT [FK__Documento__tipoI__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK_cliente_prod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Livros] DROP CONSTRAINT [FK_cliente_prod];
GO
IF OBJECT_ID(N'[dbo].[FK_cliente_usr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_cliente_usr];
GO
IF OBJECT_ID(N'[dbo].[fk_docs_Livro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documentos] DROP CONSTRAINT [fk_docs_Livro];
GO
IF OBJECT_ID(N'[dbo].[FK_perfil_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_perfil_users];
GO
IF OBJECT_ID(N'[dbo].[FK_usr_prod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Livros] DROP CONSTRAINT [FK_usr_prod];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Documentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documentos];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[Livros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Livros];
GO
IF OBJECT_ID(N'[dbo].[Tipo_docs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipo_docs];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(200)  NULL,
    [tipo] nvarchar(50)  NULL,
    [CNPJ] nvarchar(18)  NULL,
    [telefone] nvarchar(50)  NULL,
    [Responsavel] nvarchar(18)  NULL
);
GO

-- Creating table 'Perfils'
CREATE TABLE [dbo].[Perfils] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(200)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(200)  NULL,
    [nickName] nvarchar(50)  NULL,
    [perfil_id] int  NULL,
    [senha] nvarchar(50)  NULL,
    [cliente_cod] int  NULL
);
GO

-- Creating table 'Documentos'
CREATE TABLE [dbo].[Documentos] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(255)  NOT NULL,
    [caminho] varchar(max)  NOT NULL,
    [tipoID] int  NULL,
    [numero] int  NULL,
    [LivroID] int  NOT NULL
);
GO

-- Creating table 'Livros'
CREATE TABLE [dbo].[Livros] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [certific_cod] nvarchar(200)  NULL,
    [solicitante] nvarchar(200)  NULL,
    [testador] nvarchar(200)  NULL,
    [vendedor] nvarchar(200)  NULL,
    [montador] nvarchar(200)  NULL,
    [aprovador] nvarchar(200)  NULL,
    [dt_validade] datetime  NOT NULL,
    [n_Lote] nvarchar(14)  NULL,
    [nm_embarc] nvarchar(200)  NULL,
    [dt_inseriu_db] datetime  NULL,
    [cliente_id] int  NULL,
    [usr_inseriu_cod] int  NOT NULL,
    [nome] nvarchar(300)  NULL,
    [tag] nvarchar(255)  NULL,
    [observacao] varchar(max)  NULL
);
GO

-- Creating table 'Tipo_docs'
CREATE TABLE [dbo].[Tipo_docs] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [codigo] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Perfils'
ALTER TABLE [dbo].[Perfils]
ADD CONSTRAINT [PK_Perfils]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Documentos'
ALTER TABLE [dbo].[Documentos]
ADD CONSTRAINT [PK_Documentos]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [PK_Livros]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Tipo_docs'
ALTER TABLE [dbo].[Tipo_docs]
ADD CONSTRAINT [PK_Tipo_docs]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [cliente_cod] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_cliente_usr]
    FOREIGN KEY ([cliente_cod])
    REFERENCES [dbo].[Clientes]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cliente_usr'
CREATE INDEX [IX_FK_cliente_usr]
ON [dbo].[Usuarios]
    ([cliente_cod]);
GO

-- Creating foreign key on [perfil_id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_perfil_users]
    FOREIGN KEY ([perfil_id])
    REFERENCES [dbo].[Perfils]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_perfil_users'
CREATE INDEX [IX_FK_perfil_users]
ON [dbo].[Usuarios]
    ([perfil_id]);
GO

-- Creating foreign key on [cliente_id] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [FK_cliente_prod]
    FOREIGN KEY ([cliente_id])
    REFERENCES [dbo].[Clientes]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cliente_prod'
CREATE INDEX [IX_FK_cliente_prod]
ON [dbo].[Livros]
    ([cliente_id]);
GO

-- Creating foreign key on [tipoID] in table 'Documentos'
ALTER TABLE [dbo].[Documentos]
ADD CONSTRAINT [FK__Documento__tipoI__4CA06362]
    FOREIGN KEY ([tipoID])
    REFERENCES [dbo].[Tipo_docs]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Documento__tipoI__4CA06362'
CREATE INDEX [IX_FK__Documento__tipoI__4CA06362]
ON [dbo].[Documentos]
    ([tipoID]);
GO

-- Creating foreign key on [LivroID] in table 'Documentos'
ALTER TABLE [dbo].[Documentos]
ADD CONSTRAINT [fk_docs_Livro]
    FOREIGN KEY ([LivroID])
    REFERENCES [dbo].[Livros]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_docs_Livro'
CREATE INDEX [IX_fk_docs_Livro]
ON [dbo].[Documentos]
    ([LivroID]);
GO

-- Creating foreign key on [usr_inseriu_cod] in table 'Livros'
ALTER TABLE [dbo].[Livros]
ADD CONSTRAINT [FK_usr_prod]
    FOREIGN KEY ([usr_inseriu_cod])
    REFERENCES [dbo].[Usuarios]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usr_prod'
CREATE INDEX [IX_FK_usr_prod]
ON [dbo].[Livros]
    ([usr_inseriu_cod]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------