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
        public Enums.BodyStyleEnum BodyStyle { get; set; }
        public Enums.ColorEnum Color { get; set; }

        [NotMapped]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public virtual Mechanic Mechanic { get; set; }

        [NotMapped]
        public virtual Owner Owner { get; set; }

        [NotMapped]
        public virtual Engine Engine { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        [ForeignKey(nameof(Mechanic))]
        public int MechanicId { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(Engine))]
        public int EngineCode { get; set; }
    }
}
