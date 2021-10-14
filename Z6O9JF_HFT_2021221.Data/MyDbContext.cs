using System;
using Microsoft.EntityFrameworkCore;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Data
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<AircraftBrand> AircraftBrand { get; set; }
        public virtual DbSet<AircraftEngine> AircraftEngine { get; set; }
        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
