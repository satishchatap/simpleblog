namespace Application.UseCases.GetArticle
{
    using Domain;
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
        ///     Article closed.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Article closed.
        /// </summary>
        void Ok(Article article);
    }
}
