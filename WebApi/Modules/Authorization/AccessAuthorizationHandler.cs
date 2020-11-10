using Application.Services;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Modules.Authorization
{
    internal class AccessAuthorizationHandler : AuthorizationHandler<AccessRightRequirement>
    {
        private readonly IUserService _userService;
        public AccessAuthorizationHandler(IUserService userService)
        {
            _userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRightRequirement requirement)
        {
            var permissions =_userService.GetCurrentUserPermissions();
            if (requirement.AcessRight.IndexOf(',') < 0)
            {
                //check access
                if (permissions != null && permissions.Contains(requirement.AcessRight))
                {
                    // Mark the requirement as satisfied
                    context.Succeed(requirement);
                }
            }else
            {
                var requested = requirement.AcessRight.Split(',');
                //check access
                if (permissions != null && permissions.Any(p=>requested.Contains(p)))
                {
                    // Mark the requirement as satisfied
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
