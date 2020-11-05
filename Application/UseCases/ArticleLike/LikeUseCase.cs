namespace Application.UseCases.ArticleLike
{
    using Domain;
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class LikeUseCase : ILikeUseCase
    {
        private readonly IArticleFactory _articleFactory;
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LikeUseCase" /> class.
        /// </summary>
        /// <param name="articleRepository">Article Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        /// <param name="userService"></param>
        /// <param name="articleFactory"></param>
        public LikeUseCase(
            IArticleRepository articleRepository,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IArticleFactory articleFactory)
        {
            this._articleRepository = articleRepository;
            this._unitOfWork = unitOfWork;
            this._articleFactory = articleFactory;
            this._userService = userService;
            this._outputPort = new LikePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid articleId) =>
            this.Like(
                new ArticleId(articleId));

        private async Task Like(ArticleId articleId)
        {
            IArticle article = await this._articleRepository
                .GetArticle(articleId)
                .ConfigureAwait(false);

            if (article is Article likeArticle)
            {
                Like like = this._articleFactory
              .NewLike(_userService.GetCurrentUserId(), likeArticle.ArticleId);

                await this.Like(likeArticle, like)
                    .ConfigureAwait(false);

                this._outputPort.Ok(like, likeArticle);
                return;
            }

            this._outputPort.NotFound();
        }

        private async Task Like(Article article,Like like)
        {
           
            await this._articleRepository
                .Update(article, like)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
