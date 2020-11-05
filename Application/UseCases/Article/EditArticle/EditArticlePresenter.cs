namespace Application.UseCases.EditArticle
{
   
     using Domain;

    /// <summary>
    /// </summary>
    public sealed class EditArticlePresenter : IOutputPort
    {
        public Article? Article { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Article article) => this.Article = article;
    }
}
