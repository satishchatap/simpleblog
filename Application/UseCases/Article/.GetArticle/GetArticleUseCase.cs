

namespace Application.UseCases.GetArticle
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Domain.ValueObjects;

    /// <inheritdoc />
    public sealed class GetArticleUseCase : IGetArticleUseCase
    {
        private readonly IArticleRepository _articleRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetArticleUseCase" /> class.
        /// </summary>
        /// <param name="articleRepository">Article Repository.</param>
        public GetArticleUseCase(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
            this._outputPort = new GetArticlePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid articleId) =>
            this.GetArticleInternal(new ArticleId(articleId));

        private async Task GetArticleInternal(ArticleId articleId)
        {
            IArticle article = await this._articleRepository
                .GetArticle(articleId)
                .ConfigureAwait(false);

            if (article is Article getArticle)
            {
                this._outputPort.Ok(getArticle);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}
