namespace Application.UseCases.DeleteArticle
{
    using Domain;
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class DeleteArticleUseCase : IDeleteArticleUseCase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteArticleUseCase" /> class.
        /// </summary>
        /// <param name="articleRepository">Article Repository.</param>
        /// <param name="userService">User Service.</param>
        /// <param name="unitOfWork"></param>
        public DeleteArticleUseCase(
            IArticleRepository articleRepository,
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            this._articleRepository = articleRepository;
            this._userService = userService;
            this._unitOfWork = unitOfWork;
            this._outputPort = new DeleteArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid articleId)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            return this.DeleteArticleInternal(new ArticleId(articleId), externalUserId);
        }

        private async Task DeleteArticleInternal(ArticleId articleId, string externalUserId)
        {
            IArticle article = await this._articleRepository
                .Find(articleId, externalUserId)
                .ConfigureAwait(false);

            if (article is Article deleteArticle)
            {
                await this.Delete(deleteArticle)
                    .ConfigureAwait(false);

                this._outputPort.Ok(deleteArticle);
                return;
            }

            this._outputPort.NotFound();
        }

        private async Task Delete(Article deleteArticle)
        {
            await this._articleRepository
                .DeleteAsyc(deleteArticle.ArticleId)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
