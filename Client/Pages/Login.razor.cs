using BlazorAdmin.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BlazorAdmin.Client.Pages
{
    public class LoginBase : BaseComponent
    {
        [Inject] private IJSRuntime _jsRuntime { get; set; }

        [Inject] private NavigationManager UriHelper { get; set; }
        [Inject] private AuthenticationStateProvider AuthenticationProvider { get; set; }

        AuthenticationState AuthState;
        #region Event Handlers
        public async Task OnLoginClickAsync()
        {

            AuthState = await AuthenticationProvider.GetAuthenticationStateAsync();
            System.Diagnostics.Debug.Print($"AuthState {AuthState.User.Identity.Name} ");
            UriHelper.NavigateTo("dashboard");

        }

        protected override async Task OnInitializedAsync()
        {


            AuthState = await AuthenticationProvider.GetAuthenticationStateAsync();
        }
        #endregion
    }
}
