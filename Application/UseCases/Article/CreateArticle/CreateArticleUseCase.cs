namespace Application.UseCases.CreateArticle
{
    using Domain;
    using Services;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CreateArticleUseCase : ICreateArticleUseCase
    {
        private readonly IArticleFactory _articleFactory;
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        public CreateArticleUseCase(
            IArticleRepository articleRepository,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IArticleFactory articleFactory)
        {
            this._articleRepository = articleRepository;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._articleFactory = articleFactory;
            this._outputPort = new CreateArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(string title, string body, string summary) =>
            this.CreateArticle(title, body, summary);

        private async Task CreateArticle(string title, string body, string summary)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            Article article = this._articleFactory
                .NewArticle( title, body, summary,externalUserId);
            article.Audit(externalUserId, AuditType.Add);
            await this.Article(article)
                .ConfigureAwait(false);

            this._outputPort?.Ok(article);
        }

        private async Task Article(Article article)
        {
            await this._articleRepository
                .Add(article)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
