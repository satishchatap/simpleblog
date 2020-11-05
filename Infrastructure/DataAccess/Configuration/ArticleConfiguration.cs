namespace Infrastructure.DataAccess.Configuration
{
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    ///     Article Configuration.
    /// </summary>
    public sealed class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        /// <summary>
        ///     Configure Article.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Article");
            builder.Property(article => article.Title)
                .IsRequired();
            builder.Property(article => article.Summary)
                .IsRequired();
            builder.Property(article => article.Body)
                .IsRequired();
            builder.Property(article => article.PublishedDate)
                .IsRequired();
            builder.Property(b => b.ArticleId)
                .HasConversion(
                    v => v.Id,
                    v => new ArticleId(v))
                .IsRequired();

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.Property(b => b.CreatedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            builder.Property(b => b.ModifiedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);


            builder.HasMany(x => x.Comments)
                .WithOne(b => b.Article)
               .HasForeignKey(b => b.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Likes)
                .WithOne(b => b.Article)
               .HasForeignKey(b => b.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
