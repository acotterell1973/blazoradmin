using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAdmin.UI
{
    public class JavascriptConnector
    {
        private IJSRuntime JsRuntime { get; }
        public JavascriptConnector(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
        }

        #region Dialog Component Interop

        public async ValueTask<bool> ShowDialog(ElementReference element)
        {
            return await JsRuntime.InvokeAsync<bool>("window.RadialJsDialog.showDialog", element);
        }


        public void AllowDrag(ElementReference element)
        {
            JsRuntime.InvokeVoidAsync("window.RadialJsDialog.allowDrag", element);
        }
        #endregion


    }
}
