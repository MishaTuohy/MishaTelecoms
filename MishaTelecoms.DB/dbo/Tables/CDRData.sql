CREATE TABLE [dbo].[CDRData] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [CallingNumber] NVARCHAR (MAX)   NULL,
    [CalledNumber]  NVARCHAR (MAX)   NULL,
    [Country]       NVARCHAR (MAX)   NULL,
    [CallType]      NVARCHAR (MAX)   NULL,
    [Duration]      INT              NOT NULL,
    [DateCreated]   NVARCHAR (MAX)   NULL,
    [Cost]          MONEY       NOT NULL,
    CONSTRAINT [PK_CDRData] PRIMARY KEY CLUSTERED ([Id] ASC)
);