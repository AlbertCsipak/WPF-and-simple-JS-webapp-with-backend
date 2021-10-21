using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface IAdvancedLogic
    {
        IEnumerable<KeyValuePair<string, double>> AVGServiceCostByBrands();
        IEnumerable<KeyValuePair<string, List<Brand>>> CarBrandsInService();
        IEnumerable<KeyValuePair<string, Dictionary<int, int>>> EveryCarWithMoreThan110HP();
        IEnumerable<KeyValuePair<string, Dictionary<Enums.EngineType, int>>> MechanicEngineTypeCount();
        IEnumerable<KeyValuePair<string, double>> ServiceIncome();
    }
}