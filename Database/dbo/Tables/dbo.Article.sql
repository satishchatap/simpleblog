CREATE TABLE [dbo].[Article] (
    [ArticleId]     UNIQUEIDENTIFIER NOT NULL,
    [Author]        VARCHAR (50)     NULL,
    [Title]         VARCHAR (100)    NOT NULL,
    [Summary]       VARCHAR (200)    NOT NULL,
    [Body]          NVARCHAR (MAX)   NOT NULL,
    [CreatedOn]     DATETIME2 (7)    NOT NULL,
    [ModifiedOn]    DATETIME2 (7)    NOT NULL,
    [CreatedBy]     NVARCHAR (MAX)   NULL,
    [ModifiedBy]    NVARCHAR (MAX)   NULL,
    [PublishedDate] DATETIME2 (7)    NOT NULL,
    [RowVersion]    ROWVERSION       NULL,
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([ArticleId] ASC)
);

