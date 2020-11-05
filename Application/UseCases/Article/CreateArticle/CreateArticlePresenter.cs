namespace Application.UseCases.CreateArticle
{
   
     using Domain;

    /// <summary>
    /// </summary>
    public sealed class CreateArticlePresenter : IOutputPort
    {
        public Article? Article { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Article article) => this.Article = article;
    }
}
