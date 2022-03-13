using System;
using System.Windows;
using System.Windows.Threading;
using Z6O9JF_HFT_2021221.WPFClient.UserControls;

namespace Z6O9JF_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarControl carControl = new();
        MechanicControl mechanicControl = new();
        BrandControl brandControl = new();
        public MainWindow()
        {
            InitializeComponent();
            Clock();
        }

        void Clock()
        {
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void CarButton(object sender, RoutedEventArgs e)
        {
           cc_MainMenu.Content = carControl;
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = null;
        }
        private void MechanicButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = mechanicControl;
        }
        private void BrandButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = brandControl;
        }
    }
}
