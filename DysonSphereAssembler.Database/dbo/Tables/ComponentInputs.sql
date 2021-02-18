CREATE TABLE [dbo].[ComponentInputs] (
    [Id]                INT NOT NULL,
    [RecipeId]          INT NOT NULL,
    [InputComponenetId] INT NOT NULL,
    [AmountNeeded]      INT NOT NULL,
    [Version]           INT CONSTRAINT [DF_ComponentInputs_Group] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_RecipeInputs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

