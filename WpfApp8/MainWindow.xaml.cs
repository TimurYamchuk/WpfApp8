using System.Windows;
using WpfApp8.ViewModels; 

namespace WpfApp8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ColorViewModel();
        }
    }
}
