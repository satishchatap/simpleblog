namespace WebApi.UseCases.CustomErrors.V1
{
    /// <summary>
    ///     Custom Error Response
    /// </summary>
    public sealed class CustomErrorResponse
    {
        /// <summary>
        ///     Gets Request Id.
        /// </summary>
        public string RequestId { get; set; } = string.Empty;

        /// <summary>
        ///     Verify if RequestId is null or empty.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
