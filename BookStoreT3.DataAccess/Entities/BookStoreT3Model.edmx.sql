
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/25/2017 01:09:17
-- Generated from EDMX file: D:\Projects\Logos\BookStoreT3\BookStoreT3.DataAccess\Entities\BookStoreT3Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookStoreT3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TypeOfBookBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_TypeOfBookBook];
GO
IF OBJECT_ID(N'[dbo].[FK_ExtraInfoBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExtraInfoes] DROP CONSTRAINT [FK_ExtraInfoBook];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderBook_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBook] DROP CONSTRAINT [FK_OrderBook_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderBook_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBook] DROP CONSTRAINT [FK_OrderBook_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_UserOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[TypeOfBooks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeOfBooks];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[ExtraInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExtraInfoes];
GO
IF OBJECT_ID(N'[dbo].[OrderBook]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBook];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Value] float  NOT NULL,
    [TypeOfBookId] int  NOT NULL
);
GO

-- Creating table 'TypeOfBooks'
CREATE TABLE [dbo].[TypeOfBooks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotalValue] float  NOT NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ExtraInfoes'
CREATE TABLE [dbo].[ExtraInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Isbn10] nvarchar(max)  NULL,
    [Isbn13] nvarchar(max)  NULL,
    [Year] int  NULL,
    [Book_Id] int  NOT NULL
);
GO

-- Creating table 'OrderBook'
CREATE TABLE [dbo].[OrderBook] (
    [Orders_Id] int  NOT NULL,
    [Books_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeOfBooks'
ALTER TABLE [dbo].[TypeOfBooks]
ADD CONSTRAINT [PK_TypeOfBooks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExtraInfoes'
ALTER TABLE [dbo].[ExtraInfoes]
ADD CONSTRAINT [PK_ExtraInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Orders_Id], [Books_Id] in table 'OrderBook'
ALTER TABLE [dbo].[OrderBook]
ADD CONSTRAINT [PK_OrderBook]
    PRIMARY KEY CLUSTERED ([Orders_Id], [Books_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeOfBookId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_TypeOfBookBook]
    FOREIGN KEY ([TypeOfBookId])
    REFERENCES [dbo].[TypeOfBooks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeOfBookBook'
CREATE INDEX [IX_FK_TypeOfBookBook]
ON [dbo].[Books]
    ([TypeOfBookId]);
GO

-- Creating foreign key on [Book_Id] in table 'ExtraInfoes'
ALTER TABLE [dbo].[ExtraInfoes]
ADD CONSTRAINT [FK_ExtraInfoBook]
    FOREIGN KEY ([Book_Id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExtraInfoBook'
CREATE INDEX [IX_FK_ExtraInfoBook]
ON [dbo].[ExtraInfoes]
    ([Book_Id]);
GO

-- Creating foreign key on [Orders_Id] in table 'OrderBook'
ALTER TABLE [dbo].[OrderBook]
ADD CONSTRAINT [FK_OrderBook_Order]
    FOREIGN KEY ([Orders_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Books_Id] in table 'OrderBook'
ALTER TABLE [dbo].[OrderBook]
ADD CONSTRAINT [FK_OrderBook_Book]
    FOREIGN KEY ([Books_Id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderBook_Book'
CREATE INDEX [IX_FK_OrderBook_Book]
ON [dbo].[OrderBook]
    ([Books_Id]);
GO

-- Creating foreign key on [UserId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[Orders]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------