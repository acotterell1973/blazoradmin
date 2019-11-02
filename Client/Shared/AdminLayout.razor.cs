using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAdmin.Client.Shared
{
    public class AdminLayoutBase : LayoutComponentBase
    {
        [Inject] BlazorAdmin.Shared.AppState AppState { get; set; }

        protected override Task OnInitializedAsync()
        {
            AppState.OnChange += StateHasChanged;
            return base.OnInitializedAsync();
        }
    }
}
