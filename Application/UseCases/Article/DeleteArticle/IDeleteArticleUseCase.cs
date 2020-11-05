using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteArticle
{
    /// <summary>
    /// Delete Article use Case
    /// </summary>
    public interface IDeleteArticleUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <param name="articleId">Article Id.</param>
        /// <returns>Task.</returns>
        Task Execute(Guid articleId);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
