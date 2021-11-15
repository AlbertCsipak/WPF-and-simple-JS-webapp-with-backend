using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }
        public override string ToString()
        {
            string name = "-";
            if (Name != null)
            {
                name = Name;
            }
            return $"OwnerID: {OwnerId}\tName: {name}";
        }
        public Owner()
        {
            Cars = new HashSet<Car>();
        }
    }
}
