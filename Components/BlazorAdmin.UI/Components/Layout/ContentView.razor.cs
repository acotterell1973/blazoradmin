using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAdmin.UI.Components.Layout
{
    public partial class ContentView
    {
        [Inject] private HttpClient Http { get; set; }

        #region Parameters



        /// <summary>
        /// Sets the title for the Content View.
        /// </summary>
        [Parameter] public string ContentTitle { get; set; } = "Title Not Set";

        /// <summary>
        /// Controls the visibility of Search Control for the default Sub Header View.
        /// </summary>
        [Parameter] public bool ShowSearchFilter { get; set; } = false;


        /// <summary>
        /// Set's the visibility of the left content view from the Main body.
        /// </summary>
        public bool ShowLeftContentView { get; set; } = false;

        /// <summary>
        /// Add any additional styles to the left content area.
        /// </summary>
        [Parameter]
        public string LeftContentViewCssClass { get; set; }

        /// <summary>
        /// Add any additional styles to the right content area.
        /// </summary>
        [Parameter]
        public string RightContentViewCssClass { get; set; }

        /// <summary>
        /// Add any additional styles to the main content body area
        /// </summary>
        [Parameter]
        public string ContentBodyViewCssClass { get; set; }

        /// <summary>
        /// Show's the visibility of the right content from Main body.
        /// </summary>
        public bool ShowRightContentView { get; set; } = false;
        /// <summary>
        /// Add any additional styles to the OrderStatusCssClass.
        /// </summary>
        [Parameter]
        public string OrderStatusCssClass { get; set; }

        /// <summary>
        /// Check if need for order number or not.
        /// </summary>
        [Parameter]
        public bool OrderNumberExists { get; set; } = false;
        /// <summary>
        /// Check if need for alert message or not.
        /// </summary>
        [Parameter]
        public bool AlertMessageExists { get; set; } = true;

        //Content Layout Management
        /// <summary>
        /// A Customizable Content Header. If the Content Header is not defined.
        /// A default view for the sub content header will be rendered. 
        /// </summary>
        [Parameter] public RenderFragment ContentHeaderFragment { get; set; }

        /// <summary>
        /// This renders the content left of Content body.
        /// </summary>
        [Parameter] public RenderFragment ContentLeftFragment { get; set; }

        /// <summary>
        /// This is render the main functionality of the Content View.
        /// </summary>
        [Parameter] public RenderFragment ContentBody { get; set; }

        /// <summary>
        /// This renders the content right of Content body.
        /// </summary>
        [Parameter] public RenderFragment ContentRightFragment { get; set; }


        /// <summary>
        /// A Customizable Content Footer. If the Content Footer is not defined.
        /// A default view for the sub content footer will be rendered. 
        /// </summary>
        [Parameter] public RenderFragment ContentFooter { get; set; }

        public ElementReference LeftPanelContainer { get; set; }
        public ElementReference RightPanelContainer { get; set; }


        internal bool DisplayFullBody => (ShowLeftContentView == false && ShowRightContentView == false);

        #endregion

        #region Helper
        private void InitializeComponent()
        {
            // AlertMessages = await Http.GetJsonAsync<List<AlertMessage>>("api/SampleData/AlertMessages");
        }

        public void ToggleLeftContent()
        {

            ShowLeftContentView = !ShowLeftContentView;
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
