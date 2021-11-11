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
    [Route("[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        IMechanicLogic myLogic;
        public MechanicController(IMechanicLogic entity)
        {
            myLogic = entity;
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
        }

        [HttpPut]
        public void Put([FromBody] Mechanic value)
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
