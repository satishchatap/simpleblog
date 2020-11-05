using System.Threading.Tasks;

namespace Application.UseCases.CreateArticle
{
    public interface ICreateArticleUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        Task Execute(string title, string body, string summary);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
