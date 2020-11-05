namespace Application.UseCases.EditArticle
{
    using Domain;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class EditArticleUseCase : IEditArticleUseCase
    {
       
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        public EditArticleUseCase(
            IArticleRepository articleRepository,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            this._articleRepository = articleRepository;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._outputPort = new EditArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid articleId, string title, string body, string summary) =>
            this.EditArticle(articleId,title, body, summary);

        private async Task EditArticle(Guid articleId,string title, string body, string summary)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();
            var domainArticleId = new Domain.ValueObjects.ArticleId(articleId);
            var articleExisting =await this._articleRepository.GetArticle(domainArticleId)
                .ConfigureAwait(false);

            var article = new Article(articleExisting.ArticleId, title, body, summary, externalUserId);

            article.Audit(externalUserId, AuditType.Modify);

            await this.Article(article)
                .ConfigureAwait(false);

            this._outputPort?.Ok(article);
        }

        private async Task Article(Article article)
        {
            await this._articleRepository
                .Update(article)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
