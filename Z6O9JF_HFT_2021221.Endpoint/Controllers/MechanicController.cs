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
    public class MechanicController : ControllerBase
    {
        IMechanicLogic myLogic;
        IHubContext<SignalRHub> hub;
        public MechanicController(IMechanicLogic entity, IHubContext<SignalRHub> hub)
        {
            myLogic = entity;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Mechanic> Get()
        {
            return myLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Mechanic Get(int id)
        {
            return myLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Mechanic value)
        {
            myLogic.Create(value);
            hub.Clients.All.SendAsync("MechanicCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Mechanic value)
        {
            myLogic.Update(value);
            hub.Clients.All.SendAsync("MechanicUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = myLogic.Read(id);
            myLogic.Delete(id);
            hub.Clients.All.SendAsync("MechanicDeleted", value);
        }
    }
}
