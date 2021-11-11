using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface IAdvancedLogic
    {
        IEnumerable<KeyValuePair<string, double>> AVGServiceCostByBrands();
        IEnumerable<KeyValuePair<string, List<string>>> CarBrandsInService();
        IEnumerable<KeyValuePair<string, List<Car>>> OwnersAndTheirStrongestCar();
        IEnumerable<KeyValuePair<string, List<Enums.EngineType>>> MechanicEngineTypes();
        IEnumerable<KeyValuePair<string, int>> ServiceIncome();
    }
}