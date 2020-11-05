namespace WebApi.UseCases.Likes.V1
{
    using Models;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The response for a successful Like.
    /// </summary>
    public sealed class LikeResponse
    {
        /// <summary>
        ///     The Like response constructor.
        /// </summary>
        public LikeResponse(LikeModel like) => this.Like = like;

        /// <summary>
        ///     Gets Like.
        /// </summary>
        [Required]
        public LikeModel Like { get; }
    }
}
