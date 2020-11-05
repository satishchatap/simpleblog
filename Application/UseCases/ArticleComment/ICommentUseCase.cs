using System;
using System.Threading.Tasks;

namespace Application.UseCases.ArticleComment
{
    public interface ICommentUseCase
    {
        /// <summary>
        ///  Executes the Use Case.
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task Execute(Guid articleId,  string description);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
