using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class AdvancedControlLogic : IAdvancedControlLogic
    {
        RestService restService;
        ObservableCollection<string> serviceIncome;
        ObservableCollection<string> mechanicEngineTypes;
        ObservableCollection<string> avgServiceCost;
        ObservableCollection<string> carBrandsInService;
        public AdvancedControlLogic()
        {
            restService = new("http://localhost:11111");
        }

        public void Setup(ObservableCollection<string> serviceIncome, ObservableCollection<string> mechanicEngineTypes,
            ObservableCollection<string> avgServiceCost, ObservableCollection<string> carBrandsInService)
        {
            this.serviceIncome = serviceIncome;
            this.mechanicEngineTypes = mechanicEngineTypes;
            this.avgServiceCost = avgServiceCost;
            this.carBrandsInService = carBrandsInService;
            ServiceIncome();
            MechanicEngineTypes();
            AVGServiceCostByBrand();
            CarBrandsInService();
        }

        void ServiceIncome()
        {
            var get = restService.Get<KeyValuePair<string, int>>("advanced/serviceincome");

            foreach (var item in get)
            {
                serviceIncome.Add(item.Key.ToString() + " " + item.Value.ToString());
            }
        }
        void MechanicEngineTypes()
        {
            var get = restService.Get<KeyValuePair<string, List<Enums.EngineType>>>("advanced/mechanicenginetypes");

            foreach (var item in get)
            {
                string content = item.Key.ToString();

                foreach (var item1 in item.Value)
                {
                    content += " "+item1.ToString();
                }

                mechanicEngineTypes.Add(content);
            }
        }
        void AVGServiceCostByBrand()
        {
            var get = restService.Get<KeyValuePair<string, double>>("advanced/avgservicecostbybrands");
            foreach (var item in get)
            {
                avgServiceCost.Add(item.Key.ToString() + " " + item.Value.ToString());
            }

        }
        void CarBrandsInService()
        {
            var get = restService.Get<KeyValuePair<string, List<string>>>("advanced/carbrandsinservice");
            foreach (var item in get)
            {
                string content = item.Key.ToString();

                foreach (var item1 in item.Value)
                {
                    content += " " + item1.ToString();
                }

                carBrandsInService.Add(content);
            }
        }
    }
}
