using Domain;

namespace Application.UseCases.ArticleLike
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
        ///     like
        /// </summary>
        void Ok(Like like, Article article);

        /// <summary>
        ///     Not found.
        /// </summary>
        void NotFound();
    }
}
