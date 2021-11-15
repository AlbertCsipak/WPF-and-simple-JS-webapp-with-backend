using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Z6O9JF_HFT_2021221.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vin { get; set; }
        public string Model { get; set; }
        public int ServiceCost { get; set; }
        public Enums.BodyStyleEnum BodyStyle { get; set; }
        public Enums.ColorEnum Color { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Mechanic Mechanic { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Owner Owner { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Engine Engine { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        [ForeignKey(nameof(Mechanic))]
        public int MechanicId { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(Engine))]
        public int EngineCode { get; set; }
        public override string ToString()
        {
            string model = "-";
            if (Model != null)
            {
                model = Model;
            }

            return $"Vin: {Vin}\tBrandID: {BrandId}\tMechanicId: {MechanicId}\tOwnerID: {OwnerId}\tEngineCode: {EngineCode}\tModel: {model}";
        }
    }
}
