using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeatherApp.ViewModel;

namespace WeatherApp.View
{
    /// <summary>
    /// Interaction logic for WeatherWindow.xaml
    /// </summary>
    public partial class WeatherWindow : Window
    {
        private readonly WeatherViewModel _viewModel = new WeatherViewModel();
        public WeatherWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }
        //exit button
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //minimalize button
        private void MinimalizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //scrolling list of days in panel
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
            e.Handled = true;
        }
        //pass Data to WeatherViewModel after click launch button
        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Reset();
            _viewModel.SetCity(CityTextBox.Text);
            _viewModel.SetDays(DaysTextBox.Text);
            _viewModel.CreateHTTPRequestURL();
            _viewModel.GetXMLData();
            _viewModel.PopulateDayWeatherList();
            _viewModel.GetReturnedLocation();
            lvDataBinding.ItemsSource = _viewModel.daysObservableCollection;
        }
    }
}
