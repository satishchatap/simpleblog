using Domain;

namespace Application.UseCases.DeleteArticle
{
    /// <summary>
    /// Delete Article Presenter
    /// </summary>
    public sealed class DeleteArticlePresenter : IOutputPort
    {
        public Article? Article { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Article article) => this.Article = article;
    }
}
