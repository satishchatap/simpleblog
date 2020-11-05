namespace Application.UseCases.ArticleLike
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class LikeValidationUseCase : ILikeUseCase
    {
        private readonly ILikeUseCase _useCase;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LikeValidationUseCase" /> class.
        /// </summary>
        /// <param name="useCase"></param>
        public LikeValidationUseCase(ILikeUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new LikePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(Guid likeId)
        {
            await this._useCase
                .Execute(likeId)
                .ConfigureAwait(false);
        }
    }
}
