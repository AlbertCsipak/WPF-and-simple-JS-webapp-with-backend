using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic myLogic;
        public CarController(ICarLogic entity)
        {
            myLogic = entity;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return myLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return myLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Car value)
        {
            myLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Car value)
        {
            myLogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            myLogic.Delete(id);
        }
    }
}
