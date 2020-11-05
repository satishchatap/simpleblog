

namespace IntegrationTests.EntityFrameworkTests
{
    using Domain;
    using Domain.ValueObjects;
    using Infrastructure.DataAccess.Repositories;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    public sealed class ArticleRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public ArticleRepositoryTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task Add()
        {
            ArticleRepository articleRepository = new ArticleRepository(this._fixture.Context);

            Article article = new Article(
                new ArticleId(Guid.NewGuid()),
                "This is Title", "This is Body", "This is Summary", SeedData.DefaultAuthor
            );

            Comment comment = new Comment(
                new CommentId(Guid.NewGuid()),
               article.ArticleId, "This is my First Comment", SeedData.DefaultAuthor
            );

            Like like = new Like(
                new LikeId(Guid.NewGuid()), SeedData.DefaultAuthor,
                article.ArticleId
            );

            await articleRepository
               .Add(article)
               .ConfigureAwait(false);

            await articleRepository
                .Add(article, like)
                .ConfigureAwait(false);

            await articleRepository
                .Add(article, comment)
                .ConfigureAwait(false);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAnyArticle = this._fixture
                .Context
                .Articles
                .Any(e => e.ArticleId == article.ArticleId);

            bool hasAnyComment = this._fixture
                .Context
                .Comments
                .Any(e => e.CommentId == comment.CommentId);

            bool hasAnyLike = this._fixture
                .Context
                .Likes
                .Any(e => e.LikeId == like.LikeId);

            Assert.True(hasAnyArticle && hasAnyComment && hasAnyLike);
        }

        [Fact]
        public async Task Delete()
        {
            ArticleRepository articleRepository = new ArticleRepository(this._fixture.Context);

            Article article = new Article(
                new ArticleId(Guid.NewGuid()),
                "This is Title", "This is Body", "This is Summary", SeedData.DefaultAuthor
            );

            Comment comment = new Comment(
                new CommentId(Guid.NewGuid()),
                article.ArticleId, "This is my First Comment", SeedData.DefaultAuthor
            );

            Like like = new Like(
                new LikeId(Guid.NewGuid()), SeedData.DefaultAuthor,
                article.ArticleId
            );

            await articleRepository
               .Add(article)
               .ConfigureAwait(false);

            await articleRepository
                .Add(article, comment)
                .ConfigureAwait(false);

            await articleRepository
                .Add(article, like)
                .ConfigureAwait(false);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            articleRepository
                .Delete(article.ArticleId);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAnyArticle = this._fixture
                .Context
                .Articles
                .Any(e => e.ArticleId == article.ArticleId);

            bool hasAnyComment = this._fixture
                .Context
                .Comments
                .Any(e => e.CommentId == comment.CommentId);

            bool hasAnyLike = this._fixture
                .Context
                .Likes
                .Any(e => e.LikeId == like.LikeId);

            Assert.False(hasAnyArticle && hasAnyComment && hasAnyLike);
        }
    }
}
