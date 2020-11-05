using Domain;
using System;

namespace WebApi.Models
{
    /// <summary>
    /// Like Model
    /// </summary>
    public class LikeModel
    {      
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="like"></param>
        public LikeModel(Like like)
        {
            LikeId = like.LikeId.Id;
            ArticleId = like.ArticleId.Id;
            Author = like.Author;
        }
        /// <summary>
        /// Id
        /// </summary>
        public Guid LikeId { get; }
        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Article Id
        /// </summary>
        public Guid ArticleId { get; }
    }
}
