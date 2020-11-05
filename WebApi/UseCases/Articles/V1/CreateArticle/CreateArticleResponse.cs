namespace WebApi.UseCases.Articles.V1.CreateArticle
{
    using Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Response for Create 
    /// </summary>
    public sealed class CreateArticleResponse
    {
        /// <summary>
        /// Article
        /// </summary>
        [Required]
        public ArticleModel Article { get; }
        /// <summary>
        /// Response for Create Constuctor
        /// </summary>
        /// <param name="articleModel"></param>
        public CreateArticleResponse(ArticleModel articleModel)
        {
            this.Article = articleModel;
        }
    }
}
