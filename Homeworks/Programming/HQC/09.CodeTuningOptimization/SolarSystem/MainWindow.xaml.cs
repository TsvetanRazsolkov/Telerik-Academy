using System.Windows;

namespace SolarSystem
{
    /// <summary>
	/// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrbitsCalculator _data = new OrbitsCalculator();
        public MainWindow()
        {
            DataContext = _data;
            //// Before optimization. May actually need this, but the app seems to work correctly :)
            //InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _data.StartTimer();
        }

        private void Pause_Checked(object sender, RoutedEventArgs e)
        {
            _data.Pause(true);
        }

        private void Pause_Unchecked(object sender, RoutedEventArgs e)
        {
            _data.Pause(false);
        }
    }
}
