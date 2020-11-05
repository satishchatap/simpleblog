namespace Application.UseCases.GetAllArticles
{
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetAllArticlesUseCase : IGetAllArticlesUseCase
    {
        private readonly IArticleRepository _articleRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAllArticlesUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="articleRepository">Customer Repository.</param>
        public GetAllArticlesUseCase(
            IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
            this._outputPort = new GetAllArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            return this.GetAllArticles();
        }

        private async Task GetAllArticles()
        {
            IList<Article>? articles = await this._articleRepository
                .GetAllArticles()
                .ConfigureAwait(false);

            this._outputPort.Ok(articles);
        }
    }
}
