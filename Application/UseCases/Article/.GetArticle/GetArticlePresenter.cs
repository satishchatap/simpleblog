namespace Application.UseCases.GetArticle
{
    using Domain;
    public sealed class GetArticlePresenter : IOutputPort
    {
        public Article? Article { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Ok(Article article)
        {
            this.Article = article;
        }
    }
}
