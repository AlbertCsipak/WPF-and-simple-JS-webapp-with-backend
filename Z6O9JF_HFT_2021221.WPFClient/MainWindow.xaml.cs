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
        public MainWindow()
        {
            InitializeComponent();
            Clock();
            cc_MainMenu.Content = new AdvancedControl();
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
            cc_MainMenu.Content = new CarControl();
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = new AdvancedControl();
        }
        private void MechanicButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = new MechanicControl();
        }
        private void BrandButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = new BrandControl();
        }
    }
}
