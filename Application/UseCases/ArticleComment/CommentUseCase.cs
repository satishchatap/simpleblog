namespace Application.UseCases.ArticleComment
{
    using Domain;
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CommentUseCase : ICommentUseCase
    {
        private readonly IArticleFactory _articleFactory;
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommentUseCase" /> class.
        /// </summary>
        /// <param name="articleRepository">Article Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        /// <param name="userService"></param>
        /// <param name="articleFactory"></param>
        public CommentUseCase(
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
        public Task Execute(Guid articleId, string description) =>
            this.Comment(
                new ArticleId(articleId),
                description);

        private async Task Comment(ArticleId articleId, string description)
        {
            IArticle article = await this._articleRepository
                .GetArticle(articleId)
                .ConfigureAwait(false);

            if (article is Article commentArticle)
            {
                Comment comment = this._articleFactory
              .NewComment(commentArticle.ArticleId, description,_userService.GetCurrentUserId());

                await this.Comment(commentArticle, comment)
                    .ConfigureAwait(false);

                this._outputPort.Ok(comment, commentArticle);
                return;
            }

            this._outputPort.NotFound();
        }

        private async Task Comment(Article article,Comment comment)
        {
           
            await this._articleRepository
                .Update(article, comment)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
