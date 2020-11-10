

namespace WebApi.UseCases.Comments.V1
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.ArticleComment;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using Models;
    /// <summary>
    /// Comments
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.CommentArticle)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class CommentsController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;
        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        public CommentsController(Validation validation)
        {
            this._validation = validation;
        }
        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._validation.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Comment comment, Article article) =>
            this._viewModel = this.Ok(new CommentResponse(new CommentModel(comment)));

        /// <summary>
        ///     Comment on an article.
        /// </summary>
        /// <response code="200">The comment details.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="articleId">Article Id.</param>
        /// <param name="description">description.</param>
        /// <returns>The Comment.</returns>

        [Authorize(Policy = "AnyAccess")]
        [HttpPatch("{articleId:guid}/Comment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Patch))]
        public async Task<IActionResult> Comment(
            [FromServices] ICommentUseCase useCase,
            [FromRoute][Required] Guid articleId,
            [FromForm][Required] string description)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(articleId, description)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
