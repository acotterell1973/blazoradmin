using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace BlazorAdmin.UI
{
    public class BaseComponent : ComponentBase, IDisposable
    {

        
        

        public ElementReference HtmlReference;

        #region Injected Property
        [Inject] internal Shared.AppState AppState { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Inject] public JavascriptConnector javascriptConnector { get; set; }

        #endregion

        #region Parameters
        [CascadingParameter]
        private Task<AuthenticationState> AppAuthenticationState { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string Text { get; set; }

        #endregion

        #region properties
        [Parameter]
        public string Id { get; set; }

        protected ClaimsPrincipal AuthUser { get; set; }
        private string _cssClass { get; set; } = "";
        /// <summary>
        /// specifies the css class name that can be appended with root element of the dialog.
        /// one or more custom css classes can be added to a dialog.
        /// </summary>
        [Parameter]
        [DefaultValue("")]
        [JsonProperty("cssclass")]
        public string CssClass
        {
            get => _cssClass;
            set
            {
                if (CompareValues(_cssClass, value))
                {
                    return;
                }
                _cssClass = value;
                StateHasChanged();
            }
        }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> HtmlAttributes { get; set; }

        #endregion


        /// <summary>
        /// returns true if both values are equal.
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        protected bool CompareValues(object oldValue, object newValue)
        {
            //https://stackoverflow.com/questions/10454519/best-way-to-compare-two-complex-objects
            if (ReferenceEquals(oldValue, newValue)) return true;
            if ((oldValue == null) || (newValue == null)) return false;
            if (oldValue.GetType() != newValue.GetType()) return false;

            var oldValueJson = JsonConvert.SerializeObject(oldValue);
            var newValueJson = JsonConvert.SerializeObject(newValue);

            return oldValueJson == newValueJson;


        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }



        public void Dispose()
        {
            throw new NotImplementedException("If we can an error. Look at what's calling dispose and handle appropriately.");
        }
    }
}
