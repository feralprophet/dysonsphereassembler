CREATE TABLE [dbo].[Machines] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Name]               VARCHAR (50)    NOT NULL,
    [MachineType]        INT             NOT NULL,
    [ProductionModifier] DECIMAL (18, 1) NOT NULL,
    CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED ([Id] ASC)
);



