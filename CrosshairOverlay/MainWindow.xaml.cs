using System; // Needed for EventArgs
using System.Windows;

namespace CrosshairOverlay
{
    public partial class MainWindow : Window
    {
        // 1. Create the shared data source
        private CrosshairViewModel _viewModel = new CrosshairViewModel();
        private OverlayWindow _overlay;

        public MainWindow()
        {
            InitializeComponent();

            // 2. Connect the "Brain" (ViewModel) to this window (The Sliders)
            this.DataContext = _viewModel;

            // 3. Create and show the overlay
            _overlay = new OverlayWindow();

            // 4. Connect the SAME "Brain" to the overlay so they share data
            _overlay.DataContext = _viewModel;
            _overlay.Show();
        }

        // Close the overlay when the main app closes
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Close the overlay explicitly to prevent it from hanging in the background
            if (_overlay != null)
            {
                _overlay.Close();
            }

            Application.Current.Shutdown();
        }
    }
}