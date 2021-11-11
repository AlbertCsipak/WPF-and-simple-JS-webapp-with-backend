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
    public class EngineController : ControllerBase
    {
        IEngineLogic myLogic;
        public EngineController(IEngineLogic entity)
        {
            myLogic = entity;
        }

        [HttpGet]
        public IEnumerable<Engine> Get()
        {
            return myLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Engine Get(int id)
        {
            return myLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Engine value)
        {
            myLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Engine value)
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
