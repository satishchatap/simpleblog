

namespace Application.UseCases.EditArticle
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class EditArticleValidationUseCase : IEditArticleUseCase
    {
        private readonly IEditArticleUseCase _useCase;
        private IOutputPort _outputPort;

        public EditArticleValidationUseCase(IEditArticleUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new EditArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(Guid articleId, string title, string body, string summary)
        {          

            await this._useCase
                .Execute(articleId,title, body, summary)
                .ConfigureAwait(false);
        }
    }
}
