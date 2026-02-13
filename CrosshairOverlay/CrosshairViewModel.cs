using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace CrosshairOverlay
{
    public class CrosshairViewModel : INotifyPropertyChanged
    {
        // --- 1. Dimensions ---
        private double _gap = 10;
        private double _thickness = 4; // Thicker by default like your image
        private double _length = 10;
        private double _dotSize = 4;
        private double _outlineThickness = 2; // Critical for the "Pop" look

        public double Gap { get => _gap; set { _gap = value; OnPropertyChanged(); } }
        public double Thickness { get => _thickness; set { _thickness = value; OnPropertyChanged(); } }
        public double Length { get => _length; set { _length = value; OnPropertyChanged(); } }
        public double DotSize { get => _dotSize; set { _dotSize = value; OnPropertyChanged(); } }
        public double OutlineThickness { get => _outlineThickness; set { _outlineThickness = value; OnPropertyChanged(); } }

        // --- 2. Toggles ---
        private bool _showDot = true;
        private bool _showOutlines = true;
        public bool ShowDot { get => _showDot; set { _showDot = value; OnPropertyChanged(); } }
        public bool ShowOutlines { get => _showOutlines; set { _showOutlines = value; OnPropertyChanged(); } }

        // --- 3. Colors (Inner vs Outer) ---
        // We manage R, G, B individually so Sliders can bind to them directly
        private byte _mainR = 0, _mainG = 255, _mainB = 255; // Cyan default
        private byte _outR = 0, _outG = 0, _outB = 139;       // Dark Blue default

        public double MainR { get => _mainR; set { _mainR = (byte)value; OnPropertyChanged(); UpdateMainBrush(); } }
        public double MainG { get => _mainG; set { _mainG = (byte)value; OnPropertyChanged(); UpdateMainBrush(); } }
        public double MainB { get => _mainB; set { _mainB = (byte)value; OnPropertyChanged(); UpdateMainBrush(); } }

        public double OutR { get => _outR; set { _outR = (byte)value; OnPropertyChanged(); UpdateOutlineBrush(); } }
        public double OutG { get => _outG; set { _outG = (byte)value; OnPropertyChanged(); UpdateOutlineBrush(); } }
        public double OutB { get => _outB; set { _outB = (byte)value; OnPropertyChanged(); UpdateOutlineBrush(); } }

        // These are the Brushes the UI actually uses
        private SolidColorBrush _mainBrush = new SolidColorBrush(Color.FromRgb(0, 255, 255));
        private SolidColorBrush _outlineBrush = new SolidColorBrush(Color.FromRgb(0, 0, 139));

        public SolidColorBrush MainBrush { get => _mainBrush; private set { _mainBrush = value; OnPropertyChanged(); } }
        public SolidColorBrush OutlineBrush { get => _outlineBrush; private set { _outlineBrush = value; OnPropertyChanged(); } }

        private void UpdateMainBrush() => MainBrush = new SolidColorBrush(Color.FromRgb(_mainR, _mainG, _mainB));
        private void UpdateOutlineBrush() => OutlineBrush = new SolidColorBrush(Color.FromRgb(_outR, _outG, _outB));


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}