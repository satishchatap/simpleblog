namespace Infrastructure.Authentication
{
    using Application.Services;
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using System.Security.Claims;

    /// <inheritdoc />
    public sealed class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public UserService(
            IHttpContextAccessor httpContextAccessor) =>
            this._httpContextAccessor = httpContextAccessor;

        /// <inheritdoc />
        public string GetCurrentUserId()
        {
            ClaimsPrincipal user = this._httpContextAccessor
                .HttpContext
                .User;
            string id = user.FindFirst("sub")?.Value!;
            return id;
        }
        public string[] GetCurrentUserPermissions()
        {
            ClaimsPrincipal user = this._httpContextAccessor
                .HttpContext
                .User;

            string aud = user.FindFirst("aud")?.Value!;
            var permissions=user.FindAll("scope").Where(s => s.Value.StartsWith(aud)).Select(a=>a.Value);
            return permissions!.ToArray();
        }
    }
}
