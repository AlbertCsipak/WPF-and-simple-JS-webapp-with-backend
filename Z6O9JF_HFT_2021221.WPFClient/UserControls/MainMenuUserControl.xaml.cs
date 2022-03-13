using System.Windows;
using System.Windows.Controls;

namespace Z6O9JF_HFT_2021221.WPFClient.UserControls
{
    /// <summary>
    /// Interaction logic for MainMenuUserControl.xaml
    /// </summary>
    public partial class MainMenuUserControl : UserControl
    {
        ContentControl CC;
        public MainMenuUserControl(ContentControl cc)
        {
            InitializeComponent();
            this.CC = cc;
        }
        public MainMenuUserControl()
        {

        }

        private void ShowCarMenu(object sender, RoutedEventArgs e)
        {
            CC.Content = new CarMenuUserControl(CC);
        }
    }
}
