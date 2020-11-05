namespace WebApi.Modules.Common.FeatureFlags
{
    /// <summary>
    ///     Features Flags Enum.
    /// </summary>
    public enum CustomFeature
    {
        /// <summary>
        /// Article
        /// </summary>
        CreateArticle,

        /// <summary>
        ///     Article Likes.
        /// </summary>
        ArticleLikeCount,

        /// <summary>
        ///     Article Comments.
        /// </summary>
        ArticleCommentCount,

        /// <summary>
        ///     Add Comment
        /// </summary>
        CommentArticle,

        /// <summary>
        ///     Like Article.
        /// </summary>
        LikeArticle,

        /// <summary>
        ///     Get Article.
        /// </summary>
        GetArticle,

        /// <summary>
        ///     Get Articles.
        /// </summary>
        GetArticles,

        /// <summary>
        ///     Filter errors out.
        /// </summary>
        ErrorFilter,

        /// <summary>
        ///     Use Swagger.
        /// </summary>
        Swagger,

        /// <summary>
        ///     Use SQL Server Persistence.
        /// </summary>
        SQLServer,        

        /// <summary>
        ///     Use authentication.
        /// </summary>
        Authentication,

        /// <summary>
        ///     Edit Article
        /// </summary>
        EditArticle,

        /// <summary>
        ///     Delete Article
        /// </summary>
        DeleteArticle,

        /// <summary>
        /// Get All Articles
        /// </summary>
        GetAllArticles
    }
}
