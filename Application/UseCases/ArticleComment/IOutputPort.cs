using Domain;

namespace Application.UseCases.ArticleComment
{
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();

        /// <summary>
        ///     comment
        /// </summary>
        void Ok(Comment comment, Article article);

        /// <summary>
        ///     Not found.
        /// </summary>
        void NotFound();
    }
}
