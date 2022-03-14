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
    public class BrandController : ControllerBase
    {
        IBrandLogic myLogic;
        IHubContext<SignalRHub> hub;
        public BrandController(IBrandLogic entity, IHubContext<SignalRHub> hub)
        {
            myLogic = entity;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return myLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return myLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            myLogic.Create(value);
            hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            myLogic.Update(value);
            hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var get = myLogic.Read(id);
            myLogic.Delete(id);
            hub.Clients.All.SendAsync("BrandDeleted", get);
        }
    }
}
