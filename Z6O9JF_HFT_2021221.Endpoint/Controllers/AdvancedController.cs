using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.Repository;

namespace Z6O9JF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdvancedController : ControllerBase
    {
        IAdvancedLogic myLogic;
        public AdvancedController(IAdvancedLogic entity)
        {
            myLogic = entity;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGServiceCostByBrands()
        {
            return myLogic.AVGServiceCostByBrands();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, List<string>>> CarBrandsInService() 
        {
            return myLogic.CarBrandsInService();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, List<Car>>> OwnersAndTheirStrongestCar() 
        {
            return myLogic.OwnersAndTheirStrongestCar();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, List<Enums.EngineType>>> MechanicEngineTypes()
        {
            return myLogic.MechanicEngineTypes();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> ServiceIncome() 
        {
            return myLogic.ServiceIncome();
        }
    }
}
