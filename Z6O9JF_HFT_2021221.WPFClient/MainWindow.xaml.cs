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
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

            cc_MainMenu.Content = new MainControl(cc_MainMenu);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            cc_MainMenu.Content = new MainControl(cc_MainMenu);
        }
    }
}
