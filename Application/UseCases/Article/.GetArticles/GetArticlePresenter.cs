namespace Application.UseCases.GetArticles
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetArticlePresenter : IOutputPort
    {
        public IList<Article>? Articles { get; private set; }
        public void Ok(IList<Article> articles) => this.Articles = articles;
    }
}
