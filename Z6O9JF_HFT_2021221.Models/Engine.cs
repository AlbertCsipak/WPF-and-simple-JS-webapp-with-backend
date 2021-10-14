using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Engine
    {
        public string EngineCode { get; set; }
        public int Displacement { get; set; }
        public int Power { get; set; }
        public Enums.EngineType EngineType { get; set; }
    }
}
