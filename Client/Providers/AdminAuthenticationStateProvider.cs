using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorAdmin.Client.Providers
{
    public class AdminAuthenticationStateProvider : AuthenticationStateProvider
    {
        string UserId;
        string Password;

        public void LoadUser(string _UserId, string _Password)
        {
            UserId = _UserId;
            Password = _Password;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //   var securityService = new SharedServiceLogic.Security();

            // var userService = new UserService();

            // var validPassword = await securityService.ValidatePassword(UserId, Password);

            var authenticated = true;// validPassword == true ? true : false;


            var identity = authenticated
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,"Andrew") },"Fake Auth Type.")
                : new ClaimsIdentity();

            var result = new AuthenticationState(new ClaimsPrincipal(identity));

            return await Task.FromResult(result);
        }

    }
}
