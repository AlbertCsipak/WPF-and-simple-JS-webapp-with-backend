using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class BrandControlLogic : IBrandControlLogic
    {
        RestCollection<Brand> brands;
        RestService restService = new("http://localhost:11111/");
        IMessenger messenger;

        public BrandControlLogic(IMessenger messenger) { this.messenger = messenger; }

        public void Setup(RestCollection<Brand> brands)
        {
            this.brands = brands;
        }

        public void Add(Brand brand)
        {
            Brand newBrand = new Brand()
            {
                Name = brand.Name,
                Location = brand.Location
            };
            brands.Add(newBrand);
            messenger.Send("msg", "BasicChannel");
        }

        public void Edit(Brand brand)
        {
            brands.Update(brand);
            messenger.Send("msg", "BasicChannel");
        }
        public void Remove(Brand brand)
        {
            brands.Delete(brand.BrandId);
            messenger.Send("msg", "BasicChannel");
        }
    }
}
