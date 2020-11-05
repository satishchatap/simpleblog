

namespace IntegrationTests
{
    using System;
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public static class SeedData
    {
        public static readonly string DefaultUserId = "197D0438-E04B-453D-B5DE-ECA05960C6AE";

        public static readonly ArticleId DefaultArticleId =
            new ArticleId(new Guid("4C510CFE-5D61-4A46-A3D9-C4313426655F"));

        public static readonly string DefaultAuthor ="schatap";

        public static readonly ArticleId SecondArticleId =
            new ArticleId(new Guid("E82D2EA6-E9D3-444D-A22F-9D65F2F2C65E"));

        public static readonly string SecondExternalUserId = "C70E69BF-EDC7-48E3-BF33-B424F7464C5F";

        public static readonly CommentId DefaultCommentId =
            new CommentId(new Guid("7BF066BA-379A-4E72-A59B-9755FDA432CE"));

        public static readonly LikeId DefaultLikeId =
            new LikeId(new Guid("31ADE963-BD69-4AFB-9DF7-611AE2CFA651"));

        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<Article>()
                .HasData(
                    new
                    {
                        ArticleId = DefaultArticleId,
                        PublicationDate = DateTime.UtcNow,
                        AuthorId = DefaultAuthor
                    });

            builder.Entity<Comment>()
                .HasData(
                    new
                    {
                        CommentId = DefaultCommentId,
                        ArticleId = DefaultArticleId,
                        AuthorId = DefaultAuthor
                    });

            builder.Entity<Like>()
                .HasData(
                    new
                    {
                        LikeId = DefaultLikeId,
                        ArticleId = DefaultArticleId,
                        AuthorId = DefaultAuthor
                    });
        }
    }
}
