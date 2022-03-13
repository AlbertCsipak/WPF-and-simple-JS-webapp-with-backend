using System.Windows.Controls;

namespace Z6O9JF_HFT_2021221.WPFClient.UserControls
{
    /// <summary>
    /// Interaction logic for CarMenuUserControl.xaml
    /// </summary>
    public partial class CarMenuUserControl : UserControl
    {
        ContentControl CC;
        public CarMenuUserControl(ContentControl cc)
        {
            InitializeComponent();
            this.CC = cc;
        }
        public CarMenuUserControl()
        {

        }
    }
}
