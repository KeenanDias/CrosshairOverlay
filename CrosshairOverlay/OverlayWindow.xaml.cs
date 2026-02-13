using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace CrosshairOverlay
{
    public partial class OverlayWindow : Window
    {
        public OverlayWindow()
        {
            InitializeComponent();
        }

        // This runs when the window loads. It tells Windows to make this window "Transparent" to clicks.
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Get this window's ID (Handle)
            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            // Get current styles
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);

            // Add "Transparent" (Click-Through) and "ToolWindow" (Hide from Alt-Tab)
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT | WS_EX_TOOLWINDOW);
        }

        // --- Standard Win32 API Definitions ---
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int WS_EX_TOOLWINDOW = 0x00000080;
        const int GWL_EXSTYLE = -20;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
    }
}