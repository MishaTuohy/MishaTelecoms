﻿CREATE TABLE [dbo].[ApplicationUser] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [NormalizedUserName]   NVARCHAR (256) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [NormalizedEmail]      NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (50)  NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedUserName]
    ON [dbo].[ApplicationUser]([NormalizedUserName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedEmail]
    ON [dbo].[ApplicationUser]([NormalizedEmail] ASC);
