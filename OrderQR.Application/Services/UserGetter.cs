using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using OrderQR.Application.Data;
using OrderQR.Application.Interfaces;
using System.Security.Claims;

namespace OrderQR.Application.Services
{
    public class UserGetter : IUserGetter
    {
        private AuthenticationStateProvider _getAuthenticationStateAsync;
        private ClaimsPrincipal _currentUser;
        private UserManager<ApplicationUser> _userManager;

        public UserGetter(AuthenticationStateProvider getAuthenticationStateAsync, UserManager<ApplicationUser> userManager)
        {
            _getAuthenticationStateAsync = getAuthenticationStateAsync;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> Get()
        {
            var authenticationStateTask = _getAuthenticationStateAsync.GetAuthenticationStateAsync();
            _currentUser = (await authenticationStateTask).User;
            if (_currentUser.Identity.IsAuthenticated)
                return await _userManager.GetUserAsync(_currentUser);
            else
                return null;
        }
    }
}
