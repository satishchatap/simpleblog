CREATE TABLE [dbo].[Like] (
    [LikeId]     UNIQUEIDENTIFIER NOT NULL,
    [Author]     NVARCHAR (MAX)   NOT NULL,
    [ArticleId]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]  DATETIME2 (7)    NOT NULL,
    [ModifiedOn] DATETIME2 (7)    NOT NULL,
    [CreatedBy]  NVARCHAR (MAX)   NULL,
    [ModifiedBy] NVARCHAR (MAX)   NULL,
    [RowVersion] ROWVERSION       NULL,
    CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED ([LikeId] ASC),
    CONSTRAINT [FK_Like_Article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Like_ArticleId]
    ON [dbo].[Like]([ArticleId] ASC);

