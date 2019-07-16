
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/16/2019 12:26:15
-- Generated from EDMX file: C:\Users\amrit.heer\Source\Repos\synetec-assessment-mvc\Solution\SynetecMvcAssessment\Data\BonusPoolModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MvcInterviewV3Entities1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[HrDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HrDepartment];
GO
IF OBJECT_ID(N'[dbo].[HrEmployee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HrEmployee];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HrDepartments'
CREATE TABLE [dbo].[HrDepartments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [BonusPoolAllocationPerc] int  NULL
);
GO

-- Creating table 'HrEmployees'
CREATE TABLE [dbo].[HrEmployees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FistName] nvarchar(50)  NOT NULL,
    [SecondName] nvarchar(50)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [HrDepartmentId] int  NOT NULL,
    [JobTitle] nvarchar(50)  NOT NULL,
    [Salary] int  NOT NULL,
    [Full_Name] nvarchar(101)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'HrDepartments'
ALTER TABLE [dbo].[HrDepartments]
ADD CONSTRAINT [PK_HrDepartments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'HrEmployees'
ALTER TABLE [dbo].[HrEmployees]
ADD CONSTRAINT [PK_HrEmployees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------