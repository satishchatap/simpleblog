namespace WebApi.UseCases.Articles.V1.GetArticle
{
    using Domain;
    using System.ComponentModel.DataAnnotations;
    using WebApi.Models;

    /// <summary>
    ///     Get Article Response.
    /// </summary>
    public sealed class GetArticleResponse
    {
        /// <summary>
        ///     The Get Article Response constructor.
        /// </summary>
        public GetArticleResponse(Article article) => this.Article = new ArticleModel(article);

        /// <summary>
        ///     Gets article ID.
        /// </summary>
        [Required]
        public ArticleModel Article { get; }
    }
}
