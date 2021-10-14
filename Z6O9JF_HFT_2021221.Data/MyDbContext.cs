using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Data
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Mechanic> Mechanic { get; set; }
        public virtual DbSet<CarService> Service { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }

        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbBuilder)
        {
            if (!dbBuilder.IsConfigured)
            {
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
                dbBuilder.UseLazyLoadingProxies();
                dbBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasOne(car => car.Owner)
                .WithMany(Owner => Owner.Cars)
                .HasForeignKey(car => car.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasOne(car => car.Engine)
                .WithMany(Engine => Engine.Cars)
                .HasForeignKey(car => car.EngineCode)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasOne(car => car.Mechanic)
                .WithMany(Mechanic => Mechanic.Cars)
                .HasForeignKey(car => car.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Mechanic>(entity =>
            {
                entity
                .HasOne(Mechanic => Mechanic.CarService)
                .WithMany(Service => Service.Mechanics)
                .HasForeignKey(Mechanic =>Mechanic.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Engine>(entity =>
            {
                entity
                .HasOne(Engine => Engine.Brand)
                .WithMany(Brand => Brand.Engines)
                .HasForeignKey(Engine => Engine.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            CarService ServiceOne = new(){ Location = "Hungary", Name = "Bekre Pál AutóSzerelde", TaxNumber = 583729174 };

            Mechanic m1 = new() { ServiceId = ServiceOne.TaxNumber, Name = "Béla", MechanicId = 1 };
            Mechanic m2 = new() { ServiceId = ServiceOne.TaxNumber, Name = "Géza", MechanicId = 2 };
            Mechanic m3 = new() { ServiceId = ServiceOne.TaxNumber, Name = "Ádám", MechanicId = 3 };
            Mechanic m4 = new() { ServiceId = ServiceOne.TaxNumber, Name = "Robi", MechanicId = 4 };

            Owner o1 = new() { Name = "Géza", OwnerId = 1 };
            Owner o2 = new() { Name = "Béla", OwnerId = 2 };
            Owner o3 = new() { Name = "Dániel", OwnerId = 3 };

            Brand audi = new() { Name = "Audi", Location = "Germany", BrandId = 1 };
            Brand vw = new() { Name = "VW", Location = "Germany", BrandId = 8 };
            Brand bmw = new() { Name = "BMW", Location = "Germany", BrandId = 2 };
            Brand mercedes = new() { Name = "Mercedes", Location = "Germany", BrandId = 3 };
            Brand honda = new() { Name = "Honda", Location = "Japan", BrandId = 4 };
            Brand peugeot = new() { Name = "Peugeot", Location = "France", BrandId = 5 };
            Brand hyundai = new() { Name = "Hyundai", Location = "SouthKorea", BrandId = 6 };
            Brand chevrolet = new() { Name = "Chevrolet", Location = "USA", BrandId = 7 };

            Engine h1 = new() 
            { 
                BrandId = honda.BrandId, 
                Displacement = 1688, 
                Power = 100, 
                EngineType = Enums.EngineType.Gasoline, 
                EngineCode = 1274232
            };
            Engine h2 = new()
            {
                BrandId = honda.BrandId,
                Displacement = 1688,
                Power = 130,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 6748974
            };
            Engine vw1 = new()
            {
                BrandId = vw.BrandId,
                Displacement = 1896,
                Power = 105,
                EngineType = Enums.EngineType.Gasoline,
                EngineCode = 5123123
            };
            Engine vw2 = new()
            {
                BrandId = vw.BrandId,
                Displacement = 1388,
                Power = 122,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 9846372
            };
            Engine audi1 = new()
            {
                BrandId = audi.BrandId,
                Displacement = 2480,
                Power = 400,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 1968473
            };

            Car c1 = new()
            {
                BodyStyle = Enums.BodyStyleEnum.Hatchback,
                BrandId = audi.BrandId,
                Color = Enums.ColorEnum.Black,
                EngineCode = vw1.EngineCode,
                MechanicId = m1.MechanicId,
                Vin = 563821741,
                OwnerId = o1.OwnerId,
                Model = "A3",
                ServiceCost = 300
            };
            Car c2 = new()
            {
                BodyStyle = Enums.BodyStyleEnum.Hatchback,
                BrandId = vw.BrandId,
                Color = Enums.ColorEnum.Blue,
                EngineCode = vw2.EngineCode,
                MechanicId = m2.MechanicId,
                Vin = 563141741,
                OwnerId = o2.OwnerId,
                Model = "Golf mk 7",
                ServiceCost = 600
            };
            Car c3 = new()
            {
                BodyStyle = Enums.BodyStyleEnum.Hatchback,
                BrandId = honda.BrandId,
                Color = Enums.ColorEnum.White,
                EngineCode = h1.EngineCode,
                MechanicId = m3.MechanicId,
                Vin = 993141741,
                OwnerId = o3.OwnerId,
                Model = "Civic gen7",
                ServiceCost = 150
            };
            Car c4 = new()
            {
                BodyStyle = Enums.BodyStyleEnum.Sedan,
                BrandId = audi.BrandId,
                Color = Enums.ColorEnum.Red,
                EngineCode = audi1.EngineCode,
                MechanicId = m2.MechanicId,
                Vin = 993144567,
                OwnerId = o1.OwnerId,
                Model = "RS3",
                ServiceCost = 1500
            };

            modelBuilder.Entity<CarService>().HasData(ServiceOne);
            modelBuilder.Entity<Mechanic>().HasData(m1,m2,m3);
            modelBuilder.Entity<Owner>().HasData(o1,o2,o3);
            modelBuilder.Entity<Brand>().HasData(bmw, vw, audi,mercedes,honda,peugeot,hyundai,chevrolet);
            modelBuilder.Entity<Engine>().HasData(h1,h2,vw1,vw2,audi1);
            modelBuilder.Entity<Car>().HasData(c1,c2,c3,c4);
        }
    }
}
