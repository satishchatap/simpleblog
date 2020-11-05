namespace WebApi.UseCases.Articles.V1.GetAllArticles
{
    using Domain;
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Get Articles Response.
    /// </summary>
    public sealed class GetAllArticlesResponse
    {
        /// <summary>
        ///     The Get Articles Response constructor.
        /// </summary>
        public GetAllArticlesResponse(IEnumerable<Article> articles)
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
