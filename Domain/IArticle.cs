using Domain.ValueObjects;
using System;

namespace Domain
{
    public interface IArticle
    {

        /// <summary>
        ///     Gets Id.
        /// </summary>
        ArticleId ArticleId { get; }
        string Author { get; set; }
        string Title { get; }
        string Summary { get; }
        string Body { get; }
        DateTime CreatedOn { get; }
        DateTime ModifiedOn { get; }
        string CreatedBy { get; }
        string ModifiedBy { get; }
        byte[] RowVersion { get; }
        public DateTime PublishedDate { get; }

        /// <summary>
        ///    Comment on Article
        /// </summary>
        /// <returns>Comment created.</returns>
        void Comment(Comment comment);

        /// <summary>
        ///    Like Article
        /// </summary>
        /// <returns>Like created.</returns>
        void Like(Like like);

       /// <summary>
       ///  Like Count
       /// </summary>
        int LikeCount { get; }
        /// <summary>
        /// Comment Count
        /// </summary>
        int CommentCount { get; }

    }
}
