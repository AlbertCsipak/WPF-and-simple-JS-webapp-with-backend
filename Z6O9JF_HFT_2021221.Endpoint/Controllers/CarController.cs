using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Endpoint.Services;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic myLogic;
        IHubContext<SignalRHub> hub;
        public CarController(ICarLogic entity, IHubContext<SignalRHub> hub)
        {
            myLogic = entity;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("CarCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Car value)
        {
            myLogic.Update(value);
            hub.Clients.All.SendAsync("CarUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var car = myLogic.Read(id);
            myLogic.Delete(id);
            hub.Clients.All.SendAsync("CarDeleted", car);
        }
    }
}
