using System;
using System.Threading.Tasks;

namespace Application.UseCases.EditArticle
{
    public interface IEditArticleUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        Task Execute(Guid articleId,string title, string body, string summary);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
