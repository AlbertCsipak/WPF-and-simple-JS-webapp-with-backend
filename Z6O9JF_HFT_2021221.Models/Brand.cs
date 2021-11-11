using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Engine> Engines { get; set; }

        public Brand()
        {
            Cars = new HashSet<Car>();
            Engines = new HashSet<Engine>();
        }
    }
}
