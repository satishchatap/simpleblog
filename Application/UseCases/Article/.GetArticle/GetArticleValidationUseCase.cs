namespace Application.UseCases.GetArticle
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetArticleValidationUseCase : IGetArticleUseCase
    {
        private readonly IGetArticleUseCase _useCase;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetArticleValidationUseCase" /> class.
        /// </summary>
        public GetArticleValidationUseCase(IGetArticleUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new GetArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(Guid articleId)
        {
            await this._useCase
                .Execute(articleId)
                .ConfigureAwait(false);
        }
    }
}
