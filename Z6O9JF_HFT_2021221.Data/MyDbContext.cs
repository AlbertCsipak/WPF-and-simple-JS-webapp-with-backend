using System;
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
                .HasForeignKey(Mechanic =>Mechanic.ServiceNumber)
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

            CarService ServiceOne = new CarService(){ Location = "Hungary", Name = "Bekre Pál AutóSzerelde", TaxNumber = 583729174 };

            Mechanic m1 = new Mechanic() { ServiceNumber = ServiceOne.TaxNumber, Name = "Béla", MechanicId = 1 };
            Mechanic m2 = new Mechanic() { ServiceNumber = ServiceOne.TaxNumber, Name = "Géza", MechanicId = 2 };
            Mechanic m3 = new Mechanic() { ServiceNumber = ServiceOne.TaxNumber, Name = "Ádám", MechanicId = 3 };
            Mechanic m4 = new Mechanic() { ServiceNumber = ServiceOne.TaxNumber, Name = "Robi", MechanicId = 4 };

            Owner o1 = new Owner() { Name = "Géza", OwnerId = 1 };
            Owner o2 = new Owner() { Name = "Béla", OwnerId = 2 };
            Owner o3 = new Owner() { Name = "Dániel", OwnerId = 3 };

            Brand audi = new Brand() { Name = "Audi", Location = "Germany", BrandId = 1 };
            Brand vw = new Brand() { Name = "VW", Location = "Germany", BrandId = 8 };
            Brand bmw = new Brand() { Name = "BMW", Location = "Germany", BrandId = 2 };
            Brand mercedes = new Brand() { Name = "Mercedes", Location = "Germany", BrandId = 3 };
            Brand honda = new Brand() { Name = "Honda", Location = "Japan", BrandId = 4 };
            Brand peugeot = new Brand() { Name = "Peugeot", Location = "France", BrandId = 5 };
            Brand hyundai = new Brand() { Name = "Hyundai", Location = "SouthKorea", BrandId = 6 };
            Brand chevrolet = new Brand() { Name = "Chevrolet", Location = "USA", BrandId = 7 };

            Engine h1 = new Engine() 
            { 
                BrandId = honda.BrandId, 
                Displacement = 1688, 
                Power = 100, 
                EngineType = Enums.EngineType.Gasoline, 
                EngineCode = 12742322 
            };
            Engine h2 = new Engine()
            {
                BrandId = honda.BrandId,
                Displacement = 1688,
                Power = 130,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 6748974
            };
            Engine vw1 = new Engine()
            {
                BrandId = vw.BrandId,
                Displacement = 1896,
                Power = 105,
                EngineType = Enums.EngineType.Gasoline,
                EngineCode = 5123123
            };
            Engine vw2 = new Engine()
            {
                BrandId = vw.BrandId,
                Displacement = 1388,
                Power = 122,
                EngineType = Enums.EngineType.Petrol,
                EngineCode = 9846372
            };

            Car c1 = new Car()
            {
                BodyStyle = Enums.BodyStyleEnum.Hatchback,
                BrandId = audi.BrandId,
                Color = Enums.ColorEnum.Black,
                EngineCode = vw1.EngineCode,
                MechanicId = m1.MechanicId,
                Vin = 563821741,
                OwnerId = o1.OwnerId,
                Model = "A3"
            };
            Car c2 = new Car()
            {
                BodyStyle = Enums.BodyStyleEnum.Hatchback,
                BrandId = vw.BrandId,
                Color = Enums.ColorEnum.Blue,
                EngineCode = vw2.EngineCode,
                MechanicId = m2.MechanicId,
                Vin = 563141741,
                OwnerId = o2.OwnerId,
                Model = "Golf mk 7"
            };
            Car c3 = new Car()
            {
                BodyStyle = Enums.BodyStyleEnum.Hatchback,
                BrandId = honda.BrandId,
                Color = Enums.ColorEnum.White,
                EngineCode = h1.EngineCode,
                MechanicId = m3.MechanicId,
                Vin = 993141741,
                OwnerId = o3.OwnerId,
                Model = "Golf mk 7"
            };

            modelBuilder.Entity<CarService>().HasData(ServiceOne);
            modelBuilder.Entity<Mechanic>().HasData(m1,m2,m3);
            modelBuilder.Entity<Owner>().HasData(o1,o2,o3);
            modelBuilder.Entity<Brand>().HasData(bmw, vw, audi,mercedes,honda,peugeot,hyundai,chevrolet);
            modelBuilder.Entity<Engine>().HasData(h1,h2,vw1,vw2);
            modelBuilder.Entity<Car>().HasData(c1,c2,c3);
        }
    }
}
