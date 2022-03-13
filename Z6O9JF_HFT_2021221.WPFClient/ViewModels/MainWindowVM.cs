using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class MainWindowVM
    {
        public MainWindowVM()
        {
            //booster
            RestCollection<Car> cars = new RestCollection<Car>("http://localhost:11111/", "car", "hub");
        }

    }
}
