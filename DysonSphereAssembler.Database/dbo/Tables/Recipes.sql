CREATE TABLE [dbo].[Recipes] (
    [Id]             INT          NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [ComponentId]    INT          NOT NULL,
    [MachineType]    INT          NOT NULL,
    [TimeToCreate]   DECIMAL (18) NOT NULL,
    [NumberProduced] INT          NOT NULL,
    [UseByDefault]   BIT          CONSTRAINT [DF_Recipes_UseByDefault] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

