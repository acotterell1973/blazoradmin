using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TwistedCloud.UI.Enums;
using TwistedCloud.UI.EventArgs;
using TwistedCloud.UI.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorAdmin.UI
{
    public partial class TwistedCloudComponent1
    {

        #region Parameters
        //Sample format for template params
        private string _title = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [DefaultValue("Title Not Set")]
        [JsonProperty("title")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                StateHasChanged();
            }
        }

        #endregion

        #region Helper
        private void InitializeComponent()
        {

        }
        #endregion

        #region Page Events
        protected override Task OnInitializedAsync()
        {
            InitializeComponent();
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }


        protected override bool ShouldRender()
        {
            return base.ShouldRender();
        }

        #endregion
    }
}
