using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp8.Models;

namespace WpfApp8.ViewModels
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        private byte _alpha = 255;
        private byte _red = 0;
        private byte _green = 0;
        private byte _blue = 0;

        private bool _isAlphaEnabled = true;
        private bool _isRedEnabled = true;
        private bool _isGreenEnabled = true;
        private bool _isBlueEnabled = true;

        public ObservableCollection<ColorModel> Colors { get; set; } = new ObservableCollection<ColorModel>();

        public byte Alpha
        {
            get => _alpha;
            set { _alpha = value; OnPropertyChanged(); OnPropertyChanged(nameof(CurrentColor)); }
        }
        public byte Red
        {
            get => _red;
            set { _red = value; OnPropertyChanged(); OnPropertyChanged(nameof(CurrentColor)); }
        }
        public byte Green
        {
            get => _green;
            set { _green = value; OnPropertyChanged(); OnPropertyChanged(nameof(CurrentColor)); }
        }
        public byte Blue
        {
            get => _blue;
            set { _blue = value; OnPropertyChanged(); OnPropertyChanged(nameof(CurrentColor)); }
        }

        public bool IsAlphaEnabled
        {
            get => _isAlphaEnabled;
            set { _isAlphaEnabled = value; OnPropertyChanged(); }
        }
        public bool IsRedEnabled
        {
            get => _isRedEnabled;
            set { _isRedEnabled = value; OnPropertyChanged(); }
        }
        public bool IsGreenEnabled
        {
            get => _isGreenEnabled;
            set { _isGreenEnabled = value; OnPropertyChanged(); }
        }
        public bool IsBlueEnabled
        {
            get => _isBlueEnabled;
            set { _isBlueEnabled = value; OnPropertyChanged(); }
        }

        public SolidColorBrush CurrentColor => new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));

        private ColorModel _selectedColor;
        public ColorModel SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAddEnabled));
            }
        }

        public bool IsAddEnabled => !Colors.Contains(new ColorModel { Color = CurrentColor });

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ColorViewModel()
        {
            AddCommand = new RelayCommand(AddColor, _ => IsAddEnabled);
            DeleteCommand = new RelayCommand(DeleteColor);
        }

        private void AddColor(object parameter)
        {
            Colors.Add(new ColorModel { Color = CurrentColor });
            OnPropertyChanged(nameof(IsAddEnabled));
        }

        private void DeleteColor(object parameter)
        {
            if (parameter is ColorModel color)
            {
                Colors.Remove(color);
                OnPropertyChanged(nameof(IsAddEnabled));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
