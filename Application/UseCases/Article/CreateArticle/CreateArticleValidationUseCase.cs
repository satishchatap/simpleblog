

namespace Application.UseCases.CreateArticle
{
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CreateArticleValidationUseCase : ICreateArticleUseCase
    {
        private readonly ICreateArticleUseCase _useCase;
        private IOutputPort _outputPort;

        public CreateArticleValidationUseCase(ICreateArticleUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new CreateArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(string title, string body, string summary)
        {          

            await this._useCase
                .Execute(title, body, summary)
                .ConfigureAwait(false);
        }
    }
}
