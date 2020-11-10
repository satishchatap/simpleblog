namespace WebApi.UseCases.Articles.V1.GetArticles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.GetArticles;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;

    /// <summary>
    /// Articles
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.GetArticles)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class ArticlesController : ControllerBase, IOutputPort
    {
        private readonly IGetArticlesUseCase _useCase;

        private IActionResult? _viewModel;

        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="useCase"></param>
        public ArticlesController(Validation validation, IGetArticlesUseCase useCase)
        {
            this._validation = validation;
            this._useCase = useCase;
        }

        void IOutputPort.Ok(IList<Article> articles) => this._viewModel = this.Ok(new GetArticlesResponse(articles));

        /// <summary>
        ///     Get Articles.
        /// </summary>
        /// <response code="200">The List of Articles.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize(Policy = "FullAccess")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetArticlesResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get()
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute()
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
