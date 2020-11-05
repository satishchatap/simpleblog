using Domain.ValueObjects;
using System;

namespace Domain
{
    public interface IArticleFactory
    {
        /// <summary>
        /// Create New Article
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="summary"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public Article NewArticle(string title, string body, string summary, string author);

        /// <summary>
        ///  Create New Comment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="articleId"></param>
        /// <param name="description"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public Comment NewComment(ArticleId articleId, string description, string author);

        /// <summary>
        /// Create New Like
        /// </summary>
        /// <param name="author"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public Like NewLike(string author, ArticleId articleId);
    }
}
