namespace WebApi.UseCases.Articles.V1.GetAllArticles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.GetAllArticles;
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
    [FeatureGate(CustomFeature.GetAllArticles)]
    [Route("api/v{version:apiVersion}/[controller]/GetAll")]
    [ApiController]
    public sealed class ArticlesController : ControllerBase, IOutputPort
    {
        private readonly IGetAllArticlesUseCase _useCase;

        private IActionResult? _viewModel;

        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="useCase"></param>
        public ArticlesController(Validation validation, IGetAllArticlesUseCase useCase)
        {
            this._validation = validation;
            this._useCase = useCase;
        }

        void IOutputPort.Ok(IList<Article> articles) => this._viewModel = this.Ok(new GetAllArticlesResponse(articles));

        /// <summary>
        ///     Get Articles.
        /// </summary>
        /// <response code="200">The List of Articles.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllArticlesResponse))]
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
