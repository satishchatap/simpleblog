namespace WebApi.Models
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    ///     Article Details.
    /// </summary>
    public sealed class ArticleModel
    {
        /// <summary>
        ///     Article Details constructor.
        /// </summary>
        public ArticleModel(Article article)
        {
            ArticleId = article.ArticleId.Id;
            Title = article.Title;
            Summary = article.Summary;
            Body = article.Body;
            Author = article.Author;
            LikeCount = article.LikeCount;
            CommentCount = article.CommentCount;
            PublishedDate = article.PublishedDate;
            Comments = article
                .Comments
                .Select(e => new CommentModel(e))
                .ToList();

            Likes = article
                .Likes
                .Select(e => new LikeModel(e))
                .ToList();
        }

        /// <summary>
        ///     Gets article ID.
        /// </summary>
        [Required]
        public Guid ArticleId { get; }
        /// <summary>
        /// Summary
        /// </summary>

        [Required]
        public string Summary { get; }
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; }
        /// <summary>
        /// Body
        /// </summary>
        [Required]
        public string Body { get; }
        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; }
        /// <summary>
        /// Published Date
        /// </summary>
        public DateTime PublishedDate { get; }

        /// <summary>
        ///     Gets Comments.
        /// </summary>        
        public List<CommentModel> Comments { get; }

        /// <summary>
        ///     Gets Likes.
        /// </summary>
        public List<LikeModel> Likes { get; }
        /// <summary>
        /// Total Likes
        /// </summary>
        public int LikeCount { get; }

        /// <summary>
        /// Total Comments
        /// </summary>
        public int CommentCount { get; }
    }
}
