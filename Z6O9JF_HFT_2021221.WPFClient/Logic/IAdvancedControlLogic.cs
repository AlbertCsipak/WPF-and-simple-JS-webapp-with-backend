using System.Collections.ObjectModel;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public interface IAdvancedControlLogic
    {
        void Setup(ObservableCollection<string> serviceIncome, ObservableCollection<string> mechanicEngineTypes, 
            ObservableCollection<string> avgServiceCost, ObservableCollection<string> carBrandsInService);
    }
}