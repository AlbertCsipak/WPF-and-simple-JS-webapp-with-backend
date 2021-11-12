using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public virtual ICollection<Car> Cars { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public Engine()
        {
            Cars = new HashSet<Car>();
        }
    }
}
