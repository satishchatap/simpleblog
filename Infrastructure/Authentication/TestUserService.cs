using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Authentication
{
    using Application.Services;
    using DataAccess;

    /// <inheritdoc />
    public sealed class TestUserService : IUserService
    {
        /// <inheritdoc />
        public string GetCurrentUserId() => SeedData.DefaultAuthor;

        public string[] GetCurrentUserPermissions()=> SeedData.DefaultPermission;
    }
}
