using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public interface IMechanicControlLogic
    {
        void Add(Mechanic mechanic);
        void Edit(Mechanic mechanic);
        void Remove(Mechanic mechanic);
        void Setup(RestCollection<Mechanic> mechanic);
    }
}