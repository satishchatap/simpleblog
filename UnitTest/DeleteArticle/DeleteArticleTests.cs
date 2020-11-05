namespace UnitTest.DeleteArticle
{
    using Domain;
    using Domain.ValueObjects;
    using Infrastructure;
    using Infrastructure.DataAccess.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class DeleteArticleTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public DeleteArticleTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task DeleteArticle_and_childs()
        {
            ArticleRepositoryFake articleRepository = new ArticleRepositoryFake(this._fixture.Context);

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

            Assert.IsTrue(hasAnyArticle && hasAnyComment && hasAnyLike);

            var articleDelete = this._fixture
               .Context
               .Articles
               .First(e => e.ArticleId == article.ArticleId);

            var actual =this._fixture.Context.Articles.Remove(articleDelete);

            Assert.IsTrue(actual);
        }

       
    }
}
