namespace Application.UseCases.ArticleComment
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CommentValidationUseCase : ICommentUseCase
    {
        private readonly ICommentUseCase _useCase;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommentValidationUseCase" /> class.
        /// </summary>
        /// <param name="useCase"></param>
        public CommentValidationUseCase(ICommentUseCase useCase)
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
        public async Task Execute(Guid commentId, string description)
        {
            await this._useCase
                .Execute(commentId, description)
                .ConfigureAwait(false);
        }
    }
}
