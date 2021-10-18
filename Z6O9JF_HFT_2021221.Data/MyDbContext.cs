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
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;MultipleActiveResultSets=True";
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

            CarService s1 = new(){ Location = "Hungary", Name = "Bekre Pál AutóSzerelde", TaxNumber = 5837 };
            CarService s2 = new() { Location = "UK", Name = "Bro Ken Carservice", TaxNumber = 1134 };

            Mechanic m1 = new() { ServiceId = s1.TaxNumber, Name = "Béla", MechanicId = 1 };
            Mechanic m2 = new() { ServiceId = s2.TaxNumber, Name = "Géza", MechanicId = 2 };
            Mechanic m3 = new() { ServiceId = s1.TaxNumber, Name = "Ádám", MechanicId = 3 };
            Mechanic m4 = new() { ServiceId = s2.TaxNumber, Name = "Robi", MechanicId = 4 };

            Owner o1 = new() { Name = "Géza", OwnerId = 1 };
            Owner o2 = new() { Name = "Béla", OwnerId = 2 };
            Owner o3 = new() { Name = "Dániel", OwnerId = 3 };

            Brand b1 = new() { Name = "Audi", Location = "Germany", BrandId = 1 };
            Brand b2 = new() { Name = "VW", Location = "Germany", BrandId = 8 };
            Brand b3 = new() { Name = "BMW", Location = "Germany", BrandId = 2 };
            Brand b4 = new() { Name = "Mercedes", Location = "Germany", BrandId = 3 };
            Brand b5 = new() { Name = "Honda", Location = "Japan", BrandId = 4 };
            Brand b6 = new() { Name = "Peugeot", Location = "France", BrandId = 5 };
            Brand b7 = new() { Name = "Hyundai", Location = "SouthKorea", BrandId = 6 };
            Brand b8 = new() { Name = "Chevrolet", Location = "USA", BrandId = 7 };

            Engine e1 = new() 
            { 
                BrandId = b5.BrandId, 
                Displacement = 1688, 
                Power = 100, 
                EngineType = Enums.EngineType.Gasoline, 
                EngineCode = 1274232
            };
            Engine e2 = new()
            {
                BrandId = b5.BrandId,
                Displacement = 1688,
                Power = 130,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 6748974
            };
            Engine e3 = new()
            {
                BrandId = b2.BrandId,
                Displacement = 1896,
                Power = 105,
                EngineType = Enums.EngineType.Gasoline,
                EngineCode = 5123123
            };
            Engine e4 = new()
            {
                BrandId = b2.BrandId,
                Displacement = 1388,
                Power = 122,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 9846372
            };
            Engine e5 = new()
            {
                BrandId = b1.BrandId,
                Displacement = 2480,
                Power = 400,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 1968473
            };

            List<Car> carList = new();

            Car c1 = new()
            {
                BrandId = b8.BrandId,
                EngineCode = e3.EngineCode,
                MechanicId = m4.MechanicId,
                Vin = 886144430,
                OwnerId = o3.OwnerId,
                ServiceCost = 1700
            };
            carList.Add(c1);

            Car c2 = new()
            {
                BrandId = b3.BrandId,
                EngineCode = e1.EngineCode,
                MechanicId = m1.MechanicId,
                Vin = 476958188,
                OwnerId = o1.OwnerId,
                ServiceCost = 3500
            };
            carList.Add(c2);

            Car c3 = new()
            {
                BrandId = b3.BrandId,
                EngineCode = e4.EngineCode,
                MechanicId = m1.MechanicId,
                Vin = 726486262,
                OwnerId = o2.OwnerId,
                ServiceCost = 200
            };
            carList.Add(c3);

            Car c4 = new()
            {
                BrandId = b8.BrandId,
                EngineCode = e1.EngineCode,
                MechanicId = m3.MechanicId,
                Vin = 287686963,
                OwnerId = o1.OwnerId,
                ServiceCost = 900
            };
            carList.Add(c4);

            Car c5 = new()
            {
                BrandId = b7.BrandId,
                EngineCode = e4.EngineCode,
                MechanicId = m3.MechanicId,
                Vin = 785422199,
                OwnerId = o1.OwnerId,
                ServiceCost = 2000
            };
            carList.Add(c5);

            Car c6 = new()
            {
                BrandId = b5.BrandId,
                EngineCode = e5.EngineCode,
                MechanicId = m2.MechanicId,
                Vin = 614342478,
                OwnerId = o3.OwnerId,
                ServiceCost = 3300
            };
            carList.Add(c6);

            Car c7 = new()
            {
                BrandId = b3.BrandId,
                EngineCode = e4.EngineCode,
                MechanicId = m1.MechanicId,
                Vin = 261246868,
                OwnerId = o2.OwnerId,
                ServiceCost = 3400
            };
            carList.Add(c7);

            Car c8 = new()
            {
                BrandId = b5.BrandId,
                EngineCode = e1.EngineCode,
                MechanicId = m1.MechanicId,
                Vin = 152599871,
                OwnerId = o1.OwnerId,
                ServiceCost = 300
            };
            carList.Add(c8);

            Car c9 = new()
            {
                BrandId = b1.BrandId,
                EngineCode = e3.EngineCode,
                MechanicId = m2.MechanicId,
                Vin = 417037113,
                OwnerId = o3.OwnerId,
                ServiceCost = 200
            };
            carList.Add(c9);

            Car c10 = new()
            {
                BrandId = b3.BrandId,
                EngineCode = e2.EngineCode,
                MechanicId = m2.MechanicId,
                Vin = 187238463,
                OwnerId = o2.OwnerId,
                ServiceCost = 900
            };
            carList.Add(c10);

            modelBuilder.Entity<CarService>().HasData(s1,s2);
            modelBuilder.Entity<Mechanic>().HasData(m1,m2,m3,m4);
            modelBuilder.Entity<Owner>().HasData(o1,o2,o3);
            modelBuilder.Entity<Brand>().HasData(b1,b2,b3,b4,b5,b6,b7,b8);
            modelBuilder.Entity<Engine>().HasData(e1,e2,e3,e4,e5);
            modelBuilder.Entity<Car>().HasData(carList);
        }
    }
}
