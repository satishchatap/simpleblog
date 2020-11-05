using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using Domain.ValueObjects;

    /// <inheritdoc />
    public sealed class ArticleRepositoryFake : IArticleRepository
    {
        private readonly DataContextFake _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public ArticleRepositoryFake(DataContextFake context) => this._context = context;

        /// <inheritdoc />
        public async Task Add(Article article, Comment comment)
        {
            this._context
                .Articles
                .Add(article);

            this._context
                .Comments
                .Add(comment);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

       

        public async Task Add(Article article, Like like)
        {
            this._context
                .Articles
                .Add(article);

            this._context
                .Likes
                .Add(like);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task Add(Article article)
        {
            this._context
               .Articles
               .Add(article);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
        public async Task Update(Article article)
        {
            this._context
               .Articles
               .Add(article);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
        /// <inheritdoc />
        public async Task Delete(ArticleId articleId)
        {
            Article articleOld = this._context
                .Articles
                .SingleOrDefault(e => e.ArticleId.Equals(articleId));

            this._context
                .Articles
                .Remove(articleOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public Task DeleteAsyc(ArticleId articleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IArticle> Find(ArticleId articleId, string author)
        {
            Article article = this._context
                .Articles
                .Where(e => e.Author == author && e.ArticleId.Equals(articleId))
                .Select(e => e)
                .SingleOrDefault();

            if (article == null)
            {
                return ArticleNull.Instance;
            }

            return await Task.FromResult(article)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IArticle> GetArticle(ArticleId articleId)
        {
            Article article = this._context
                .Articles
                .SingleOrDefault(e => e.ArticleId.Equals(articleId));

            if (article == null)
            {
                return ArticleNull.Instance;
            }

            return await Task.FromResult(article)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Article>> GetArticles(string author)
        {
            List<Article> articles = this._context
                .Articles
                .Where(e => e.Author == author)
                .ToList();

            return await Task.FromResult(articles)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Article>> GetAllArticles()
        {
            List<Article> articles = this._context
                .Articles
                .ToList();

            return await Task.FromResult(articles)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(Article article, Comment comment)
        {
            Article articleOld = this._context
                .Articles
                .SingleOrDefault(e => e.ArticleId.Equals(article.ArticleId));

            if (articleOld != null)
            {
                this._context.Articles.Remove(articleOld);
            }

            this._context.Articles.Add(article);
            this._context.Comments.Add(comment);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(Article article, Like like)
        {
            Article articleOld = this._context
                .Articles
                .SingleOrDefault(e => e.ArticleId.Equals(article.ArticleId));

            if (articleOld != null)
            {
                this._context.Articles.Remove(articleOld);
                this._context.Articles.Add(article);
            }

            this._context.Likes.Add(like);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

    }
}
