namespace WebApi.UseCases.CustomErrors.V1
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Constructor
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class CustomErrorController : Controller
    {
        /// <summary>
        ///     Get an custom error.
        /// </summary>
        /// <returns>The custom error model.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomError()
        {
            CustomErrorResponse model =
                new CustomErrorResponse { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier };

            return this.View("~/UseCases/CustomError/V1/CustomError.cshtml", model);
        }
    }
}
