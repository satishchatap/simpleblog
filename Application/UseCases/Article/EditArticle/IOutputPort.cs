namespace Application.UseCases.EditArticle
{
    using Domain;

    /// <summary>
    ///     Open Article Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Article open.
        /// </summary>
        void Ok(Article article);

        /// <summary>
        ///     Resource not found.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();
    }
}
