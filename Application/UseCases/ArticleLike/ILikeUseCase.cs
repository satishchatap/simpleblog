using System;
using System.Threading.Tasks;

namespace Application.UseCases.ArticleLike
{
    public interface ILikeUseCase
    {
        /// <summary>
        ///  Executes the Use Case.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task Execute(Guid articleId);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
