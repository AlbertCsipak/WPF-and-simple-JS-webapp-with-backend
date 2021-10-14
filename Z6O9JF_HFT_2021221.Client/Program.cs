using System;
using Z6O9JF_HFT_2021221.Data;
namespace Z6O9JF_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext db = new MyDbContext();
            db.SaveChanges();
            ;
        }
    }
}
