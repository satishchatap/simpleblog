namespace WebApi.UseCases.Likes.V1
{
    using Application.Services;
    using Application.UseCases.ArticleLike;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Models;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    /// <summary>
    /// Likes
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.LikeArticle)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class LikesController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;
        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        public LikesController(Validation validation)
        {
            this._validation = validation;
        }
        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._validation.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Like comment, Article article) =>
            this._viewModel = this.Ok(new LikeResponse(new LikeModel(comment)));

        /// <summary>
        ///     Like on an article.
        /// </summary>
        /// <response code="200">The like details.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="articleId">Article Id.</param>
        /// <returns>The Like.</returns>
        [Authorize]
        [HttpPatch("{articleId:guid}/Like")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LikeResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Patch))]
        public async Task<IActionResult> Like(
            [FromServices] ILikeUseCase useCase,
            [FromRoute][Required] Guid articleId)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(articleId)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
