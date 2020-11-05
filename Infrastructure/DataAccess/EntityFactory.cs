using Domain;
using Domain.ValueObjects;
using System;

namespace Infrastructure
{
    public sealed class EntityFactory : IArticleFactory
    {
        /// <inheritdoc />
        public Article NewArticle(string title, string body, string summary, string author)
            => new Article(new ArticleId(Guid.NewGuid()),  title, body, summary, author);
        /// <inheritdoc />
        public Comment NewComment(ArticleId articleId, string description, string author)
            => new Comment(new CommentId(Guid.NewGuid()), articleId, description, author);
        /// <inheritdoc />
        public Like NewLike(string author, ArticleId articleId)
            => new Like(new LikeId(Guid.NewGuid()),  author, articleId);
    }
}
