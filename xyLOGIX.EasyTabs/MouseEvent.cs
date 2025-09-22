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
        public int Code { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>LParam value associated with the event.</summary>
        public IntPtr LParam { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>Data associated with the mouse event.</summary>
        public MSLLHOOKSTRUCT? MouseData { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>WParam value associated with the event.</summary>
        public IntPtr WParam { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }
    }
}