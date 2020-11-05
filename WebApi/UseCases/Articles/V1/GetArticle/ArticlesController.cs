namespace WebApi.UseCases.Articles.V1.GetArticle
{
    using Application.Services;
    using Application.UseCases.GetArticle;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

  /// <summary>
  /// Articles
  /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.GetArticle)]
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

        void IOutputPort.Ok(Article article) => this._viewModel = this.Ok(new GetArticleResponse(article));

        /// <summary>
        ///     Get an article details.
        /// </summary>
        /// <response code="200">The Article.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="articleId"></param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet("{articleId:guid}", Name = "GetArticle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetArticleResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Get(
            [FromServices] IGetArticleUseCase useCase,
            [FromRoute][Required] Guid articleId)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(articleId)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
