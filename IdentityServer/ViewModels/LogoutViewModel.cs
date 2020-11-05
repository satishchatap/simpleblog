using IdentityServer.Models;

namespace IdentityServer.ViewModels
{
    public class LogoutViewModel : LogOutModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
