using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z6O9JF_HFT_2021221.Models
{
    public class CarService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxNumber { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [NotMapped]
        public virtual ICollection<Mechanic> Mechanics { get; set; }

        public CarService()
        {
            Mechanics = new HashSet<Mechanic>();
        }
    }
}
