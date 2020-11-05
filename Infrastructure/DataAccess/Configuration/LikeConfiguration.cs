namespace Infrastructure.DataAccess.Configuration
{
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    ///     Like Configuration.
    /// </summary>
    public sealed class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        /// <summary>
        ///     Configure Like.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Like");
            builder.Property(like => like.Author)
                .IsRequired();
            builder.Property(b => b.LikeId)
                .HasConversion(
                    v => v.Id,
                    v => new LikeId(v))
                .IsRequired();


            builder.Property(b => b.CreatedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            builder.Property(b => b.ModifiedOn)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(like => like.ArticleId)
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
