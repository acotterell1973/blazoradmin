using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAdmin.UI
{
    public class BaseComponent : ComponentBase, IDisposable
    {

        [Parameter]
        public string Text { get; set; }


        public virtual string Id { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> HtmlAttributes { get; set; }

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

        public void Dispose()
        {
            throw new NotImplementedException("If we can an error. Look at what's calling dispose and handle appropriately.");
        }
    }
}
