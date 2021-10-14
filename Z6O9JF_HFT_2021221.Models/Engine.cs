using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Engine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EngineCode { get; set; }
        public int Displacement { get; set; }
        public int Power { get; set; }
        public Enums.EngineType EngineType { get; set; }

        [NotMapped]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public Engine()
        {
            Cars = new HashSet<Car>();
        }
    }
}
