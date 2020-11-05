namespace WebApi.UseCases.Articles.V1.EditArticle
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.EditArticle;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using Models;
    using System;

    /// <summary>
    /// Articles
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.EditArticle)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class ArticlesController : ControllerBase, IOutputPort
    {
      
        private IActionResult? _viewModel; 
        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        public ArticlesController(Validation validation)
        {
            this._validation = validation;
        }
        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._validation.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }


        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Article article) =>
            this._viewModel = this.Ok(new EditArticleResponse(new ArticleModel(article)));

        /// <summary>
        ///     Edit an article.
        /// </summary>
        /// <response code="200">Article already exists,</response>
        /// <response code="201">The article was created successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <param name="articleId">article id.</param>
        /// <param name="useCase">Use case.</param>
        /// <param name="title"></param>
        /// <param name="summary"></param>
        /// <param name="body"></param>
        /// <returns>The newly created article.</returns>
        [Authorize]
        [HttpPatch("{articleId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EditArticleResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EditArticleResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> Patch([FromRoute][Required] Guid articleId,
            [FromServices] IEditArticleUseCase useCase,
            [FromForm][Required] string title,
            [FromForm][Required] string summary,
            [FromForm][Required] string body)
        {
            useCase.SetOutputPort(this);
            await useCase.Execute(articleId,title,summary,body)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
