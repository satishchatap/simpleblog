using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetArticle
{
    public interface IGetArticleUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        /// <param name="articleId">Account Id.</param>
        Task Execute(Guid articleId);

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="outputPort"></param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
