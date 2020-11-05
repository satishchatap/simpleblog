namespace WebApi.UseCases.Comments.V1
{
    using Models;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The response for a successful Comment.
    /// </summary>
    public sealed class CommentResponse
    {
        /// <summary>
        ///     The Comment response constructor.
        /// </summary>
        public CommentResponse(CommentModel comment) => this.Comment = comment;

        /// <summary>
        ///     Gets Comment.
        /// </summary>
        [Required]
        public CommentModel Comment { get; }
    }
}
