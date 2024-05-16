using System;
using Win32Interop.Structs;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Contains information on mouse events captured by
    /// <see cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.MouseHookCallback" /> and
    /// processed by
    /// <see cref="M:xyLOGIX.EasyTabs.TitleBarTabsOverlay.InterpretMouseEvents" />.
    /// </summary>
    public class MouseEvent
    {
        /// <summary>Code for the event.</summary>
        public int Code { get; set; }

        /// <summary>LParam value associated with the event.</summary>
        public IntPtr LParam { get; set; }

        /// <summary>Data associated with the mouse event.</summary>
        public MSLLHOOKSTRUCT? MouseData { get; set; }

        /// <summary>WParam value associated with the event.</summary>
        public IntPtr WParam { get; set; }
    }
}