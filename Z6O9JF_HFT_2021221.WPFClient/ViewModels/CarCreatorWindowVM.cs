using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class CarCreatorWindowVM
    {
        public Car Car { get; set; }
        public CarCreatorWindowVM(Car car)
        {
            this.Car = car;
        }
        public CarCreatorWindowVM()
        {

        }
    }

}
