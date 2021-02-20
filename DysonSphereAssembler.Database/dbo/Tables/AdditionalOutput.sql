CREATE TABLE [dbo].[AdditionalOutput] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [RecipeId]    INT NOT NULL,
    [ComponentId] INT NOT NULL,
    [Amount]      INT NOT NULL,
    CONSTRAINT [PK_AdditionalOutput] PRIMARY KEY CLUSTERED ([Id] ASC)
);



