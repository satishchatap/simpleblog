namespace Infrastructure.DataAccess
{
    using Domain;
    using Domain.ValueObjects;
    using System;
    using System.Collections.ObjectModel;

    public sealed class DataContextFake
    {
        /// <summary>
        /// </summary>
        public DataContextFake()
        {
            Comment comment = new Comment(
                new CommentId(Guid.NewGuid()),
                SeedData.DefaultArticleId,
                SeedData.DefaultCommentDescription, 
                SeedData.DefaultAuthor);

            Like like = new Like(
                new LikeId(Guid.NewGuid()),
                SeedData.DefaultAuthor,
                SeedData.DefaultArticleId);

            Article article = new Article(
                SeedData.DefaultArticleId,
                SeedData.DefaultArticleTitle,
                SeedData.DefaultArticleBody,
                SeedData.DefaultArticleSummary,
                SeedData.DefaultAuthor);

            article.Comments.Add(comment);
            article.Likes.Add(like);

            this.Articles.Add(article);
            this.Comments.Add(comment);
            this.Likes.Add(like);

            Article article2 = new Article(
                SeedData.SecondArticleId,
                SeedData.DefaultArticleTitle,
                SeedData.DefaultArticleBody,
                SeedData.DefaultArticleSummary,
                SeedData.DefaultAuthor);

            this.Articles.Add(article2);
        }

        /// <summary>
        ///     Gets or sets Articles.
        /// </summary>
        public Collection<Article> Articles { get; } = new Collection<Article>();

        /// <summary>
        ///     Gets or sets Comments.
        /// </summary>
        public Collection<Comment> Comments { get; } = new Collection<Comment>();

        /// <summary>
        ///     Gets or sets Likes.
        /// </summary>
        public Collection<Like> Likes { get; } = new Collection<Like>();
    }
}
