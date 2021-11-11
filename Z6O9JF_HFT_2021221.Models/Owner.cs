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
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }

        public Owner()
        {
            Cars = new HashSet<Car>();
        }
    }
}
