IF OBJECT_ID(N'[boilerplate].[__EFMigrationsHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'boilerplate') IS NULL EXEC(N'CREATE SCHEMA [boilerplate];');
    CREATE TABLE [boilerplate].[__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [boilerplate].[__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240413130145_Initialize'
)
BEGIN
    IF SCHEMA_ID(N'boilerplate') IS NULL EXEC(N'CREATE SCHEMA [boilerplate];');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [boilerplate].[__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240413130145_Initialize'
)
BEGIN
    CREATE TABLE [boilerplate].[Boilerplate] (
        [Id] nvarchar(450) NOT NULL,
        [CreatedByUserId] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        CONSTRAINT [PK_Boilerplate] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [boilerplate].[__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240413130145_Initialize'
)
BEGIN
    INSERT INTO [boilerplate].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240413130145_Initialize', N'8.0.4');
END;
GO

COMMIT;
GO

