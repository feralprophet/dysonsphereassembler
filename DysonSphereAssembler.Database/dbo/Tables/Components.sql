CREATE TABLE [dbo].[Components] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [IsBasic]    BIT           CONSTRAINT [DF_Component_IsBasic] DEFAULT ((0)) NOT NULL,
    [IsRaw]      BIT           CONSTRAINT [DF_Component_IsRaw] DEFAULT ((0)) NOT NULL,
    [IsBuilding] BIT           CONSTRAINT [DF_Components_IsBuilding] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_Components_Name_Unique] UNIQUE NONCLUSTERED ([Name] ASC)
);

