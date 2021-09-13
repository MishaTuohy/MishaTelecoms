CREATE TABLE [dbo].[CDRData] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [CallingNumber] NVARCHAR (MAX)   NOT NULL,
    [CalledNumber]  NVARCHAR (MAX)   NOT NULL,
    [Country]       NVARCHAR (MAX)   NOT NULL,
    [CallType]      NVARCHAR (MAX)   NOT NULL,
    [Duration]      INT              NOT NULL,
    [DateCreated]   NVARCHAR (MAX)   NOT NULL,
    [Cost]          MONEY       NOT NULL,
    CONSTRAINT [PK_CDRData] PRIMARY KEY CLUSTERED ([Id] ASC)
);