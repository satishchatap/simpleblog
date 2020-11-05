using Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IArticleRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        Task<IArticle> GetArticle(ArticleId ArticleId);

        /// <summary>
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Task<IList<Article>> GetArticles(string author);

        /// <summary>
        /// Get All Articles
        /// </summary>
        /// <returns></returns>
        Task<IList<Article>> GetAllArticles();

        /// <summary>
        ///     Adds an Article.
        /// </summary>
        /// <param name="article">Article object.</param>
        /// <param name="comment">Comment object.</param>
        /// <returns>Task.</returns>
        Task Add(Article article, Comment comment);

        /// <summary>
        ///     Adds an Article.
        /// </summary>
        /// <param name="article">Article object.</param>
        /// <param name="like">Like object.</param>
        /// <returns>Task.</returns>
        Task Add(Article article, Like like);

        /// <summary>
        ///     Updates an Article.
        /// </summary>
        /// <param name="article">Article object.</param>
        /// <param name="comment">Comment object.</param>
        /// <returns>Task.</returns>
        Task Update(Article article, Comment comment);

        /// <summary>
        ///     Updates the Article.
        /// </summary>
        /// <param name="article">Article object.</param>
        /// <param name="like">Like object.</param>
        /// <returns>Task.</returns>
        Task Update(Article article, Like like);

        /// <summary>
        ///     Deletes the Article.
        /// </summary>
        /// <param name="articleId">Article Id.</param>
        /// <returns>Task.</returns>
        Task DeleteAsyc(ArticleId articleId);

        /// <summary>
        ///     create the Article.
        /// </summary>
        /// <param name="article">Article.</param>
        /// <returns>Task.</returns>
        Task Add(Article article);

        /// <summary>
        ///     update the Article.
        /// </summary>
        /// <param name="article">Article.</param>
        /// <returns>Task.</returns>
        Task Update(Article article);
        /// <summary>
        ///     Finds an Article.
        /// </summary>
        /// <param name="articleId">Article Id.</param>
        /// <param name="authorId">AuthorId Id.</param>
        /// <returns></returns>
        Task<IArticle> Find(ArticleId articleId, string author);
    }
}
