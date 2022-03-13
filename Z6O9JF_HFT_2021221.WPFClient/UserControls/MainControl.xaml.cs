using System.Windows;
using System.Windows.Controls;

namespace Z6O9JF_HFT_2021221.WPFClient.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenuUserControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        ContentControl CC;
        public MainControl(ContentControl cc)
        {
            InitializeComponent();
            this.CC = cc;
        }
        public MainControl()
        {

        }

        private void ShowCarMenu(object sender, RoutedEventArgs e)
        {
            CC.Content = new CarControl();
        }
    }
}
