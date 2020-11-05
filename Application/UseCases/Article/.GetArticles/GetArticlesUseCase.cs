namespace Application.UseCases.GetArticles
{
    using Domain;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetArticlesUseCase : IGetArticlesUseCase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserService _userService;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetArticlesUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="articleRepository">Customer Repository.</param>
        public GetArticlesUseCase(
            IUserService userService,
            IArticleRepository articleRepository)
        {
            this._userService = userService;
            this._articleRepository = articleRepository;
            this._outputPort = new GetArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            return this.GetArticles(externalUserId);
        }

        private async Task GetArticles(string externalUserId)
        {
            IList<Article>? articles = await this._articleRepository
                .GetArticles(externalUserId)
                .ConfigureAwait(false);

            this._outputPort.Ok(articles);
        }
    }
}
