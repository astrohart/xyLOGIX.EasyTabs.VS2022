using PostSharp.Patterns.Diagnostics;
using System.Windows.Forms;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Represents a handler for a <c>TabClosing</c> event.
    /// </summary>
    /// <param name="sender">
    /// Reference to an instance of <see cref="T:xyLOGIX.EasyTabs.TitleBarTab`1" />
    /// that is about to be closed.
    /// </param>
    /// <param name="e">
    /// A <see cref="T:System.Windows.Forms.FormClosingEventArgs" /> that contains the
    /// event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that handle the
    /// <c>TabClosing</c> event.
    /// </remarks>
    public delegate void TabClosingEventHandler(
        TitleBarTab sender,
        [NotLogged] FormClosingEventArgs e
    );
}