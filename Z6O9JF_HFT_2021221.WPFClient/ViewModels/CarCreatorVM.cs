using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class CarCreatorVM
    {
        public Car Car { get; set; }
        public CarCreatorVM(Car car)
        {
            this.Car = car;
        }
        public CarCreatorVM()
        {

        }
    }

}
