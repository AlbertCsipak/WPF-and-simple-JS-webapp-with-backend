using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Windows;

namespace Z6O9JF_HFT_2021221.WPFClient.Services
{
    public class CarCreatorViaWindow : ICarCreatorService
    {
        public void Create(Car car)
        {
            new CarCreatorWindow(car).ShowDialog();
        }
    }
}
