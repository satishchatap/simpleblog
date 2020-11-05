using Domain;
using System;

namespace WebApi.Models
{
    /// <summary>
    /// Comment Model
    /// </summary>
    public class CommentModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comment"></param>
        public CommentModel(Comment comment)
        {
            CommentId = comment.CommentId.Id;
            ArticleId = comment.ArticleId.Id;
            Description = comment.Description;
            Author = comment.Author;
            Author = comment.Author;
        }
        /// <summary>
        /// Id
        /// </summary>
        public Guid CommentId { get; }
        /// <summary>
        /// Author
        /// </summary>

        public string Author { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// ArticleId
        /// </summary>
        public Guid ArticleId { get; }
    }
}
