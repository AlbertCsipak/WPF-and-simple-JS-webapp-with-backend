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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Z6O9JF_HFT_2021221.WPFClient.ViewModels;

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
