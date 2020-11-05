namespace Application.UseCases.GetAllArticles
{
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Listed articles.
        /// </summary>
        void Ok(IList<Article> articles);
    }
}
