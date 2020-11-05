namespace Application.UseCases.DeleteArticle
{
    using System;
    using System.Threading.Tasks;
    using Services;

    /// <inheritdoc />
    public sealed class DeleteArticleValidationUseCase : IDeleteArticleUseCase
    {
        private readonly IDeleteArticleUseCase _useCase;
        private readonly Validation _validation;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteArticleValidationUseCase" /> class.
        /// </summary>
        public DeleteArticleValidationUseCase(IDeleteArticleUseCase useCase, Validation validation)
        {
            this._useCase = useCase;
            this._validation = validation;
            this._outputPort = new DeleteArticlePresenter();
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
            if (articleId == Guid.Empty)
            {
                this._validation
                    .Add(nameof(articleId), "AccountId is required.");
            }

            if (!this._validation
                .IsValid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(articleId)
                .ConfigureAwait(false);
        }
    }
}
