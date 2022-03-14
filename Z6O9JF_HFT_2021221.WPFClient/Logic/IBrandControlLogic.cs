using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public interface IBrandControlLogic
    {
        void Add(Brand brand);
        void Edit(Brand brand);
        void Remove(Brand brand);
        void Setup(RestCollection<Brand> brands);
    }
}