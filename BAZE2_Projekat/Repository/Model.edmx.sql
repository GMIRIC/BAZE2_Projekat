
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 18:46:45
-- Generated from EDMX file: D:\VISUAL STUDIO\BAZE2_Projekat\Repository\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WinnaryDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_WinnaryVine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VineSet] DROP CONSTRAINT [FK_WinnaryVine];
GO
IF OBJECT_ID(N'[dbo].[FK_WinnaryEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeesSet1] DROP CONSTRAINT [FK_WinnaryEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_RedVineTransport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransportSet] DROP CONSTRAINT [FK_RedVineTransport];
GO
IF OBJECT_ID(N'[dbo].[FK_StorehouseTransport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransportSet] DROP CONSTRAINT [FK_StorehouseTransport];
GO
IF OBJECT_ID(N'[dbo].[FK_PackerPackage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PackageSet] DROP CONSTRAINT [FK_PackerPackage];
GO
IF OBJECT_ID(N'[dbo].[FK_TransportPackage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PackageSet] DROP CONSTRAINT [FK_TransportPackage];
GO
IF OBJECT_ID(N'[dbo].[FK_PackageSell]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SellSet] DROP CONSTRAINT [FK_PackageSell];
GO
IF OBJECT_ID(N'[dbo].[FK_SellerSell]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SellSet] DROP CONSTRAINT [FK_SellerSell];
GO
IF OBJECT_ID(N'[dbo].[FK_SellBuy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuySet] DROP CONSTRAINT [FK_SellBuy];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerBuy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuySet] DROP CONSTRAINT [FK_CustomerBuy];
GO
IF OBJECT_ID(N'[dbo].[FK_TasterTasting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TastingSet] DROP CONSTRAINT [FK_TasterTasting];
GO
IF OBJECT_ID(N'[dbo].[FK_WhiteVineTasting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TastingSet] DROP CONSTRAINT [FK_WhiteVineTasting];
GO
IF OBJECT_ID(N'[dbo].[FK_ChampagneTastingChampagne]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TastingChampagneSet] DROP CONSTRAINT [FK_ChampagneTastingChampagne];
GO
IF OBJECT_ID(N'[dbo].[FK_TastingTastingChampagne]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TastingChampagneSet] DROP CONSTRAINT [FK_TastingTastingChampagne];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeesHierarchy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HierarchySet] DROP CONSTRAINT [FK_EmployeesHierarchy];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeesHierarchy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HierarchySet] DROP CONSTRAINT [FK_EmployeesHierarchy1];
GO
IF OBJECT_ID(N'[dbo].[FK_CityWinnary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WinnarySet] DROP CONSTRAINT [FK_CityWinnary];
GO
IF OBJECT_ID(N'[dbo].[FK_RedVine_inherits_Vine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VineSet_RedVine] DROP CONSTRAINT [FK_RedVine_inherits_Vine];
GO
IF OBJECT_ID(N'[dbo].[FK_Packer_inherits_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeesSet1_Packer] DROP CONSTRAINT [FK_Packer_inherits_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_Seller_inherits_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeesSet1_Seller] DROP CONSTRAINT [FK_Seller_inherits_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_WhiteVine_inherits_Vine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VineSet_WhiteVine] DROP CONSTRAINT [FK_WhiteVine_inherits_Vine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[WinnarySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WinnarySet];
GO
IF OBJECT_ID(N'[dbo].[CitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CitySet];
GO
IF OBJECT_ID(N'[dbo].[VineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VineSet];
GO
IF OBJECT_ID(N'[dbo].[EmployeesSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeesSet1];
GO
IF OBJECT_ID(N'[dbo].[StorehouseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StorehouseSet];
GO
IF OBJECT_ID(N'[dbo].[TransportSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransportSet];
GO
IF OBJECT_ID(N'[dbo].[PackageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PackageSet];
GO
IF OBJECT_ID(N'[dbo].[SellSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SellSet];
GO
IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[BuySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuySet];
GO
IF OBJECT_ID(N'[dbo].[TasterSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TasterSet];
GO
IF OBJECT_ID(N'[dbo].[TastingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TastingSet];
GO
IF OBJECT_ID(N'[dbo].[ChampagneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChampagneSet];
GO
IF OBJECT_ID(N'[dbo].[TastingChampagneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TastingChampagneSet];
GO
IF OBJECT_ID(N'[dbo].[HierarchySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HierarchySet];
GO
IF OBJECT_ID(N'[dbo].[VineSet_RedVine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VineSet_RedVine];
GO
IF OBJECT_ID(N'[dbo].[EmployeesSet1_Packer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeesSet1_Packer];
GO
IF OBJECT_ID(N'[dbo].[EmployeesSet1_Seller]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeesSet1_Seller];
GO
IF OBJECT_ID(N'[dbo].[VineSet_WhiteVine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VineSet_WhiteVine];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'WinnarySet'
CREATE TABLE [dbo].[WinnarySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'CitySet'
CREATE TABLE [dbo].[CitySet] (
    [Zipcode] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [CityId] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'VineSet'
CREATE TABLE [dbo].[VineSet] (
    [VineId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProductionDate] datetime  NOT NULL,
    [WinnaryId] int  NOT NULL
);
GO

-- Creating table 'EmployeesSet1'
CREATE TABLE [dbo].[EmployeesSet1] (
    [EmployeesId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Salary] nvarchar(max)  NOT NULL,
    [WinnaryId] int  NOT NULL
);
GO

-- Creating table 'StorehouseSet'
CREATE TABLE [dbo].[StorehouseSet] (
    [StorehouseId] int IDENTITY(1,1) NOT NULL,
    [Capacity] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TransportSet'
CREATE TABLE [dbo].[TransportSet] (
    [TransportId] int IDENTITY(1,1) NOT NULL,
    [RedVineVineId] int  NOT NULL,
    [StorehouseStorehouseId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PackageSet'
CREATE TABLE [dbo].[PackageSet] (
    [PackageId] int IDENTITY(1,1) NOT NULL,
    [PackerEmployeesId] int  NOT NULL,
    [TransportTransportId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SellSet'
CREATE TABLE [dbo].[SellSet] (
    [SellId] int IDENTITY(1,1) NOT NULL,
    [PackagePackageId] int  NOT NULL,
    [SellerEmployeesId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CustomerPhoneNumber] nvarchar(max)  NOT NULL,
    [PurchasedAmount] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BuySet'
CREATE TABLE [dbo].[BuySet] (
    [BuyId] int IDENTITY(1,1) NOT NULL,
    [PackagePackageId] int  NOT NULL,
    [SellSellId] int  NOT NULL,
    [CustomerCustomerId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TasterSet'
CREATE TABLE [dbo].[TasterSet] (
    [TasterId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TastingSet'
CREATE TABLE [dbo].[TastingSet] (
    [TastingId] int IDENTITY(1,1) NOT NULL,
    [TasterTasterId] int  NOT NULL,
    [WhiteVineVineId] int  NOT NULL
);
GO

-- Creating table 'ChampagneSet'
CREATE TABLE [dbo].[ChampagneSet] (
    [ChampagneId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProductionDate] datetime  NOT NULL
);
GO

-- Creating table 'TastingChampagneSet'
CREATE TABLE [dbo].[TastingChampagneSet] (
    [TastingChampagneId] int IDENTITY(1,1) NOT NULL,
    [ChampagneChampagneId] int  NOT NULL,
    [TastingTastingId] int  NOT NULL
);
GO

-- Creating table 'HierarchySet'
CREATE TABLE [dbo].[HierarchySet] (
    [HierarchyId] int IDENTITY(1,1) NOT NULL,
    [EmployeesEmployeesId] int  NOT NULL,
    [EmployeesEmployeesId1] int  NOT NULL
);
GO

-- Creating table 'VineSet_RedVine'
CREATE TABLE [dbo].[VineSet_RedVine] (
    [VineId] int  NOT NULL
);
GO

-- Creating table 'EmployeesSet1_Packer'
CREATE TABLE [dbo].[EmployeesSet1_Packer] (
    [EmployeesId] int  NOT NULL
);
GO

-- Creating table 'EmployeesSet1_Seller'
CREATE TABLE [dbo].[EmployeesSet1_Seller] (
    [EmployeesId] int  NOT NULL
);
GO

-- Creating table 'VineSet_WhiteVine'
CREATE TABLE [dbo].[VineSet_WhiteVine] (
    [VineId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'WinnarySet'
ALTER TABLE [dbo].[WinnarySet]
ADD CONSTRAINT [PK_WinnarySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CityId] in table 'CitySet'
ALTER TABLE [dbo].[CitySet]
ADD CONSTRAINT [PK_CitySet]
    PRIMARY KEY CLUSTERED ([CityId] ASC);
GO

-- Creating primary key on [VineId] in table 'VineSet'
ALTER TABLE [dbo].[VineSet]
ADD CONSTRAINT [PK_VineSet]
    PRIMARY KEY CLUSTERED ([VineId] ASC);
GO

-- Creating primary key on [EmployeesId] in table 'EmployeesSet1'
ALTER TABLE [dbo].[EmployeesSet1]
ADD CONSTRAINT [PK_EmployeesSet1]
    PRIMARY KEY CLUSTERED ([EmployeesId] ASC);
GO

-- Creating primary key on [StorehouseId] in table 'StorehouseSet'
ALTER TABLE [dbo].[StorehouseSet]
ADD CONSTRAINT [PK_StorehouseSet]
    PRIMARY KEY CLUSTERED ([StorehouseId] ASC);
GO

-- Creating primary key on [TransportId] in table 'TransportSet'
ALTER TABLE [dbo].[TransportSet]
ADD CONSTRAINT [PK_TransportSet]
    PRIMARY KEY CLUSTERED ([TransportId] ASC);
GO

-- Creating primary key on [PackageId] in table 'PackageSet'
ALTER TABLE [dbo].[PackageSet]
ADD CONSTRAINT [PK_PackageSet]
    PRIMARY KEY CLUSTERED ([PackageId] ASC);
GO

-- Creating primary key on [SellId] in table 'SellSet'
ALTER TABLE [dbo].[SellSet]
ADD CONSTRAINT [PK_SellSet]
    PRIMARY KEY CLUSTERED ([SellId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [BuyId] in table 'BuySet'
ALTER TABLE [dbo].[BuySet]
ADD CONSTRAINT [PK_BuySet]
    PRIMARY KEY CLUSTERED ([BuyId] ASC);
GO

-- Creating primary key on [TasterId] in table 'TasterSet'
ALTER TABLE [dbo].[TasterSet]
ADD CONSTRAINT [PK_TasterSet]
    PRIMARY KEY CLUSTERED ([TasterId] ASC);
GO

-- Creating primary key on [TastingId] in table 'TastingSet'
ALTER TABLE [dbo].[TastingSet]
ADD CONSTRAINT [PK_TastingSet]
    PRIMARY KEY CLUSTERED ([TastingId] ASC);
GO

-- Creating primary key on [ChampagneId] in table 'ChampagneSet'
ALTER TABLE [dbo].[ChampagneSet]
ADD CONSTRAINT [PK_ChampagneSet]
    PRIMARY KEY CLUSTERED ([ChampagneId] ASC);
GO

-- Creating primary key on [TastingChampagneId] in table 'TastingChampagneSet'
ALTER TABLE [dbo].[TastingChampagneSet]
ADD CONSTRAINT [PK_TastingChampagneSet]
    PRIMARY KEY CLUSTERED ([TastingChampagneId] ASC);
GO

-- Creating primary key on [HierarchyId] in table 'HierarchySet'
ALTER TABLE [dbo].[HierarchySet]
ADD CONSTRAINT [PK_HierarchySet]
    PRIMARY KEY CLUSTERED ([HierarchyId] ASC);
GO

-- Creating primary key on [VineId] in table 'VineSet_RedVine'
ALTER TABLE [dbo].[VineSet_RedVine]
ADD CONSTRAINT [PK_VineSet_RedVine]
    PRIMARY KEY CLUSTERED ([VineId] ASC);
GO

-- Creating primary key on [EmployeesId] in table 'EmployeesSet1_Packer'
ALTER TABLE [dbo].[EmployeesSet1_Packer]
ADD CONSTRAINT [PK_EmployeesSet1_Packer]
    PRIMARY KEY CLUSTERED ([EmployeesId] ASC);
GO

-- Creating primary key on [EmployeesId] in table 'EmployeesSet1_Seller'
ALTER TABLE [dbo].[EmployeesSet1_Seller]
ADD CONSTRAINT [PK_EmployeesSet1_Seller]
    PRIMARY KEY CLUSTERED ([EmployeesId] ASC);
GO

-- Creating primary key on [VineId] in table 'VineSet_WhiteVine'
ALTER TABLE [dbo].[VineSet_WhiteVine]
ADD CONSTRAINT [PK_VineSet_WhiteVine]
    PRIMARY KEY CLUSTERED ([VineId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WinnaryId] in table 'VineSet'
ALTER TABLE [dbo].[VineSet]
ADD CONSTRAINT [FK_WinnaryVine]
    FOREIGN KEY ([WinnaryId])
    REFERENCES [dbo].[WinnarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WinnaryVine'
CREATE INDEX [IX_FK_WinnaryVine]
ON [dbo].[VineSet]
    ([WinnaryId]);
GO

-- Creating foreign key on [WinnaryId] in table 'EmployeesSet1'
ALTER TABLE [dbo].[EmployeesSet1]
ADD CONSTRAINT [FK_WinnaryEmployees]
    FOREIGN KEY ([WinnaryId])
    REFERENCES [dbo].[WinnarySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WinnaryEmployees'
CREATE INDEX [IX_FK_WinnaryEmployees]
ON [dbo].[EmployeesSet1]
    ([WinnaryId]);
GO

-- Creating foreign key on [RedVineVineId] in table 'TransportSet'
ALTER TABLE [dbo].[TransportSet]
ADD CONSTRAINT [FK_RedVineTransport]
    FOREIGN KEY ([RedVineVineId])
    REFERENCES [dbo].[VineSet_RedVine]
        ([VineId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RedVineTransport'
CREATE INDEX [IX_FK_RedVineTransport]
ON [dbo].[TransportSet]
    ([RedVineVineId]);
GO

-- Creating foreign key on [StorehouseStorehouseId] in table 'TransportSet'
ALTER TABLE [dbo].[TransportSet]
ADD CONSTRAINT [FK_StorehouseTransport]
    FOREIGN KEY ([StorehouseStorehouseId])
    REFERENCES [dbo].[StorehouseSet]
        ([StorehouseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StorehouseTransport'
CREATE INDEX [IX_FK_StorehouseTransport]
ON [dbo].[TransportSet]
    ([StorehouseStorehouseId]);
GO

-- Creating foreign key on [PackerEmployeesId] in table 'PackageSet'
ALTER TABLE [dbo].[PackageSet]
ADD CONSTRAINT [FK_PackerPackage]
    FOREIGN KEY ([PackerEmployeesId])
    REFERENCES [dbo].[EmployeesSet1_Packer]
        ([EmployeesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PackerPackage'
CREATE INDEX [IX_FK_PackerPackage]
ON [dbo].[PackageSet]
    ([PackerEmployeesId]);
GO

-- Creating foreign key on [TransportTransportId] in table 'PackageSet'
ALTER TABLE [dbo].[PackageSet]
ADD CONSTRAINT [FK_TransportPackage]
    FOREIGN KEY ([TransportTransportId])
    REFERENCES [dbo].[TransportSet]
        ([TransportId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransportPackage'
CREATE INDEX [IX_FK_TransportPackage]
ON [dbo].[PackageSet]
    ([TransportTransportId]);
GO

-- Creating foreign key on [PackagePackageId] in table 'SellSet'
ALTER TABLE [dbo].[SellSet]
ADD CONSTRAINT [FK_PackageSell]
    FOREIGN KEY ([PackagePackageId])
    REFERENCES [dbo].[PackageSet]
        ([PackageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PackageSell'
CREATE INDEX [IX_FK_PackageSell]
ON [dbo].[SellSet]
    ([PackagePackageId]);
GO

-- Creating foreign key on [SellerEmployeesId] in table 'SellSet'
ALTER TABLE [dbo].[SellSet]
ADD CONSTRAINT [FK_SellerSell]
    FOREIGN KEY ([SellerEmployeesId])
    REFERENCES [dbo].[EmployeesSet1_Seller]
        ([EmployeesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellerSell'
CREATE INDEX [IX_FK_SellerSell]
ON [dbo].[SellSet]
    ([SellerEmployeesId]);
GO

-- Creating foreign key on [SellSellId] in table 'BuySet'
ALTER TABLE [dbo].[BuySet]
ADD CONSTRAINT [FK_SellBuy]
    FOREIGN KEY ([SellSellId])
    REFERENCES [dbo].[SellSet]
        ([SellId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellBuy'
CREATE INDEX [IX_FK_SellBuy]
ON [dbo].[BuySet]
    ([SellSellId]);
GO

-- Creating foreign key on [CustomerCustomerId] in table 'BuySet'
ALTER TABLE [dbo].[BuySet]
ADD CONSTRAINT [FK_CustomerBuy]
    FOREIGN KEY ([CustomerCustomerId])
    REFERENCES [dbo].[CustomerSet]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerBuy'
CREATE INDEX [IX_FK_CustomerBuy]
ON [dbo].[BuySet]
    ([CustomerCustomerId]);
GO

-- Creating foreign key on [TasterTasterId] in table 'TastingSet'
ALTER TABLE [dbo].[TastingSet]
ADD CONSTRAINT [FK_TasterTasting]
    FOREIGN KEY ([TasterTasterId])
    REFERENCES [dbo].[TasterSet]
        ([TasterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TasterTasting'
CREATE INDEX [IX_FK_TasterTasting]
ON [dbo].[TastingSet]
    ([TasterTasterId]);
GO

-- Creating foreign key on [WhiteVineVineId] in table 'TastingSet'
ALTER TABLE [dbo].[TastingSet]
ADD CONSTRAINT [FK_WhiteVineTasting]
    FOREIGN KEY ([WhiteVineVineId])
    REFERENCES [dbo].[VineSet_WhiteVine]
        ([VineId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WhiteVineTasting'
CREATE INDEX [IX_FK_WhiteVineTasting]
ON [dbo].[TastingSet]
    ([WhiteVineVineId]);
GO

-- Creating foreign key on [ChampagneChampagneId] in table 'TastingChampagneSet'
ALTER TABLE [dbo].[TastingChampagneSet]
ADD CONSTRAINT [FK_ChampagneTastingChampagne]
    FOREIGN KEY ([ChampagneChampagneId])
    REFERENCES [dbo].[ChampagneSet]
        ([ChampagneId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChampagneTastingChampagne'
CREATE INDEX [IX_FK_ChampagneTastingChampagne]
ON [dbo].[TastingChampagneSet]
    ([ChampagneChampagneId]);
GO

-- Creating foreign key on [TastingTastingId] in table 'TastingChampagneSet'
ALTER TABLE [dbo].[TastingChampagneSet]
ADD CONSTRAINT [FK_TastingTastingChampagne]
    FOREIGN KEY ([TastingTastingId])
    REFERENCES [dbo].[TastingSet]
        ([TastingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TastingTastingChampagne'
CREATE INDEX [IX_FK_TastingTastingChampagne]
ON [dbo].[TastingChampagneSet]
    ([TastingTastingId]);
GO

-- Creating foreign key on [EmployeesEmployeesId] in table 'HierarchySet'
ALTER TABLE [dbo].[HierarchySet]
ADD CONSTRAINT [FK_EmployeesHierarchy]
    FOREIGN KEY ([EmployeesEmployeesId])
    REFERENCES [dbo].[EmployeesSet1]
        ([EmployeesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeesHierarchy'
CREATE INDEX [IX_FK_EmployeesHierarchy]
ON [dbo].[HierarchySet]
    ([EmployeesEmployeesId]);
GO

-- Creating foreign key on [EmployeesEmployeesId1] in table 'HierarchySet'
ALTER TABLE [dbo].[HierarchySet]
ADD CONSTRAINT [FK_EmployeesHierarchy1]
    FOREIGN KEY ([EmployeesEmployeesId1])
    REFERENCES [dbo].[EmployeesSet1]
        ([EmployeesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeesHierarchy1'
CREATE INDEX [IX_FK_EmployeesHierarchy1]
ON [dbo].[HierarchySet]
    ([EmployeesEmployeesId1]);
GO

-- Creating foreign key on [CityId] in table 'WinnarySet'
ALTER TABLE [dbo].[WinnarySet]
ADD CONSTRAINT [FK_CityWinnary]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[CitySet]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityWinnary'
CREATE INDEX [IX_FK_CityWinnary]
ON [dbo].[WinnarySet]
    ([CityId]);
GO

-- Creating foreign key on [VineId] in table 'VineSet_RedVine'
ALTER TABLE [dbo].[VineSet_RedVine]
ADD CONSTRAINT [FK_RedVine_inherits_Vine]
    FOREIGN KEY ([VineId])
    REFERENCES [dbo].[VineSet]
        ([VineId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EmployeesId] in table 'EmployeesSet1_Packer'
ALTER TABLE [dbo].[EmployeesSet1_Packer]
ADD CONSTRAINT [FK_Packer_inherits_Employees]
    FOREIGN KEY ([EmployeesId])
    REFERENCES [dbo].[EmployeesSet1]
        ([EmployeesId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EmployeesId] in table 'EmployeesSet1_Seller'
ALTER TABLE [dbo].[EmployeesSet1_Seller]
ADD CONSTRAINT [FK_Seller_inherits_Employees]
    FOREIGN KEY ([EmployeesId])
    REFERENCES [dbo].[EmployeesSet1]
        ([EmployeesId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VineId] in table 'VineSet_WhiteVine'
ALTER TABLE [dbo].[VineSet_WhiteVine]
ADD CONSTRAINT [FK_WhiteVine_inherits_Vine]
    FOREIGN KEY ([VineId])
    REFERENCES [dbo].[VineSet]
        ([VineId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------