namespace WebApi.UseCases.Articles.V1.EditArticle
{
    using Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Response for Edit 
    /// </summary>
    public sealed class EditArticleResponse
    {
        /// <summary>
        /// Article
        /// </summary>
        [Required]
        public ArticleModel Article { get; }
        /// <summary>
        /// Response for Edit Constuctor
        /// </summary>
        /// <param name="articleModel"></param>
        public EditArticleResponse(ArticleModel articleModel)
        {
            this.Article = articleModel;
        }
    }
}
