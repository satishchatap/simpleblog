using Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Articles.V1.DeleteArticle
{
    /// <summary>
    /// Delete Article Response
    /// </summary>
    public class DeleteArticleResponse
    {
        /// <summary>
        ///     Delete Article Response constructor.
        /// </summary>
        public DeleteArticleResponse(Article account) => this.ArticleId = account.ArticleId.Id;

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public Guid ArticleId { get; }
    }
}
