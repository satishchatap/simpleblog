namespace WebApi.UseCases.Articles.V1.GetArticles
{
    using Domain;
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Get Articles Response.
    /// </summary>
    public sealed class GetArticlesResponse
    {
        /// <summary>
        ///     The Get Articles Response constructor.
        /// </summary>
        public GetArticlesResponse(IEnumerable<Article> articles)
        {
            foreach (Article article in articles)
            {
                ArticleModel articleModel = new ArticleModel(article);
                this.Articles.Add(articleModel);
            }
        }

        /// <summary>
        ///     Articles
        /// </summary>
        [Required]
        public List<ArticleModel> Articles { get; } = new List<ArticleModel>();
    }
}
