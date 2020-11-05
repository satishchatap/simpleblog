namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class ArticleRepository :IArticleRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public ArticleRepository(DataContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

        /// <inheritdoc />
        public async Task Add(Article Article, Comment comment)
        {
            //var art = this._context.Articles.First(a => a.ArticleId == Article.ArticleId);
            //art.Comments.Add(comment);
            await this._context
                .Articles
                .AddAsync(Article)
                .ConfigureAwait(false);

            await this._context
                .Comments
                .AddAsync(comment)
                .ConfigureAwait(false);
        }
        /// <inheritdoc />
        public async Task Add(Article Article, Like like)
        {
            await this._context
                .Articles
                .AddAsync(Article)
                .ConfigureAwait(false);

            await this._context
                .Likes
                .AddAsync(like)
                .ConfigureAwait(false);
        }
        /// <inheritdoc />
        public async Task DeleteAsyc(ArticleId ArticleId)
        {
            await this._context
                .Database
                .ExecuteSqlRawAsync("DELETE FROM [Like] WHERE ArticleId=@p0", ArticleId.Id)
                .ConfigureAwait(false);

            await this._context
                .Database
                .ExecuteSqlRawAsync("DELETE FROM [Comment] WHERE ArticleId=@p0", ArticleId.Id)
                .ConfigureAwait(false);

            await this._context
                .Database
                .ExecuteSqlRawAsync("DELETE FROM [Article] WHERE ArticleId=@p0", ArticleId.Id)
                .ConfigureAwait(false);
        }

        public void Delete(ArticleId articleId)
        {
            this._context.Articles.Remove(this._context.Articles.First(a => a.ArticleId == articleId));
        }
        /// <inheritdoc />
        public async Task<IArticle> GetArticle(ArticleId ArticleId)
        {
            Article Article = await this._context
                .Articles
                .Where(e => e.ArticleId == ArticleId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (Article is Article findArticle)
            {
                await this.LoadCommentsLikes(findArticle)
                    .ConfigureAwait(false);

                return Article;
            }

            return ArticleNull.Instance;
        }

        /// <inheritdoc />
        public async Task Update(Article Article, Comment comment) => await this._context
            .Comments
            .AddAsync(comment)
            .ConfigureAwait(false);

        /// <inheritdoc />
        public async Task Update(Article Article, Like like) => await this._context
            .Likes
            .AddAsync(like)
            .ConfigureAwait(false);

        public async Task<IArticle> Find(ArticleId ArticleId, string author)
        {
            Article Article = await this._context
                .Articles
                .Where(e => e.Author == author && e.ArticleId == ArticleId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (Article is Article findArticle)
            {
                await this.LoadCommentsLikes(findArticle)
                    .ConfigureAwait(false);

                return Article;
            }

            return ArticleNull.Instance;
        }

        public async Task<IList<Article>> GetArticles(string author)
        {
            List<Article> Articles = await this._context
                .Articles
                .Where(e => e.Author == author)
                .ToListAsync()
                .ConfigureAwait(false);
            //Lazy loading -can be disabled if not needed
            foreach (Article findArticle in Articles)
            {
                await this.LoadCommentsLikes(findArticle)
                    .ConfigureAwait(false);
            }

            return Articles;
        }
        public async Task<IList<Article>> GetAllArticles()
        {
            List<Article> Articles = await this._context
                .Articles
                .ToListAsync()
                .ConfigureAwait(false);
            //Lazy loading -can be disabled if not needed
            foreach (Article findArticle in Articles)
            {
                await this.LoadCommentsLikes(findArticle)
                    .ConfigureAwait(false);
            }

            return Articles;
        }
        private async Task LoadCommentsLikes(Article article)
        {
            await this._context
                .Comments
                .Where(e => e.ArticleId.Equals(article.ArticleId))
                .ToListAsync()
                .ConfigureAwait(false);

            await this._context
                .Likes
                .Where(e => e.ArticleId.Equals(article.ArticleId))
                .ToListAsync()
                .ConfigureAwait(false);
        }

       

        public async Task Add(Article article)
        {
            await this._context
                .Articles
                .AddAsync(article)
                .ConfigureAwait(false);
        }
        public async Task Update(Article article)
        {
            await this._context
                .Articles
                .AddAsync(article)
                .ConfigureAwait(false);
        }
    }
}