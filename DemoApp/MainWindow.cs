using xyLOGIX.EasyTabs;

namespace DemoApp
{
    /// <summary>
    /// The main window of the application.
    /// </summary>
    public partial class MainWindow : TitleBarTabs
    {
        /// <summary>
        /// Constructs a new instance of <see cref="T:DemoApp.MainWindow" /> and returns a
        /// reference to it.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Enable or disable viewing tabs through the taskbar
            AeroPeekEnabled = true;

            // Set the tab rendering engine that you wish to use
            TabRenderer = new ChromeTabRenderer(this);
        }

        /// <summary>
        /// Callback that should be implemented by the inheriting class that will create a
        /// new <see cref="T:xyLOGIX.EasyTabs.TitleBarTab" /> object when the add button is
        /// clicked.
        /// </summary>
        /// <returns>A newly created tab.</returns>
        public override TitleBarTab CreateTab()
            => new TitleBarTab(this) { Content = new MyTabContent() };
    }
}