using System.Threading.Tasks;

namespace BlazorAdmin.UI.Components.SelectList
{
    public class SelectListBase : BaseComponent
    {
        #region Parameters

        public bool ToggleDropdown { get; set; }
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
