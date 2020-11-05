namespace Infrastructure.DataAccess.Configuration
{
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    ///     Comment Configuration.
    /// </summary>
    public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        /// <summary>
        ///     Configure Comment.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Comment");
            builder.Property(comment => comment.Description)
                .IsRequired();
            builder.Property(comment => comment.Author)
                .IsRequired();
            builder.Property(b => b.CommentId)
                .HasConversion(
                    v => v.Id,
                    v => new CommentId(v))
                .IsRequired();


            builder.Property(b => b.CreatedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            builder.Property(b => b.ModifiedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(credit => credit.ArticleId)
                 .HasConversion(
                     value => value.Id,
                     value => new ArticleId(value))
                 .IsRequired();

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.Property(b => b.ArticleId)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
