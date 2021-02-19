CREATE TABLE [dbo].[ComponentInputs] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [RecipeId]         INT NOT NULL,
    [InputComponentId] INT NOT NULL,
    [AmountNeeded]     INT NOT NULL,
    CONSTRAINT [PK_RecipeInputs] PRIMARY KEY CLUSTERED ([Id] ASC)
);



