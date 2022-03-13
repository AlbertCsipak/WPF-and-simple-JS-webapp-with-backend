using System.Windows;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.ViewModels;

namespace Z6O9JF_HFT_2021221.WPFClient.Windows
{
    /// <summary>
    /// Interaction logic for CarCreatorWindow.xaml
    /// </summary>
    public partial class CarCreatorWindow : Window
    {
        public CarCreatorWindow(Car car)
        {
            InitializeComponent();
            this.DataContext = new CarCreatorWindowVM(car);
        }
        public CarCreatorWindow()
        {

        }
    }
}
