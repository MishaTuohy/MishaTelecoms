CREATE TABLE [dbo].[ApplicationRole] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (256) NOT NULL,
    [NormalizedName] NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ApplicationRole_NormalizedName]
    ON [dbo].[ApplicationRole]([NormalizedName] ASC);

