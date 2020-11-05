namespace Application.Services
{
    /// <summary>
    ///     User Service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Gets the Current User Id.
        /// </summary>
        /// <returns>User.</returns>
        string GetCurrentUserId();
        /// <summary>
        /// Get Current User Permissions
        /// </summary>
        /// <returns></returns>
        string[] GetCurrentUserPermissions();
    }
}
