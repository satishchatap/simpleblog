using Application.Services;
using Application.UseCases.DeleteArticle;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApi.Modules.Common;
using WebApi.Modules.Common.FeatureFlags;

namespace WebApi.UseCases.Articles.V1.DeleteArticle
{
    /// <summary>
    /// Articles 
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.DeleteArticle)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class ArticlesController : ControllerBase, IOutputPort
    {
        private readonly IDeleteArticleUseCase _useCase;
        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="validation"></param>
        public ArticlesController(IDeleteArticleUseCase useCase, Validation validation)
        {
            this._useCase = useCase;
            this._validation = validation;
        }

        private IActionResult? _viewModel;

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._validation.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        

        void IOutputPort.Ok(Article article) => this._viewModel = this.Ok(new DeleteArticleResponse(article));

        /// <summary>
        ///     Delete an Article.
        /// </summary>
        /// <response code="200">The closed article id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="articleId">The ArticleId.</param>
        /// <returns>ViewModel.</returns>
        [Authorize(Policy = "FullAccess")]
        [HttpDelete("{articleId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteArticleResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Delete(
            [FromRoute][Required] Guid articleId)
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(articleId)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
