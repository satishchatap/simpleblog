using Microsoft.AspNetCore.Authorization;

namespace WebApi.Modules.Authorization
{
    internal class AccessRightRequirement : IAuthorizationRequirement
    {
        public AccessRightRequirement(string accessRight)
        {
            AcessRight = accessRight;
        }

        public string AcessRight { get; private set; }
    }
}
