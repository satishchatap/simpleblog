namespace Application.UseCases.GetAllArticles
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetAllArticlePresenter : IOutputPort
    {
        public IList<Article>? Articles { get; private set; }
        public void Ok(IList<Article> articles) => this.Articles = articles;
    }
}
