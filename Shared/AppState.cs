using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAdmin.Shared
{
    public class AppState
    {
        public event Action OnChange;
        public bool IsLeftPanelOpen { get; set; } = false;
        public bool IsRightPanelOpen { get; set; } = false;
        public string CssClassString { get; set; } = "default-css-class-string-11111111";

        public void OpenLeftPanel()
        {
            IsLeftPanelOpen = true;
            NotifyStateChanged();
        }
        public void CloseLeftPanel()
        {
            IsLeftPanelOpen = false;
            NotifyStateChanged();
        }
        public void ToggleLeftPanel()
        {
            IsLeftPanelOpen = !IsLeftPanelOpen;
            NotifyStateChanged();
        }

        public void OpenRightPanel()
        {
            IsRightPanelOpen = true;
            NotifyStateChanged();
        }
        public void CloseRightPanel()
        {
            IsRightPanelOpen = false;
            NotifyStateChanged();
        }
        public void ToggleRightPanel()
        {
            if (IsRightPanelOpen)
            {
                CloseRightPanel();
            }
            else
            {
                OpenRightPanel();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
