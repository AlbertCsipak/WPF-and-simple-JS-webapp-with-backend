using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vin { get; set; }
        public enum BodyStyleEnum { Sedan, Hatchback, Coupe, Wagon }
        public BodyStyleEnum BodyStyle { get; set; }
        public enum ColorEnum {Green,Blue,Black,White,Gray,Yellow,Red }
        public ColorEnum Color { get; set; }
    }
}
