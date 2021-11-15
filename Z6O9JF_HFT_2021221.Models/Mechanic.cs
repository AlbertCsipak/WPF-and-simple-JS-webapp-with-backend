using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Mechanic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MechanicId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual CarService CarService { get; set; }

        [ForeignKey(nameof(CarService))]
        public int ServiceId { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }
        public override string ToString()
        {
            string name = "-";
            if (Name != null)
            {
                name = Name;
            }
            return $"MechanicID: {MechanicId}\tName: {name}";
        }
        public Mechanic()
        {
            Cars = new HashSet<Car>();
        }
    }
}
