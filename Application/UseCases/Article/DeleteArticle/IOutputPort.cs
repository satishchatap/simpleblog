using Domain;

namespace Application.UseCases.DeleteArticle
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
        ///     Article deleted successfully.
        /// </summary>
        void Ok(Article account);

        /// <summary>
        ///     Article not found.
        /// </summary>
        void NotFound();
    }
}
