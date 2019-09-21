using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAdmin.UI.Components.Layout
{
    public class ContentViewBase : BaseComponent
    {
        [Parameter]
        public RenderFragment ContentHeader { get; set; }

        [Parameter]
        public RenderFragment ContentBody { get; set; }

        [Parameter]
        public RenderFragment ContentFooter { get; set; }
    }
}
