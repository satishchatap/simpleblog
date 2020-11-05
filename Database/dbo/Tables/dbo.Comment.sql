CREATE TABLE [dbo].[Comment] (
    [CommentId]   UNIQUEIDENTIFIER NOT NULL,
    [Author]      VARCHAR (50)     NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    [ArticleId]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]   DATETIME2 (7)    NOT NULL,
    [ModifiedOn]  DATETIME2 (7)    NOT NULL,
    [CreatedBy]   NVARCHAR (MAX)   NULL,
    [ModifiedBy]  NVARCHAR (MAX)   NULL,
    [RowVersion]  ROWVERSION       NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_Comment_Article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Comment_ArticleId]
    ON [dbo].[Comment]([ArticleId] ASC);

