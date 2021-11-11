﻿using Microsoft.AspNetCore.Mvc;
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
    public class CarServiceController : ControllerBase
    {
        ICarServiceLogic myLogic;
        public CarServiceController(ICarServiceLogic entity)
        {
            myLogic = entity;
        }

        [HttpGet]
        public IEnumerable<CarService> Get()
        {
            return myLogic.GetAll();
        }

        [HttpGet("{id}")]
        public CarService Get(int id)
        {
            return myLogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] CarService value)
        {
            myLogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] CarService value)
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
