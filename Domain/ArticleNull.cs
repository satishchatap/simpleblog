using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    using ValueObjects;

    /// <inheritdoc />
    public sealed class ArticleNull : IArticle
    {
        public static ArticleNull Instance { get; } = new ArticleNull();

        /// <inheritdoc />
        public ArticleId ArticleId => new ArticleId(Guid.Empty);
        /// <inheritdoc />
        public string Author { get; set; }
        /// <inheritdoc />
        public string Title { get; }
        /// <inheritdoc />
        public string Summary { get; }
        /// <inheritdoc />
        public string Body { get; }
        /// <inheritdoc />
        public DateTime CreatedOn { get; private set; }
        /// <inheritdoc />
        public DateTime ModifiedOn { get; private set; }
        /// <inheritdoc />
        public string CreatedBy { get; private set; }
        /// <inheritdoc />
        public string ModifiedBy { get; private set; }
        /// <inheritdoc />
        public byte[] RowVersion { get; }
        /// <inheritdoc />
        public DateTime PublishedDate { get; }
        /// <inheritdoc />
        public int LikeCount => 0;
        /// <inheritdoc />
        public int CommentCount => 0;
        /// <inheritdoc />
        public void Comment(Comment comment)
        {
            // Null Pattern
        }
        /// <inheritdoc />
        public void Like(Like like)
        {
            // Null Pattern
        }
    }
}
